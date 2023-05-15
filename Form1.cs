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
        MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=resturant_database; Uid=root; Pwd=ali1234");
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
                gonderci = "ID,tarih, Harc";
            else if (radioButton3.Checked)
                gonderci = "ID,tarih, Satin";
            else if (radioButton4.Checked)
                gonderci = "ID,tarih, Kazanc";
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
            try
            {
                tunel.Open();
                int id = int.Parse(textBox8.Text);
                string tarih = (textBox1.Text);
                int harc = int.Parse(textBox2.Text);
                int satis = int.Parse(textBox3.Text);
                int kazanc = satis - harc;

                DateTime time = DateTime.Now;
                string format = "yyyy-M-d";
  

                if (checkBox1.Checked == true)
                    tarih = time.ToString(format);
                MySqlCommand cmd = new MySqlCommand
                    ("INSERT INTO hesaplar(ID,Tarih, Harc,Satin,Kazanc)" +
                    "VALUES("+id+", '"+tarih.ToString()+"', '"+harc+"', '"+satis+"', '"+kazanc+"'); ",tunel);

                cmd.ExecuteNonQuery();
                tunel.Close();
                listele("Temel");
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            
        }
        private void listele(params string[] prm)
        {
            string sql = "";
            if (prm[0] == "Temel")
                sql = "select * from hesaplar";
            if(prm[0] == "Hafta")
            {
                string suan = "";
                DateTime time = DateTime.Now;
                string format = "yyyy-M-d'"+(-7)+"'";
                suan = time.ToString(format);

                string limit = "";
                DateTime time2 = DateTime.Now;
                string format2 = "yyyy-M-d'" + (-14) + "'";
                suan = time.ToString(format);

                MessageBox.Show(limit.ToString());
                sql = "select * from hesaplar where Tarih BETWEEN'"+ limit + "' and '"+suan+"'";
            }
            if (prm[0] == "Ay")
            {
                string suan = "";
                DateTime time = DateTime.Now;
                string format = "yyyy-'"+(-1)+"'-d";
                suan = time.ToString(format);
                MessageBox.Show(suan.ToString());
                sql = "select * from hesaplar where tarih < '" + suan + "'";
            }
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
                int kazanc = int.Parse(textBox4.Text) - int.Parse(textBox5.Text); 
                //string sql = "UPDATE hesaplar SET Harc='"+textBox5.Text+"', Satin='"+textBox4.Text+"' where ID='"+textBox6+"'";
                string sql = "UPDATE hesaplar SET Harc='"+textBox5.Text+"', Satin='"+textBox4.Text+"', Kazanc='"+kazanc+"' where ID = '"+textBox6.Text+"'";
                MySqlDataAdapter adp = new MySqlDataAdapter(sql, tunel);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                tunel.Close();
                listele("Temel");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                listele("Hafta");
            }
            else if (radioButton6.Checked)
            {
                listele("Ay");
            }
            else if (radioButton5.Checked)
            {
                listele("Yil");
            }
        }
    }
}
