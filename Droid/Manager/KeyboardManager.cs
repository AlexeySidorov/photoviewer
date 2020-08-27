using Android.App;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.Fragment.App;
using MvvmCross.Platforms.Android.Views;

namespace photoviewer.Droid.Manager
{
    public static class KeyboardManager
    {
        /// <summary>
        /// Çàêðûòü êëàâèàòóðó
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(MvxActivity activity, View view)
        {
            if (activity != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        /// <summary>
        /// Çàêðûòü êëàâèàòóðó
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(Activity activity, View view)
        {
            if (activity != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        /// <summary>
        /// Çàêðûòü êëàâèàòóðó
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(FragmentActivity activity, View view)
        {
            if (activity != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        /// <summary>
        /// Çàêðûòü êëàâèàòóðó
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(Context context, View view)
        {
            if (context != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }
    }
}
