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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox1.Hide();
            textBox2.Hide();
            label1.Hide();
            label2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();

        }
        int p;
        private void button1_Click(object sender, EventArgs e)
        {
            bool z = false;
                
                XmlDocument doc = new XmlDocument();
                doc.Load("ids.xml");
                XmlNodeList list = doc.GetElementsByTagName("iden");
                for (int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        XmlNodeList ch = list[i].ChildNodes;
                        if (ch[0].InnerText == textBox1.Text)
                        {
                            textBox2.Text = ch[1].InnerText;
                            p = i;
                            z = true;
                            break;
                        }
                    }catch(Exception)
                    {
                        continue;
                    }
                }
            if(z==false)
            {
                MessageBox.Show("هذا الموظف غير موجود");
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( textBox1.Text == "")
            {
                MessageBox.Show("اكتب رقم الموظف ");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("اضغظ على زر اظهار الاسم ");
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ids.xml");
                XmlNodeList list = doc.GetElementsByTagName("iden");
                XmlNodeList child = list[p].ChildNodes;
                list[p].RemoveAll();
                doc.Save("ids.xml");
                 doc = new XmlDocument();
                XmlElement table = doc.CreateElement("iden");

                XmlElement node = doc.CreateElement("id");
                node.InnerText = textBox1.Text;
                table.AppendChild(node);

                node = doc.CreateElement("name");
                node.InnerText = textBox2.Text;
                table.AppendChild(node);

                doc.Load("ids.xml");
                XmlElement root = doc.DocumentElement;
                root.AppendChild(table);
                doc.Save("ids.xml");

               

                MessageBox.Show("تم التعديل بنجاح");
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("اكتب رقم الموظف ");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("اضغظ على زر اظهار الاسم ");
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ids.xml");
                XmlNodeList list = doc.GetElementsByTagName("iden");
                XmlNodeList child = list[p].ChildNodes;
                list[p].RemoveAll();
                doc.Save("ids.xml");

               
                doc = new XmlDocument();
                doc.Load("debts.xml");
                list = doc.GetElementsByTagName("debt");
                for (int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        child = list[i].ChildNodes;
                        if (textBox1.Text == child[0].InnerText && textBox2.Text == child[1].InnerText)
                        {
                            list[i].RemoveAll();

                        }
                    }catch(Exception)
                    {
                        continue;
                    }
                }
                doc.Save("debts.xml");


                MessageBox.Show("تم الحذف بنجاح");
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox3.Text=="mo5871d")
            {
                textBox1.Show();
                textBox2.Show();
                label1.Show();
                label2.Show();
                button1.Show();
                button2.Show();
                button3.Show();
                label3.Hide();
                textBox3.Hide();
                button5.Hide();
            }
            else
            {
                MessageBox.Show("password is invalid!!!");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
