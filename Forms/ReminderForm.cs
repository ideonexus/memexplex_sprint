using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Media;
using System.Resources;
using System.Diagnostics;
using System.Xml;
using System.Text.RegularExpressions;
using mxplx.Forms;

namespace mxplx
{
	public partial class ReminderForm : Form
	{
		#region Constants & enumerations

		public enum AlarmStates { Pending, Alarming, Off }
		private int alarmAnimationFrame = 0;

		#endregion

		#region Instance variables

		private AlarmStates alarmState;
		private Reminder reminder;

		#endregion

		#region Construction

		public ReminderForm()
		{
			InitializeComponent();
			Icon = global::mxplx.Properties.Resources.Reminder;
			AlarmState = AlarmStates.Off;
		}

		#endregion

		#region Properties

		public AlarmStates AlarmState
		{
			get { return alarmState; }
			set {
				alarmState = value;
				switch (alarmState) {
					case AlarmStates.Alarming: {
						timer.Interval = 250;
						timer.Enabled = true;

                        //Get a Random Meme Id
                        Random random = new Random();
                        System.Net.WebClient client = new System.Net.WebClient();
                        //Get Max Number of Memes from Mxplx.com
                        int memeCount = Convert.ToInt32(client.DownloadString(new Uri("http://mxplx.com/api/meme.count")));
                        int randomNumber = random.Next(0, memeCount);
                        string memUrl = String.Format("http://mxplx.com/api/meme/{0}.xml", randomNumber);
                        //HREF Link to Mxplx Meme Page.
                        string mxplxurl = String.Format("http://mxplx.com/Meme/{0}/", randomNumber);
                        //Get the Meme Xml from mxplx API
                        string memeXml = client.DownloadString(new Uri(memUrl));
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.LoadXml(memeXml);
                        
                        //Old Method of Loading Meme Page in Internet Explorer
                        //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        //proc.EnableRaisingEvents=false;
                        //proc.StartInfo.FileName="iexplore";
                        //proc.StartInfo.Arguments = url;
                        //proc.WaitForExit();

                        //Method for Loading Meme Page in Default Browser.
                        //Process p = Process.Start(url);
                        
                        //Open Meme Form and Propagate with Meme Details.
                        MemeForm memeForm = new MemeForm { Text = String.Format("Meme {0}", randomNumber) };
                        memeForm.memeTitle.Text = Regex.Replace(xmldoc.SelectSingleNode("//results/result/title").InnerText, @"<[^>]*>", String.Empty).Replace("/", "");
                        memeForm.memeText.Text = Regex.Replace(xmldoc.SelectSingleNode("//results/result/text").InnerText, @"<[^>]*>", String.Empty).Replace("/", "");
                        memeForm.memeQuote.Text = Regex.Replace(xmldoc.SelectSingleNode("//results/result/quote").InnerText, @"<[^>]*>", String.Empty).Replace("/","");
                        memeForm.memeLink = mxplxurl;
                        memeForm.MemeLinkLabel.Text = mxplxurl;
                        
                        //Play Tibetan Bowl Gong
                        SoundPlayer simpleSound = new SoundPlayer(global::mxplx.Properties.Resources.TibetanBowlHit);
                        simpleSound.Play();

                        //Show Tooltip Icon
                        notifyIcon.ShowBalloonTip(60 * 60 * 1000, reminder.NextOccurance.ToString(), reminder.Name, ToolTipIcon.None);

                        memeForm.ShowDialog();

                        //Automatically Generate New Reminder
                        ReminderForm reminderForm = new ReminderForm { AlarmState = AlarmStates.Pending, reminder = reminder.Clone() };
                        reminderForm.reminder.Time = new TimeSpan(0, (int) inMinutesNud.Value, 0);
                        reminderForm.reminder.Active = true;
                        reminderForm.notifyIcon.Text = string.Format("{0} at {1}", reminderForm.reminder.Name, reminderForm.reminder.NextOccurance);

						break;
					}
					case AlarmStates.Pending: {
						Icon = global::mxplx.Properties.Resources.Reminder;
						timer.Interval = 1000;
						timer.Enabled = true;
						break;
					}
					case AlarmStates.Off: {
						Icon = global::mxplx.Properties.Resources.Reminder;
						timer.Enabled = false;
						if (reminder != null)
							reminder.Active = false;
						break;
					}
				}
			}
		}

		#endregion

		#region Event handlers
        
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);

			if (reminder != null)
				ReminderToUserInterface();

			nameCombo.Items.Clear();
			foreach (Reminder availableReminder in MainForm.AllReminders)
				nameCombo.Items.Add(availableReminder);
			nameCombo.SelectedItem = reminder;

			ReflectInterface(this, e);
		}

		private void ReflectInterface(object sender, EventArgs e)
		{
			atTimePicker.Visible = atRadio.Checked;
			inMinutesNud.Visible = inRadio.Checked;
			minutesLabel.Visible = inRadio.Checked;
		}

		private void NotifyIcon_Click(object sender, EventArgs e)
		{
			Show();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if ((alarmState == AlarmStates.Pending) && (DateTime.Now >= reminder.NextOccurance))
				AlarmState = AlarmStates.Alarming;

			if (alarmState == AlarmStates.Alarming) {
				switch (alarmAnimationFrame++) {
					case 0: {
							notifyIcon.Icon = global::mxplx.Properties.Resources.Alarm1;
							break;
						}
					case 1: {
							notifyIcon.Icon = global::mxplx.Properties.Resources.Reminder;
							break;
						}
					case 2: {
							notifyIcon.Icon = global::mxplx.Properties.Resources.Alarm2;
							alarmAnimationFrame = 0;
							break;
						}
				}
			}
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			AlarmState = AlarmStates.Off;
			Close();
		}

		private void SetButton_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(nameCombo.Text)) {
				MessageBox.Show("Name can not be blank");
				return;
			}

			if (reminder == null) {
				reminder = new Reminder();
				MainForm.AllReminders.Add(reminder);
			}

			reminder.Name = nameCombo.Text;
			reminder.ReminderType = (atRadio.Checked) ? ReminderTypes.Time : ReminderTypes.Interval;
			reminder.Time = (reminder.ReminderType == ReminderTypes.Time) ? TimeSpan.Parse(atTimePicker.Text) : new TimeSpan(0, (int) inMinutesNud.Value, 0);

			notifyIcon.Text = string.Format("{0} at {1}", reminder.Name, reminder.NextOccurance);
			timer.Enabled = true;

			AlarmState = AlarmStates.Pending;

			Hide();
		}

		private void NameCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (nameCombo.SelectedItem != null) {
				Reminder potentialReminder = nameCombo.SelectedItem as Reminder;
				if (potentialReminder.Active) {
					reminder = potentialReminder.Clone();
					
					MainForm.AllReminders.Add(reminder);
				}
				else
					reminder = potentialReminder;

				ReminderToUserInterface();
			}
		}

		private void ReminderToUserInterface()
		{
			nameCombo.Text = reminder.Name;
			atRadio.Checked = (reminder.ReminderType == ReminderTypes.Time);
			inRadio.Checked = (reminder.ReminderType == ReminderTypes.Interval);
			atTimePicker.Value = (reminder.ReminderType == ReminderTypes.Time) ? reminder.NextOccurance : DateTime.Now;
			inMinutesNud.Value = (reminder.ReminderType == ReminderTypes.Interval) ? reminder.Time.Minutes : 0;
		}

		private void HideButton_Click(object sender, EventArgs e)
		{
			Hide();
		}

		#endregion
	}
}