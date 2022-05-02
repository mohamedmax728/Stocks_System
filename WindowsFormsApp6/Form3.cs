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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string name = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" && textBox6.Text == "" && textBox8.Text == "")
            {
                MessageBox.Show("عدم اكمال البيانات");
            }
            else if (textBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("عدم اكمال البيانات");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("الرجاء الضغط على زر اظهار الاسم");
            }
            else
            {
                string dat = textBox1.Text;

                string stat = textBox2.Text;
                string adebt = textBox3.Text;
                string sdebt = textBox4.Text;
                string gdebt = textBox9.Text;
                string tax = textBox12.Text;
                string id = textBox5.Text;
                string pernumber = textBox6.Text;
                textBox7.Enabled = false;

                string treanum = textBox8.Text;
                string addnum = textBox10.Text;
                string hdebt = textBox11.Text;
                if (!File.Exists("debts.xml"))
                {
                    XmlWriter writer = XmlWriter.Create("debts.xml");
                    writer.WriteStartDocument();
                    writer.WriteStartElement("table");

                    writer.WriteStartElement("debt");
                    writer.WriteStartElement("id");
                    writer.WriteString(id);
                    writer.WriteEndElement();

                    writer.WriteStartElement("name");
                    writer.WriteString(name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("date");
                    writer.WriteString(dat);
                    writer.WriteEndElement();

                    writer.WriteStartElement("stat");
                    writer.WriteString(stat);
                    writer.WriteEndElement();

                    writer.WriteStartElement("adebt");
                    if (adebt == "") adebt = 0.ToString();
                    writer.WriteString(adebt);
                    writer.WriteEndElement();

                    writer.WriteStartElement("hdebt");
                    if (hdebt == "") hdebt = 0.ToString();
                    writer.WriteString(hdebt);
                    writer.WriteEndElement();


                    writer.WriteStartElement("sdebt");
                    if (sdebt == "") sdebt = 0.ToString();

                    writer.WriteString(sdebt.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("gdebt");
                    if (gdebt == "") gdebt = 0.ToString();

                    writer.WriteString(gdebt);
                    writer.WriteEndElement();

                    writer.WriteStartElement("worktax");
                    if (tax == "") tax = 0.ToString();
                    writer.WriteString(tax);
                    writer.WriteEndElement();

                    writer.WriteStartElement("pernumber");
                    if (pernumber == "") pernumber = 0.ToString();
                    writer.WriteString(pernumber);
                    writer.WriteEndElement();

                    writer.WriteStartElement("addnum");
                    if (addnum == "") addnum = 0.ToString();
                    writer.WriteString(addnum);
                    writer.WriteEndElement();

                    writer.WriteStartElement("treanum");
                    if (treanum == "") treanum = 0.ToString();
                    writer.WriteString(treanum);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.Close();
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    XmlElement table = doc.CreateElement("debt");

                    XmlElement node = doc.CreateElement("id");
                    node.InnerText = id;
                    table.AppendChild(node);

                    node = doc.CreateElement("name");
                    node.InnerText = name;
                    table.AppendChild(node);

                    node = doc.CreateElement("date");
                    node.InnerText = dat;
                    table.AppendChild(node);

                    node = doc.CreateElement("stat");
                    node.InnerText = stat;
                    table.AppendChild(node);

                    node = doc.CreateElement("adebt");//مدين
                    if (adebt == "") adebt = 0.ToString();
                    node.InnerText = adebt;
                    table.AppendChild(node);

                    node = doc.CreateElement("hdebt");//دائن عاملين
                    if (hdebt == "") hdebt = 0.ToString();
                    node.InnerText = hdebt;
                    table.AppendChild(node);


                    node = doc.CreateElement("sdebt");//دائن خدمي
                    if (sdebt == "") sdebt = 0.ToString();
                    node.InnerText = sdebt.ToString();
                    table.AppendChild(node);

                    node = doc.CreateElement("gdebt");//دائن تجاري
                    if (gdebt == "") gdebt = 0.ToString();
                    node.InnerText = gdebt.ToString();
                    table.AppendChild(node);

                    node = doc.CreateElement("worktax");//ضريبة كسب عمل
                    if (tax == "") tax = 0.ToString();
                    node.InnerText = tax.ToString();
                    table.AppendChild(node);


                    node = doc.CreateElement("pernumber");
                    if (pernumber == "") pernumber = 0.ToString();
                    node.InnerText = pernumber;
                    table.AppendChild(node);

                    node = doc.CreateElement("addnum");
                    if (addnum == "") addnum = 0.ToString();
                    node.InnerText = addnum;
                    table.AppendChild(node);


                    node = doc.CreateElement("treanum");
                    if (treanum == "") treanum = 0.ToString();
                    node.InnerText = treanum;
                    table.AppendChild(node);







                    doc.Load("debts.xml");
                    XmlElement root = doc.DocumentElement;
                    root.AppendChild(table);
                    doc.Save("debts.xml");

                }
                MessageBox.Show("added successfully!");
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
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ids.xml");
            XmlNodeList list = doc.GetElementsByTagName("iden");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;
                try
                {
                    if (textBox5.Text == child[0].InnerText)
                    {
                        textBox7.Text = child[1].InnerText;
                        name = textBox7.Text;
                        break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox7.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ids.xml");
            bool z = false;
            XmlNodeList list = doc.GetElementsByTagName("iden");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList child = list[i].ChildNodes;
                try
                {
                    if (textBox5.Text == child[0].InnerText)
                    {
                        z = true;
                        textBox7.Text = child[1].InnerText;
                        name = textBox7.Text;
                        break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if(!z)
            {
                MessageBox.Show("غير مسجل");
                textBox5.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
