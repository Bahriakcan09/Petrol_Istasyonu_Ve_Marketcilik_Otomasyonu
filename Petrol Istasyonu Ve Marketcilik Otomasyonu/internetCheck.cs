using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Petrol_Istasyonu_Ve_Marketcilik_Otomasyonu
{
    internal class internetCheck
    {
        public static bool internet()
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.OpenRead("https://google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}