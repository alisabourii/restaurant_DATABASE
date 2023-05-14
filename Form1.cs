using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Hesaplar_VT
{
    public partial class Form1 : Form
    {
        MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=simindokht_ctg; Uid=root; Pwd=ali1234");
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string gonderci = "";
            if (radioButton1.Checked)
                gonderci = "*";
            else if (radioButton2.Checked)
                gonderci = "tarih, Harc";
            else if (radioButton3.Checked)
                gonderci = "tarih, Satin";
            else if (radioButton4.Checked)
                gonderci = "tarih, Kazanc";
            goster(gonderci);
        }
        private void goster(string gst)
        {
            try
            {
                tunel.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select " + gst + " From hesaplar", tunel);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                tunel.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tunel.Open();
            int kazanc =   int.Parse(textBox3.Text) - int.Parse(textBox2.Text);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO hesaplar(Tarih, Harc,Satin,Kazanc) VALUES('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+kazanc+"')", tunel);
            cmd.ExecuteNonQuery();
            listele("Temel");
            tunel.Close();
            
        }
        private void listele(params string[] prm)
        {
            string sql = "";
            if (prm[0] == "Temel")
                sql = "select * from ogrenciler";
            
            
            try
            {
                tunel.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(sql, tunel);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                tunel.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                tunel.Open();
                string sql = "UPDATE hesaplar SET Harc='"+textBox5.Text+"', Satin='"+textBox4.Text+"' where Tarih='"+textBox6+"'";
                MySqlDataAdapter adp = new MySqlDataAdapter(sql, tunel);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                tunel.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
