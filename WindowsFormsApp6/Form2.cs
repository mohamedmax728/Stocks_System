using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label4.Hide();
            label5.Hide();
            textBox2.Hide();
            dataGridView1.Hide();
            label3.Hide();
            textBox4.Hide();
            textBox3.Hide();
            textBox4.Enabled = false;
            textBox3.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("debts.xml");
            XmlNodeList list = doc.GetElementsByTagName("debt");
            bool z = false;
            decimal sertax = 0,commtax=0;
            decimal balance = 0,debtor=0,creditor=0;
            decimal sercred = 0, commcred = 0,tm=0,td=0,tk=0,tt=0,tkhd=0;
            int p = 0;
            for (int i = 0; i < list.Count; i++)
            {
                
                XmlNodeList child = list[i].ChildNodes;
                try
                {
                    sertax = 0; commtax = 0;
                    sercred = 0; commcred = 0; debtor = 0; creditor = 0;
                    if (textBox1.Text == child[0].InnerText)
                    {
                        z = true;
                        textBox2.Text = child[1].InnerText;
                        if (dataGridView1.ColumnCount == 0)
                        {
                            dataGridView1.Columns.Add("مسلسل", "مسلسل");
                            dataGridView1.Columns.Add("التاريخ", "التاريخ");
                            dataGridView1.Columns.Add("بيان", "بيان");
                            dataGridView1.Columns.Add("مدين", "مدين");
                            dataGridView1.Columns.Add("دائن", "دائن");
                            dataGridView1.Columns.Add("ضريبة كسب عمل", "ضريبة كسب عمل");
                            dataGridView1.Columns.Add("ضريبة تجارية", "ضريبة تجارية");

                            dataGridView1.Columns.Add("ضريبة خدمية", "ضريبة خدمية");

                            dataGridView1.Columns.Add("رصيد", "رصيد");
                            dataGridView1.Columns.Add("رقم اذن صرف", "رقم اذن صرف");
                            dataGridView1.Columns.Add("رقم اضافة", "رقم اضافة");
                            dataGridView1.Columns.Add("رقم اذن توريد", "رقم اذن توريد");
                        }
                        if (child[5].InnerText == "") child[5].InnerText = 0.ToString();
                        if (child[4].InnerText == "") child[4].InnerText = 0.ToString();
                        if (child[6].InnerText == "") child[6].InnerText = 0.ToString();
                        if (child[7].InnerText == "") child[7].InnerText = 0.ToString();
                        if (child[8].InnerText == "") child[8].InnerText = 0.ToString();

                        balance -= decimal.Parse(child[4].InnerText);
                        

                        debtor = decimal.Parse(child[4].InnerText);
                        balance += decimal.Parse(child[5].InnerText);
                        balance += decimal.Parse(child[8].InnerText);
                        sercred = decimal.Parse(child[6].InnerText);

                        commcred = decimal.Parse(child[7].InnerText);

                        if (sercred > 300)
                        {
                            sertax = sercred;
                            sertax *= 3;
                            sertax /= 100;
                            sercred = sercred - sertax;
                        }
                        if (commcred > 300)
                        {
                            commtax = commcred / 100;
                            commcred = commcred - commtax;
                        }
                        creditor = sercred + commcred + decimal.Parse(child[5].InnerText);
                        tm += decimal.Parse(child[4].InnerText);
                        td += creditor;
                        tk += decimal.Parse(child[8].InnerText);
                        tt += commtax;
                        tkhd += sertax;

                        balance += sercred + commcred + sertax + commtax;
                        dataGridView1.Rows.Add(new string[] { (++p).ToString(),child[2].InnerText,child[3].InnerText,
                        child[4].InnerText,creditor.ToString(),child[8].InnerText ,commtax.ToString(),sertax.ToString(),balance.ToString()
                        ,child[9].InnerText,child[10].InnerText,child[11].InnerText});
                        DataGridViewColumn column = dataGridView1.Columns[2];
                        column.Width = 250;
                         column = dataGridView1.Columns[0];
                        column.Width = 50;
                    }
                }catch(Exception)
                {
                    continue;
                }
            }
            if (z == false)
                MessageBox.Show("id is not found","warning");
            else
            {
                label2.Show();
                textBox2.Show();
                dataGridView1.Show();
                dataGridView1.Enabled = false;
                label3.Show();
                label4.Show();
                label5.Show();
                textBox4.Show();
                textBox3.Show();
                textBox2.Enabled = false;
                textBox4.Text = (tt+tkhd).ToString();
                textBox3.Text = tk.ToString();
                dataGridView1.Rows.Add(new string[] {"","","اجمالي الفترة",tm.ToString(),td.ToString()
                    ,tk.ToString(),tt.ToString(),tkhd.ToString(),(-tm+td+tk+tt+tkhd).ToString(),"","","" });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.Document = printDocument1;

            //printPreviewDialog1.ShowDialog();
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocument1_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
            /*  PrintDialog p = new PrintDialog();
              p.Document = printDocument1;
              DialogResult r = p.ShowDialog();*/
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap map = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(map, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            //map.RotateFlip(RotateFlipType.Rotate90FlipXY);
            e.Graphics.DrawImage(map, 90, 50);
            // printDocument1.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", this.dataGridView1.Width
            //    , this.dataGridView1.Height);
            //printDocument1.DefaultPageSettings.PaperSize.Kind = 100;
            map.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
