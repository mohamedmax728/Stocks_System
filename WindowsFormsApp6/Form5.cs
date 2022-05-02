using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp6
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("debts.xml");
            XmlDocument document = new XmlDocument();
            document.Load("ids.xml");
            XmlNodeList li = doc.GetElementsByTagName("debt");
            XmlNodeList list = document.GetElementsByTagName("iden");

            decimal sertax = 0, commtax = 0;
            decimal balance = 0;
            decimal adebt = 0, sdebt = 0;
            decimal tk = 0;
            decimal totaladebt = 0, totalsdebt = 0, totaltk = 0, totalbalance = 0, totalsertax = 0, totalcommtax = 0;
             for (int i = 0; i < list.Count; i++)
             {
                tk = 0;
                adebt = 0; sdebt = 0;
                XmlNodeList ch = list[i].ChildNodes;
                sertax = 0; commtax = 0; balance = 0;
                for (int j = 0; j < li.Count; j++)
                {

                    try
                    {
                        decimal t = 0, x = 0;
                        XmlNodeList child = li[j].ChildNodes;
                        if (ch[0].InnerText == child[0].InnerText)
                        {
                            balance -= decimal.Parse(child[4].InnerText);
                            balance += decimal.Parse(child[5].InnerText);
                            balance += decimal.Parse(child[6].InnerText);
                            balance += decimal.Parse(child[7].InnerText);
                            balance += decimal.Parse(child[8].InnerText);
                            adebt += decimal.Parse(child[4].InnerText);
                             
                            if (decimal.Parse(child[6].InnerText) > 300)
                            {
                                t = decimal.Parse(child[6].InnerText);
                                t *= 3;
                                t /= 100;
                                
                                sertax += t;
                            }
                            // - (sertax)
                            //(- commtax);
                            if (decimal.Parse(child[7].InnerText) > 300)
                            {
                                x = decimal.Parse(child[7].InnerText);
                                x /= 100;
                                commtax += x;
                            }
                            sdebt += (decimal.Parse(child[6].InnerText));
                            sdebt += (decimal.Parse(child[7].InnerText)); 
                            sdebt += decimal.Parse(child[5].InnerText);
                            sdebt -= t;
                            sdebt -= x;
                            tk += decimal.Parse(child[8].InnerText);
                        }
                    }catch(Exception)
                    {
                        continue;
                    }
                }
                try
                {
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id"  , "id");
                        dataGridView1.Columns.Add("الاسم", "الاسم");
                        dataGridView1.Columns.Add("مدين", "مدين");
                        dataGridView1.Columns.Add("دائن", "دائن");
                        dataGridView1.Columns.Add("اجمالي ضريبة كسب عمل", "اجمالي ضريبة كسب عمل");
                        dataGridView1.Columns.Add("اجمالي ضريبة تجارية", "اجمالي ضريبة تجارية");
                        dataGridView1.Columns.Add("اجمالي ضريبة خدمية" , "اجمالي ضريبة خدمية");
                        dataGridView1.Columns.Add("اجمالي الارصدة", "اجمالي الارصدة");
                    }
                    dataGridView1.Rows.Add(new string[] { ch[0].InnerText,ch[1].InnerText,adebt.ToString(),sdebt.ToString(),
                    tk.ToString(),commtax.ToString(),sertax.ToString(),(balance).ToString()});
                    DataGridViewColumn column = dataGridView1.Columns[1];
                    column.Width = 400;
                    totaladebt += adebt;
                    totalsdebt += sdebt;
                    totaltk += tk;
                    totalcommtax += commtax;
                    totalsertax += sertax;
                    totalbalance += balance;
                }
                catch(Exception)
                {
                    continue;
                }
            }
            dataGridView1.Rows.Add(new string[] { "","اجمالي الفترة",totaladebt.ToString(),totalsdebt.ToString(),
            totaltk.ToString(),totalcommtax.ToString(),totalsertax.ToString(),(totalbalance).ToString()});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
          //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocument1_PrintPage_1;
            pd.Document = doc;
            if(pd.ShowDialog()==DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap map = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(map, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(map, 100, 120);
            //map.Dispose();
        }
    }
}
