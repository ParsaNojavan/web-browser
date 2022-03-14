using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        String Url = string.Empty;
        public Form1()
        {
            InitializeComponent();
            Url = "http://www.bing.com";
            myBrowser();
        }
        private void myBrowser()
        {
            if (toolStripComboBox3.Text != "") Url = toolStripComboBox3.Text;
            webBrowser4.Navigate(Url);
            webBrowser4.ProgressChanged += new WebBrowserProgressChangedEventHandler(webpage_ProgressChanged);
            webBrowser4.DocumentTitleChanged += new EventHandler(webpage_DocumentTitleChanged);
            webBrowser4.StatusTextChanged += new EventHandler(webpage_StatusTextChanged);
            webBrowser4.Navigated += new WebBrowserNavigatedEventHandler(webpage_Navigated);
            webBrowser4.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webpage_DocumentCompleted);
        }
        private void webpage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser4.CanGoBack) toolStripButton13.Enabled = true;
            else toolStripButton13.Enabled = false;
            if (webBrowser4.CanGoForward) toolStripButton14.Enabled = true;
            else toolStripButton14.Enabled = false;
            toolStripLabel2.Text = "Done";
        }
        private void webpage_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser4.DocumentTitle.ToString();
        }
        private void webpage_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripLabel2.Text = webBrowser4.StatusText;
        }
        private void webpage_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar2.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar2.Value = ((int)e.CurrentProgress < 0 || (int)e.MaximumProgress < (int)e.CurrentProgress) ? (int)e.MaximumProgress : (int)e.CurrentProgress;
        }
        private void webpage_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripComboBox3.Text = webBrowser4.Url.ToString();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            webBrowser4.GoBack();
        }



        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            webBrowser4.ShowPrintPreviewDialog();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            webBrowser4.GoHome();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            webBrowser4.GoForward();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            webBrowser4.Refresh();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            toolStripComboBox3.Text = webBrowser4.Url.ToString();
        }
    }
}