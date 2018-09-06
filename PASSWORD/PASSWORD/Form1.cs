using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PASSWORD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public string uspa;
        public string[] degerler;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection bag = new OleDbConnection
                ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=userpass.accdb");
                OleDbDataAdapter kur = new OleDbDataAdapter
                ("select user,pass from up where user='" + textBox1.Text + "' or pass='" + textBox2.Text + "'", bag);
                DataSet hamal = new DataSet();
                kur.Fill(hamal);
                uspa = hamal.Tables[0].Rows[0].ItemArray[0].ToString() + " " + hamal.Tables[0].Rows[0].ItemArray[1].ToString();
                degerler = uspa.Split(' ');

                if (textBox1.Text + " " + textBox2.Text == "admin" + " " + "admin")
                {
                    MessageBox.Show("Marabaların Yolunu Gözler Adminim Rootum");
                    Form3 frm3 = new Form3();
                    frm3.Show();
                    this.Hide();
                }
                else if (textBox1.Text + " " + textBox2.Text == uspa)
                {
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                    frm2.label1.Text = "Merhaba Veritabanımdaki Tablomdaki Kullanıcı" + " " + degerler[0].ToString();
                }
                else if (degerler[0].ToString() != textBox1.Text)
                {
                    this.BackColor = Color.Red;
                    MessageBox.Show("Kullanıcı Adı HATALI");
                    textBox1.Clear();
                }
                else if (degerler[1].ToString() != textBox2.Text)
                {
                    this.BackColor = Color.Red;
                    MessageBox.Show("Parola HATALI");
                    textBox2.Clear();
                }
                
            }
            catch (Exception)
            {
                if (uspa == null)
                {
                    MessageBox.Show("Kullanıcı Adı veya Parola HATALI");
                    textBox1.Clear();
                    textBox2.Clear();
                }

            }

        }
    }
}
