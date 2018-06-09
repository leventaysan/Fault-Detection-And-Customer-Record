using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace YalçınTeknik
{
    public partial class Form3 : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=son.accdb;Persist Security Info=True");
            da = new OleDbDataAdapter("Select *from müsteri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "müsteri");
            dataGridView1.DataSource = ds.Tables["müsteri"];
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sonDataSet.müsteri' table. You can move, or remove it, as needed.
            this.müsteriTableAdapter.Fill(this.sonDataSet.müsteri);
            griddoldur();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into müsteri (Musteri_no,Adı_Soyadı,Telefon,Adres,Arıza,Tarih) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
            else
            {
                MessageBox.Show("Alanları Doldurun!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı Silmek İstediğinizden Emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//uyarı mesajı verildi.
            if (cevap == DialogResult.Yes)
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from müsteri where Musteri_no=" + textBox2.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update müsteri set Adı_Soyadı='" + textBox3.Text + "',Telefon='" + textBox4.Text + "',Adres='" + textBox5.Text + "',Arıza='" + textBox6.Text + "',Tarih='" + textBox7.Text + "' where Musteri_no=" + textBox2.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
                MessageBox.Show("Güncelleme Başarılı");
            }
            else
            {
                MessageBox.Show("Güncelleme yapılamadı!!");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=son.accdb;Persist Security Info=True");
            da = new OleDbDataAdapter("Select *from müsteri where Adı_Soyadı like '" + textBox1.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "müsteri");
            dataGridView1.DataSource = ds.Tables["müsteri"];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
