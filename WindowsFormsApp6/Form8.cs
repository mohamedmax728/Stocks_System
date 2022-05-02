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
using System.Xml;

namespace WindowsFormsApp6
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        int p = 0;
        private void Form8_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("رقم الاذن.xml");
            XmlNodeList list = doc.GetElementsByTagName("id");
            XmlNodeList child = list[0].ChildNodes;
            string number = child[0].InnerText;
            File.Delete("رقم الاذن.xml");
            doc.Load("debts.xml");
            list = doc.GetElementsByTagName("debt");
            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    child = list[i].ChildNodes;
                    if (number == child[9].InnerText || number == child[10].InnerText || number == child[11].InnerText)
                    {
                        textBox1.Text = child[0].InnerText;
                        textBox2.Text = child[1].InnerText;
                        textBox3.Text = child[3].InnerText;
                        textBox4.Text = child[4].InnerText;
                        textBox5.Text = child[6].InnerText;
                        textBox6.Text = child[5].InnerText;
                        textBox7.Text = child[7].InnerText;
                        textBox8.Text = child[2].InnerText;
                        textBox9.Text = child[10].InnerText;
                        textBox10.Text = child[9].InnerText;
                        textBox11.Text = child[11].InnerText;
                        textBox12.Text = child[8].InnerText;
                        p = i;

                        break;
                    }
                }catch(Exception)
                {
                    continue;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("debts.xml");
            XmlNodeList list = doc.GetElementsByTagName("debt");
            XmlNodeList child = list[p].ChildNodes;
            child[0].InnerText = textBox1.Text;
            child[1].InnerText = textBox2.Text;
            child[3].InnerText = textBox3.Text;
            child[4].InnerText = textBox4.Text;
            child[6].InnerText = textBox5.Text;
            child[5].InnerText = textBox6.Text;
            child[7].InnerText = textBox7.Text;
            child[2].InnerText = textBox8.Text;
            child[10].InnerText = textBox9.Text;
            child[9].InnerText = textBox10.Text;
            child[11].InnerText = textBox11.Text;
            child[8].InnerText = textBox12.Text;
            doc.Save("debts.xml");
            
            MessageBox.Show("تم التعديل بنجاح");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            this.Hide();
            Form7 f = new Form7();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("debts.xml");
            XmlNodeList list = doc.GetElementsByTagName("debt");
            XmlNodeList child = list[p].ChildNodes;

            list[p].RemoveAll();
            doc.Save("debts.xml");
            MessageBox.Show(" تم الحذف بنجاح");
            this.Hide();
            Form7 f = new Form7();
            f.Show();
        }
    }
}
