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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
       
        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("ids.xml");
            XmlNodeList list = doc.GetElementsByTagName("iden");
            for(int i=0;i<list.Count;i++)
            {
                try
                {
                    XmlNodeList ch = list[i].ChildNodes;

                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", "id");
                        dataGridView1.Columns.Add("name", "name");

                    }
                    dataGridView1.Rows.Add(new string[] { ch[0].InnerText, ch[1].InnerText });
                }catch(Exception)
                {
                    continue;
                }
            }
            DataGridViewColumn column = dataGridView1.Columns[1];
            column.Width = 250;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap map = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(map, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(map,100,90);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
