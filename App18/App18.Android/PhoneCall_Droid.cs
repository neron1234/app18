﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App18.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall_Droid))]
namespace App18.Droid
{
    public class PhoneCall_Droid : IPhoneCall
    {
        public void ZwyklePolaczenie(string PhoneNumber)
        {
            try
            {
                var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", PhoneNumber));
                var intent = new Intent(Intent.ActionCall, uri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
            }
            catch (Exception ex)
            {
                new AlertDialog.Builder(Android.App.Application.Context).SetPositiveButton("OK", (sender, args) =>
                {
                    //User pressed OK
                })
                .SetMessage(ex.ToString())
                .SetTitle("Android Exception")
                .Show();
            }
        }

    }
}