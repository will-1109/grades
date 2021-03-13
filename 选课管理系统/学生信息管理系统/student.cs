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
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatepswd f3 = new updatepswd();
            f3.TopLevel = false;
            f3.FormBorderStyle = FormBorderStyle.None;
            f3.WindowState = FormWindowState.Maximized;
            panel1.Controls.Add(f3);
            f3.Show();
        }

        private void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void 退出系统ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            selectgrades MyFrmMain = new selectgrades();
            MyFrmMain.Show();
        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select f2 = new select();
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            f2.WindowState = FormWindowState.Maximized;
            panel1.Controls.Add(f2);
            f2.Show();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showcourse f1 = new showcourse();
            f1.TopLevel = false;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.WindowState = FormWindowState.Maximized;
            panel1.Controls.Add(f1);
            f1.Show();
        }

        private void 退出系统ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        private void 退出系统ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
