using CefSharp.WinForms;
using NavegaTeus.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NavegaTeus.Views
{
    public partial class FormPage : Form
    {
        public PagesModel Page { get; set; }
        private int secodsToHideBtnRefresh = 5;
        public FormPage(PagesModel page)
        {
            InitializeComponent();
            this.Page = page;
            chromiumWebBrowser.LoadUrlAsync(page.URL);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (Page.AutoUpdate)
            {
                DateTime nextCheck = Page.LastUpdate + Page.UpdateFrequency;
                if (DateTime.Now > nextCheck)
                {
                    chromiumWebBrowser.LoadUrl(Page.URL);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.LoadUrl(Page.URL);
        }

        private void timerBtnRefresh_Tick(object sender, EventArgs e)
        {
            secodsToHideBtnRefresh--;
            if (secodsToHideBtnRefresh == 0)
                btnRefresh.Visible = false;
        }
        public void ShowControls()
        {
            secodsToHideBtnRefresh = 5;
            btnRefresh.Visible = true;
        }
    }
}
