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
        var auth = "QIcj0RgPDtVzQFW919C9ojVnJkJDff7Ps4m7lqQq"; // your app secret
        var firebaseClient = new FirebaseClient(
            "<QIcj0RgPDtVzQFW919C9ojVnJkJDff7Ps4m7lqQq>");
        //new FirebaseOptions
        //{
        //    AuthTokenAsyncFactory = () => Task.FromResult(auth)
        //}


        private void MarketPage_Load(object sender, EventArgs e)
        {
             var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
             var dinos = await firebase
                .Child("")
                .OrderByKey()
                .StartAt("")
                .LimitToFirst()
                .OnceAsync<>();
  
             foreach (var dino in dinos)
             {
              Console.WriteLine($"{dino.Key} is {dino.Object.Height}m high.");
             }
        }
 
             var firebase = new FirebaseClient("https://petrol-ve-marketcilik-default-rtdb.firebaseio.com/");
   
             var dino = await firebase
               .Child("")
               .PostAsync(new Dinosaur());
             
             Console.WriteLine($"Key for the new dinosaur: {dino.Key}");
             
             await firebase
               .Child("dinosaurs")
               .Child("t-rex")
               .PutAsync(new Dinosaur());
             
             await firebase
               .Child("dinosaurs")
               .Child("t-rex")
               .DeleteAsync();
                }

        
    }

