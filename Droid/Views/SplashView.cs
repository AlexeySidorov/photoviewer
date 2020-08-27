using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Transitions;
using Android.Views;
using AndroidX.AppCompat.Widget;
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
    public class BaseView : MvxActivity<DashboardViewModel>
    {
        private int _layout = Resource.Layout.BaseView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(_layout);

            SetupWindowAnimations();

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
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
                Finish();
            else
                base.OnBackPressed();
        }

        /// <summary>
        /// Toolbar base activity
        /// </summary>
        public Toolbar Toolbar { get; set; }

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
