using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace Petrol_Istasyonu_Ve_Marketcilik_Otomasyonu
{
    public partial class MarketPage : Form
    {
        public MarketPage()
        {
            InitializeComponent();
        }
        
        private async void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); 
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("İdSutunu", "Id");
            dataGridView1.Columns.Add("AdSutunu", "Ad");
            dataGridView1.Columns.Add("FiyatSutunu", "Fiyat");
            dataGridView1.Columns.Add("StokSutunu", "Stok");
            dataGridView1.Columns.Add("KeySutunu", "key");
            dataGridView1.Columns[4].Visible = false;
            var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
            var data = await firebase.Child(Properties.Settings.Default.marketID).Child("Urunler").OnceAsync<URUNLER>();
            foreach (var item in data)
            {
                dataGridView1.Rows.Add(item.Object.İd,item.Object.Ad,item.Object.Fiyat,item.Object.Adet,item.Key);
            }

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
                try
                {
                    var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
                    URUNLER urun = new URUNLER();
                    urun.İd = Convert.ToInt32(textBox1.Text);
                    urun.Ad = textBox2.Text;
                    urun.Fiyat = Convert.ToDouble(textBox3.Text);
                    urun.Adet = Convert.ToInt32(textBox4.Text);

                    await firebase.Child(Properties.Settings.Default.marketID).Child("Urunler").PostAsync(urun);

                }
                catch (Exception)
                {
                MessageBox.Show("Urunler çekilemedi.");
            }
            }

        private void MarketPage_Load(object sender, EventArgs e)
        {

        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            FirebaseClient firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
            await firebase.Child(Properties.Settings.Default.marketID).Child("Urunler").Child(dataGridView1.SelectedRows[0].Cells[4].Value?.ToString()).DeleteAsync();
            button4.PerformClick();
                   }

        private async void button3_ClickAsync(object sender, EventArgs e)
        {
            var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
            //var data = await firebase.Child("001").Child("Urunler").Child(dataGridView1.SelectedRows[0].Cells[4].Value?.ToString()).OnceSingleAsync<URUNLER>();
            URUNLER urn = new URUNLER();

                urn.İd = Convert.ToInt32(textBox1.Text);
                urn.Ad = textBox2.Text;
                urn.Fiyat = Convert.ToDouble(textBox3.Text);
                urn.Adet = Convert.ToInt32(textBox4.Text);

            await firebase.Child(Properties.Settings.Default.marketID).Child("Urunler").Child(dataGridView1.SelectedRows[0].Cells[4].Value?.ToString()).PutAsync(urn);
        }
    }
}

