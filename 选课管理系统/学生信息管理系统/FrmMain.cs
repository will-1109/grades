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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            manaclass MyFrmMain=new manaclass();
            MyFrmMain.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stumana MyFrmMain = new stumana();
            MyFrmMain.Show();
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
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            teachermanage MyFrmMain = new teachermanage();
            MyFrmMain.Show();
        }
    }
}
