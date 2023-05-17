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
                GeneralPage generalPage = new GeneralPage();
                generalPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giris Basarisiz");
            }
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
    }
}
