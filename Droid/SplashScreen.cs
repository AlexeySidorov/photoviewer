
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace photoviewer.Droid
{
    [Activity(
        Label = "PhotoViewer"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/AppTheme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
