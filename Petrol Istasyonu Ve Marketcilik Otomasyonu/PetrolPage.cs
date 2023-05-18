﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petrol_Istasyonu_Ve_Marketcilik_Otomasyonu
{
    public partial class PetrolPage : Form
    {
        public PetrolPage()
        {
            InitializeComponent();
        }
        double M_Benzin = 0, M_Dizel = 0, M_LPG = 0; //kullanacağımız değişkenleri tanımladık
        double E_Benzin = 0, E_Dizel = 0, E_LPG = 0;
        double F_Benzin = 0, F_Dizel = 0, F_LPG = 0;
        string[] depo_bilgileri; 
        private void txt_depo_oku()
        { //burada petrol türlerimiz double, dizimiz string olduğu için dizimizi double değişkenine çeviriyoruz. 
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            M_Benzin = Convert.ToDouble(depo_bilgileri[0]); 
             M_Dizel = Convert.ToDouble(depo_bilgileri[1]);
             M_LPG = Convert.ToDouble(depo_bilgileri[2]);
        }
        private void txt_depo_yaz()
        {
            label1.Text = M_Benzin.ToString("N"); //virgülden sonra basamak sayısını 2ye ayarlıyoruz.
            label2.Text = M_Dizel.ToString("N");
            label3.Text = M_LPG.ToString("N");
        }

        private void PetrolPage_Load(object sender, EventArgs e)
        {
            txt_depo_oku();
            txt_depo_yaz();
        }
    }
}
