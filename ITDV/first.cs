using System;
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
    public partial class first : Form
    {
        public first()
        {
            InitializeComponent();
        }

        private void first_Load(object sender, EventArgs e)
        {
            label1.Text = "首頁";
            this.panel2.Controls.Clear();
            home form = new home();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(46, 51, 73);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label1.Text = "匯入與檢視資料";
            this.panel2.Controls.Clear();
            fuc1 form = new fuc1();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(46, 51, 73);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label1.Text = "圖表";
            this.panel2.Controls.Clear();
            fuc2 form = new fuc2();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(46, 51, 73);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button7.BackColor = Color.FromArgb(24, 30, 54);
            label1.Text = "修改資料";
            this.panel2.Controls.Clear();
            fuc3 form = new fuc3();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(46, 51, 73);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            label1.Text = "工作分配";
            this.panel2.Controls.Clear();
            fuc4 form = new fuc4();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            label1.Text = "Google搜尋";
            this.panel2.Controls.Clear();
            web form = new web();
            form.webBrowser1.Navigate("https://www.google.com/search?q=" + textBox1.Text);
            form.webBrowser1.ScriptErrorsSuppressed = true;
            //web form = new web();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Select(0, textBox1.Text.Length);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(24, 30, 54);
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button5.BackColor = Color.FromArgb(24, 30, 54);
            button3.BackColor = Color.FromArgb(24, 30, 54);
            label1.Text = "首頁";
            this.panel2.Controls.Clear();
            home form = new home();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            form.Show();
        }
    }
}
