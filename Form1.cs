using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MarketApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            string txt = Convert.ToString(FiyatBulma.fiyatBul(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12,checkBox13, numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12,numericUpDown13)) + "TL";
            label3.Text = txt;
            
            List<CheckBox> list = new List<CheckBox>() { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox13 };
            for(int i = 0; i < 12; i++) {
                list[i].Checked = false;
            }
            List<NumericUpDown> listNum = new List<NumericUpDown>() { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12, numericUpDown13 };
            for (int i = 0; i < 12; i++)
            {
                listNum[i].Value = 0;
            }
        }

        private void showPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown1.Value != 0) { checkBox1.Checked = true; } else { checkBox1.Checked = false; } }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown2.Value != 0) { checkBox2.Checked = true; } else { checkBox2.Checked = false; }}
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown3.Value != 0) { checkBox3.Checked = true; } else { checkBox3.Checked = false; } }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown4.Value != 0) { checkBox4.Checked = true; } else { checkBox4.Checked = false; }}
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown5.Value != 0) { checkBox5.Checked = true; } else { checkBox5.Checked = false; }}
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        { if (numericUpDown6.Value != 0) { checkBox6.Checked = true; } else { checkBox6.Checked = false; } }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown7.Value != 0) { checkBox7.Checked = true; } else { checkBox7.Checked = false; }}
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown8.Value != 0) { checkBox8.Checked = true; } else { checkBox8.Checked = false; }}
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {if(numericUpDown10.Value != 0) { checkBox10.Checked = true; } else { checkBox10.Checked = false; }}
        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown11.Value != 0) { checkBox11.Checked = true; } else { checkBox11.Checked = false; }}
        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown12.Value != 0) { checkBox12.Checked = true; } else { checkBox12.Checked = false; }}
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {if(numericUpDown9.Value != 0) { checkBox9.Checked = true; } else { checkBox9.Checked = false; } }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown13.Value != 0) { checkBox13.Checked = true; } else { checkBox13.Checked = false; }
        }

        
    }
}
class FiyatBulma
{
    public String urn = "";
    public static decimal fiyatBul(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7, CheckBox cb8, CheckBox cb9, CheckBox cb10, CheckBox cb11, CheckBox cb12, CheckBox cb13, NumericUpDown nu1, NumericUpDown nu2, NumericUpDown nu3, NumericUpDown nu4, NumericUpDown nu5, NumericUpDown nu6, NumericUpDown nu7, NumericUpDown nu8, NumericUpDown nu9, NumericUpDown nu10, NumericUpDown nu11, NumericUpDown nu12, NumericUpDown nu13)
    {

        //---------------İçecekler Fiayti Testi----------- 
        int TKahveF = 30;
        int SpersoF = 45;
        int LatteF = 55;
        int CapichoF = 50;
        int MochaF = 40;
        int CayF = 10;
        int AmericanoF = 40;
        int SMochaF = 40;
        int PortakalSuyuF = 30;
        int KolaF = 5;
        int AyranF = 5;
        int GazozF = 5;

        //---------------Yemeklerin Fiayti Testi----------- 
        int tostF = 30;


        decimal toplamFiyat = 0;
        String icecekUrunleri = "";
        String yemkeUrunleri = "";

        if (cb1.Checked) { toplamFiyat += (nu1.Value) * TKahveF; icecekUrunleri += $"/Türk.K:{nu1.Value}"; }
        if (cb2.Checked) { toplamFiyat += (nu2.Value) * SpersoF; icecekUrunleri += $"/sperso:{nu2.Value}"; }
        if (cb3.Checked) { toplamFiyat += (nu3.Value) * LatteF; icecekUrunleri += $"/Latte:{nu3.Value}"; }
        if (cb4.Checked) { toplamFiyat += (nu4.Value) * CapichoF; icecekUrunleri += $"/Capicho:{nu4.Value}"; }
        if (cb5.Checked) { toplamFiyat += (nu5.Value) * MochaF; icecekUrunleri += $"/Mocha:{nu5.Value}"; }
        if (cb6.Checked) { toplamFiyat += (nu6.Value) * CayF; icecekUrunleri += $"/Çay:{nu6.Value}"; }
        if (cb7.Checked) { toplamFiyat += (nu7.Value) * AmericanoF; icecekUrunleri += $"/Americano:{nu7.Value}"; }
        if (cb8.Checked) { toplamFiyat += (nu8.Value) * SMochaF; icecekUrunleri += $"/Soğuk Mocha:{nu8.Value}"; }
        if (cb9.Checked) { toplamFiyat += (nu9.Value) * PortakalSuyuF; icecekUrunleri += $"/Portakal.S:{nu9.Value}"; }
        if (cb10.Checked) { toplamFiyat += (nu10.Value) * KolaF; icecekUrunleri += $"/Kola:{nu10.Value}"; }
        if (cb11.Checked) { toplamFiyat += (nu11.Value) * AyranF; icecekUrunleri += $"/Ayyran:{nu11.Value}"; }
        if (cb12.Checked) { toplamFiyat += (nu12.Value) * GazozF; icecekUrunleri += $"/Gazoz:{nu12.Value}"; }

        if (cb13.Checked) { toplamFiyat += (nu13.Value) * tostF; yemkeUrunleri += $"/Tost:{nu13.Value}"; }

        MessageBox.Show(icecekUrunleri);
        return toplamFiyat;
    }

    public static String icecekUrunleri(String ick)
    {
        return ick;
    }
    
}

class TimeClues 
{
    public static string nowTime()
    {
        DateTime currentDateTime = DateTime.Now;
        int currentYear = currentDateTime.Year;
        int currentMonth = currentDateTime.Month;
        int currentDay = currentDateTime.Day;
        String date = $"{currentYear.ToString()}/{currentMonth.ToString()}/{currentDay.ToString()}";
        return date;
    }
    public static string id()
    {
        string date = nowTime();
        string trg = date.Replace("/", "");
        return trg;
    }
}

class sqlCommandLar
{
    MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");
    public string icecek;
    public string yemek;
    public int toplamFiyat;
    public void ekleme(String icecek, String yemek)
    {
        try
        {
            tunel.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO scap (Tarih, Icecek, Yemek, ToplamFiyat) VALUES ('"+TimeClues.nowTime()+"', '"+ icecek + "', 'Tost', "+ yemek + "));",
                                                tunel);
            cmd.ExecuteNonQuery();
            tunel.Close();

        }
        catch(Exception e) 
        {
            MessageBox.Show(e.Message); 
        }
    }
    public void goster()
    {
        try
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from scap",tunel);
            DataTable dt = new DataTable();
            adp.Fill(dt);

        }
        catch (Exception e) {MessageBox.Show(e.Message); }
    }
}