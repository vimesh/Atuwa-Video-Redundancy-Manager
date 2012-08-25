using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace atuwa
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        //this.Browser.DocumentTitleChanged += Browser_DocumentTitleChanged;
        private void Browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Uri url = ((WebBrowser)sender).Document.Url;
            labelAbout.Text = url.ToString();
        }

        private void linkLabelWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             System.Diagnostics.Process.Start("http://atuwa.orgfree.com/");
        }
    }
}
