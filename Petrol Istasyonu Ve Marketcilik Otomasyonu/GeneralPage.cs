using System;
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
    public partial class GeneralPage : Form
    {
        public GeneralPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PetrolPage petrolPage = new PetrolPage();
            petrolPage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MarketPage marketPage = new MarketPage();
            marketPage.Show();
        }
    }
}
