using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App18.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall_iOS))]
namespace App18.iOS
{
   
    public class PhoneCall_iOS : IPhoneCall
    {
        public void ZwyklePolaczenie(string PhoneNumber)
        {
            try
            {
                NSUrl url = new NSUrl(string.Format(@"telprompt://{0}", PhoneNumber));
                UIApplication.SharedApplication.OpenUrl(url);
            }
            catch (Exception ex)
            {
                UIAlertView alert = new UIAlertView();
                alert.Title = "iOS Exception";
                alert.AddButton("OK");
                alert.Message = ex.ToString();
                alert.Show();
            }
        }
    }
}