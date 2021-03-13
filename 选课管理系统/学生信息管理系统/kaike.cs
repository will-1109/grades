using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 登录案例
{
    public partial class kaike : Form
    {
        public kaike()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        SqlConnection conn = new SqlConnection(updatepswd.connectionString);
        private void button1_Click(object sender, EventArgs e)
        {
            

          
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
