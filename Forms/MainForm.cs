using System;
using System.Drawing;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.Win32;

namespace mxplx
{
	public partial class MainForm : Form
	{
		#region Constants & enumerations

		private const string StartupRegistry = @"Software\Microsoft\Windows\CurrentVersion\Run";
		private const string AppStartName = "mxplx";

		#endregion

		#region Construction

		public MainForm()
		{
			InitializeComponent();

			// Set the icons
			Icon = global::mxplx.Properties.Resources.Settings;
			notifyIcon.Icon = Icon;
			newReminderToolStripMenuItem.Image = global::mxplx.Properties.Resources.Reminder.ToBitmap();
			settingsToolStripMenuItem.Image = Icon.ToBitmap();
		}

		#endregion

		#region Static methods

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static List<Reminder> AllReminders = new List<Reminder>();

		public static int PendingRemindersCount
		{
			get {
				int result = 0;
				foreach (Reminder reminder in AllReminders)
					if (reminder.Active)
						result += 1;
				return result;
			}
		}

		private static void SetStartup(bool startup)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistry, true);

			if ((key.GetValue(AppStartName) == null) && (startup))
				key.SetValue(AppStartName, Application.ExecutablePath, RegistryValueKind.String);

			if ((key.GetValue(AppStartName) != null) && (!startup))
				key.DeleteValue(AppStartName);

			key.Close();
		}

		#endregion

		#region Event handlers

		private void MainForm_Load(object sender, EventArgs e)
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(StartupRegistry);
			launchStartupCheckbox.Checked = (key.GetValue(AppStartName) != null);
			key.Close();
			warnPendingCheckBox.Checked = global::mxplx.Properties.Settings.Default.WarnPendingAlarmsOnClose;

			if (global::mxplx.Properties.Settings.Default.FirstRun) {
				notifyIcon.ShowBalloonTip(5000);
				global::mxplx.Properties.Settings.Default.FirstRun = false;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing) {
				Hide();
				e.Cancel = true;
			}
			SetStartup(launchStartupCheckbox.Checked);
			global::mxplx.Properties.Settings.Default.WarnPendingAlarmsOnClose = warnPendingCheckBox.Checked;
			global::mxplx.Properties.Settings.Default.Save();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((PendingRemindersCount == 0) || (!warnPendingCheckBox.Checked))
				Application.Exit();

			if (MessageBox.Show(string.Format("You have {0} pending reminders.  Are you sure you wish to exit?", PendingRemindersCount),
				"Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				Application.Exit();
		}

		private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
			Show();
		}

		private void NewReminderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReminderForm reminderForm = new ReminderForm();
			reminderForm.Show();
            reminderForm.BringToFront();
			reminderForm.Focus();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			Hide();
		}

        private void VersionLabel_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://mxplx.com/");
		}

		#endregion
	}
}