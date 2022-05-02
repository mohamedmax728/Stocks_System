using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp6
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("debts.xml");
            XmlNodeList list = doc.GetElementsByTagName("debt");
            bool Z = false;
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;
                if (textBox1.Text == child[9].InnerText || textBox1.Text == child[10].InnerText || textBox1.Text == child[11].InnerText)
                {
                    Z = true;
                    break;
                }

            }
            if(Z)
            {
                XmlWriter writer = XmlWriter.Create("رقم الاذن.xml");
                writer.WriteStartDocument();
                writer.WriteStartElement("table");
                writer.WriteStartElement("iden");
                writer.WriteStartElement("id");
                writer.WriteString(textBox1.Text);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Close();
                this.Hide();
                Form8 f8 = new Form8();
                f8.Show();
            }
            else
            {
                MessageBox.Show("رقم الاذن غير مسجل");
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

        }

        private void Form7_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
