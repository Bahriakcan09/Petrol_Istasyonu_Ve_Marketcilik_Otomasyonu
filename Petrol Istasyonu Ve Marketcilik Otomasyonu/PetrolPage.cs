using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        

        private async void button3_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
                petrolfiyat petrol = new petrolfiyat();
                petrol.İd = Convert.ToInt32(textBox9.Text);
                petrol.Ad = textBox8.Text;
                petrol.Litre = Convert.ToInt32(textBox10.Text);
                petrol.Fiyat = Convert.ToDouble(textBox7.Text);

                await firebase.Child("001").Child("Petroller").PostAsync(petrol);

            }
            catch (Exception)
            {
                MessageBox.Show("Urunler çekilemedi.");
            }

        }
        private async Task Petrol_GuncelleAsync(string key)
        {
            try
            {
                var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
                petrolfiyat petrol = new petrolfiyat();
                petrol.İd = Convert.ToInt32(textBox9.Text);
                petrol.Ad = textBox8.Text;
                petrol.Litre = Convert.ToInt32(textBox10.Text);
                petrol.Fiyat = Convert.ToDouble(textBox7.Text);

                await firebase.Child("001").Child("Petroller").Child(key).PutAsync(petrol);

            }
            catch (Exception)
            {
                MessageBox.Show("Urunler Güncellenemedi.");
            }
           
        }

        private void PetrolPage_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            
        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("İdSutunu", "Id");
            dataGridView1.Columns.Add("AdSutunu", "Ad");
            dataGridView1.Columns.Add("FiyatSutunu", "Fiyat");
            dataGridView1.Columns.Add("StokSutunu", "Litre");
            dataGridView1.Columns.Add("KeySutunu", "key");
            dataGridView1.Columns[4].Visible = false;
            var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
            var data = await firebase.Child("001").Child("Petroller").OnceAsync<petrolfiyat>();
            foreach (var item in data)
            {
                dataGridView1.Rows.Add(item.Object.İd, item.Object.Ad, item.Object.Fiyat, item.Object.Litre, item.Key);
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[0].Value?.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[1].Value?.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[2].Value?.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[3].Value?.ToString();
            
        }

        private async void button5_ClickAsync(object sender, EventArgs e)
        {
            await Petrol_GuncelleAsync(dataGridView1.SelectedRows[0].Cells[4].Value?.ToString());
        }
    }
}
