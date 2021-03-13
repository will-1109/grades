using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 登录案例
{
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatepswd f3 = new updatepswd();
            f3.TopLevel = false;
            f3.FormBorderStyle = FormBorderStyle.None;
            f3.WindowState = FormWindowState.Maximized;
            panel1.Controls.Add(f3);
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            teschernewclass f4 = new teschernewclass();
            f4.TopLevel = false;
            f4.FormBorderStyle = FormBorderStyle.None;
            f4.WindowState = FormWindowState.Maximized;

            panel1.Controls.Add(f4);
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tmanas MyFrmMain = new tmanas();
            MyFrmMain.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mywork f5 = new mywork();
            f5.TopLevel = false;
            f5.FormBorderStyle = FormBorderStyle.None;
            f5.WindowState = FormWindowState.Maximized;

            panel1.Controls.Add(f5);
            f5.Show();
        }
    }
}
