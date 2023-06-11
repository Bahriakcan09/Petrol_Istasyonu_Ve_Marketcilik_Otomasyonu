using Firebase.Auth.Providers;
using Firebase.Auth;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Petrol_Istasyonu_Ve_Marketcilik_Otomasyonu
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            if (!internetCheck.internet())
            {
                MessageBox.Show("Internet Baglantısı Yok.");
                return;
            };
            bool login = await loginAsync();
            if (login)
            {
                bool search = await searchMarketAsync();
                if(search)
                {
                    Properties.Settings.Default.lastMail = usernameTxt.Text;
                    GeneralPage generalPage = new GeneralPage();
                    generalPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi tekrar deneyiniz");
                }
            }
            else
            {
                MessageBox.Show("Giris Basarisiz");
            }
        }
        private async Task<bool> searchMarketAsync()
        {
            if (internetCheck.internet())
            {
                var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
                var data = await firebase.Child("MarketCalisanlari").OnceAsync<Market>();
                foreach (var item in data)
                {
                    if(usernameTxt.Text == item.Object.Mail)
                    {
                        Properties.Settings.Default.marketID = item.Object.Id;
                        Properties.Settings.Default.Save();
                        return true;
                    }
                }
                return false;
            }  
            return false;
    }
        private async Task<bool> loginAsync()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyBPP5gvm8JvBT43dAsqUYlOXxy_GUcMyAU",
                AuthDomain = "petrol-ve-marketcilik.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new GoogleProvider().AddScopes("email"),
                    new EmailProvider()

                },
            };

            var client = new FirebaseAuthClient(config);
            try
            {
                await client.SignInWithEmailAndPasswordAsync(usernameTxt.Text, passwordTxt.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.lastMail))
            {
                usernameTxt.Text = Properties.Settings.Default.lastMail;
            }
        }
    }
}
