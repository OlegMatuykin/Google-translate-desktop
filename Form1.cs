using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Google_translate_desktop
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser browser;

        private void OnBrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            if (args.Frame.IsMain)
            {
                args
                    .Browser
                    .MainFrame
                    .ExecuteJavaScriptAsync(
                    "document.documentElement.style.overflowY = 'hidden';");
            }
        }

        public void InitBrowser()
        {
            var newsettings = new BrowserSettings();
            var settings = new CefSettings();

            this.Text = "Google Translate";
            settings.CachePath = System.IO.Path.GetTempPath() + "\\googleTranslate";
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("https://translate.google.com/");

            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.FrameLoadEnd += OnBrowserFrameLoadEnd;
        }

        public Form1()
        {
            InitializeComponent();
            InitBrowser();
            this.Icon = Properties.Resources.Google_Translate_Icon;
        }
    }
}
