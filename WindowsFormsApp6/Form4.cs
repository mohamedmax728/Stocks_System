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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            if (id == "" || name == "")
            {
                MessageBox.Show("ادخل البيانات بشكل صحبح");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            { 
                if (!File.Exists("ids.xml"))
                {
                    XmlWriter writer = XmlWriter.Create("ids.xml");
                    writer.WriteStartDocument();
                    writer.WriteStartElement("table");

                    writer.WriteStartElement("iden");

                    writer.WriteStartElement("id");
                    writer.WriteString(id);
                    writer.WriteEndElement();

                    writer.WriteStartElement("name");
                    writer.WriteString(name);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.Close();
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    XmlElement table = doc.CreateElement("iden");

                    XmlElement node = doc.CreateElement("id");
                    node.InnerText = id;
                    table.AppendChild(node);

                    node = doc.CreateElement("name");
                    node.InnerText = name;
                    table.AppendChild(node);

                    doc.Load("ids.xml");
                    XmlElement root = doc.DocumentElement;
                    root.AppendChild(table);
                    doc.Save("ids.xml");
                }
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("added susccessfully!!!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

            private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
