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

[assembly: Dependency(typeof(OrientationHandler))]
namespace Lexov.Droid.Utilities
{
    class OrientationHandler : BaseDependencyImplementation, IOrientationHandler
    {
        [Obsolete]
        public void ForceLandscape()
        {
            GetActivity().RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
        }

        [Obsolete]
        public void ForcePortrait()
        {
            GetActivity().RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }
    }
}