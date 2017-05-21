using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CrossPlatformSample.IF;
using CrossPlatformSample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidToast))]
namespace CrossPlatformSample.Droid
{
    public class AndroidToast : IToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}