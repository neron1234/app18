using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App18
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            
		}

        void zadzwonGsmClicked(object sender, EventArgs args)
        {
            try
            {

                if (numerTelefonu.Text == "")
                {
                    DisplayAlert("Alert", "Specify the number to start the call.", "OK");
                }
                else
                {
                    DependencyService.Get<IPhoneCall>().ZwyklePolaczenie(numerTelefonu.Text.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void zadzwonVoipClicked(object sender, EventArgs args)
        {
            try
            {

                GetXml();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void GetXml()
        {
            //Check network status  
            if (NetworkCheck.IsInternet())
            {
                string xml = "";


                var httpContent = new StringContent(xml, Encoding.UTF8, "application/xml");
                var requestUri = "";
                var client = new HttpClient(new NativeMessageHandler());
                var response = await client.PostAsync(requestUri, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                   await   DisplayAlert("XmlParsing", "Bed url", "Ok");
                }


                if (response != null && response.IsSuccessStatusCode)
                {
                    var s = await response.Content.ReadAsStringAsync();
                }

            }
            else
            {
                await DisplayAlert("XmlParsing", "No network is available.", "Ok");
            }
        }
    }
}
