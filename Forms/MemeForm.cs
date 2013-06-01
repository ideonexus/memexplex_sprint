using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mxplx.Forms
{
    public partial class MemeForm : Form
    {
        public string memeLink;
        public MemeForm()
        {
            InitializeComponent();
        }

        private void MemeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(memeLink);
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void memeQuote_Click(object sender, EventArgs e)
        {

        }
    }
}
