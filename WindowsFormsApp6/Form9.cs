using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="mohamed"&&textBox2.Text=="5871")
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
            else
            {

                MessageBox.Show("username or password is invalid!!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
