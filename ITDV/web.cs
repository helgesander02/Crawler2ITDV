﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalhw
{
    public partial class web : Form
    {
        public web()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void web_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://www.google.com/");
            //webBrowser1.ScriptErrorsSuppressed = true;
        }
    }
}
