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
using Lexov.Droid.Utilities;
using Lexov.Utilities;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OpenAppAndroid))]
namespace Lexov.Droid.Utilities
{
    public class OpenAppAndroid : Activity, IOpenApp
    {
        public OpenAppAndroid() { }

        [Obsolete]
        public void OpenExternalApp()
        {
            Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage("org.sufficientlysecure.keychain");

            if(intent != null)
            {
                intent.AddFlags(ActivityFlags.NewTask);
                Forms.Context.StartActivity(intent);
            }
            else
            {
                intent = new Intent(Intent.ActionView);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.SetData(Android.Net.Uri.Parse("https://f-droid.org/en/packages/org.sufficientlysecure.keychain/"));
                Forms.Context.StartActivity(intent);
            }
        }
    }
}