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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private int mnouret()
        {
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=userpass.accdb");
            bag.Open();

            OleDbDataAdapter kur = new OleDbDataAdapter("select max(mno) from up", bag);

            DataSet hamal = new DataSet();
            kur.Fill(hamal);


            return int.Parse(hamal.Tables[0].Rows[0].ItemArray[0].ToString());


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=userpass.accdb");
            bag.Open();

            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;

            komut.CommandText = "insert into up(user,pass,ad soyad,dogum tarihi,mno) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "'," + (mnouret() + 1) + ")";
            komut.ExecuteNonQuery();

            bag.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Refresh();
            groupBox1.Visible = false;
        }
    }
}
