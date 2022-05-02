using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("debts.xml"))
            {
                MessageBox.Show("ليست هناك ديون مسجلة");
            }
            else
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!File.Exists("debts.xml"))
            {
                MessageBox.Show("ليست هناك ديون مسجلة");
            }
            else
            {
                this.Hide();
                Form5 f5 = new Form5();
                f5.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!File.Exists("ids.xml"))
            {
                MessageBox.Show("لا يوجد موظفين مسجلين");
            }
            else
            {
                this.Hide();
                Form6 f6 = new Form6();
                f6.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f7 = new Form11();
            f7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!File.Exists("ids.xml"))
            {
                MessageBox.Show("لا يوجد موظفين مسجلين");
            }
            else
            {
                this.Hide();
                Form10 f = new Form10();
                f.Show();

            }
        }
    }
}
