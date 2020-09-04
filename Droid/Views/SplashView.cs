using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Transitions;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.DrawerLayout.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using photoviewer.Droid.Manager;
using photoviewer.Droid.Navigations;
using photoviewer.ViewModels;
using Plugin.Permissions;

namespace photoviewer.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.StateAlwaysHidden)]
    public class SplashView : MvxActivity<SplashViewModel>, INavigationActivity
    {
        private int _layout = Resource.Layout.BaseView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(_layout);

            SetupWindowAnimations();

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        /// <summary>
        /// WindowAnimations
        /// </summary>
        private void SetupWindowAnimations()
        {
            if (Build.VERSION.SdkInt == BuildVersionCodes.Lollipop)
            {
                var fade = new Fade();
                fade.SetDuration(1000);
                Window.EnterTransition = fade;
                var slide = new Slide();
                slide.SetDuration(1000);
                Window.ExitTransition = slide;
            }
        }

        /// <summary>
        /// Back pressed
        /// </summary>
        public override void OnBackPressed()
        {
            KeyboardManager.HideKeyboard(this, Toolbar);

            var fm = SupportFragmentManager;
            // ReSharper disable once SuspiciousTypeConversion.Global
            var backPressedListener = fm.Fragments.OfType<IBackPressedListener>().FirstOrDefault();
            if (backPressedListener != null && !backPressedListener.IsBaseBackPressed)
                backPressedListener.OnBackPressed();
            else if (fm.BackStackEntryCount == 1)
                return;
            else
                base.OnBackPressed();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        /// <summary>
        /// Toolbar base activity
        /// </summary>
        public Toolbar Toolbar { get; set; }

        public DrawerLayout DrawerLayout { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        /// <summary>
        /// Request permissions
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
