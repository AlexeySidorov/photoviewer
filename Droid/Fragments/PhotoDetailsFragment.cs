using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using photoviewer.ViewModels;

namespace photoviewer.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class PhotoDetailsFragment : BaseFragment<PhotoDetailsViewModel>
    {
        protected override int FragmentId => Resource.Layout.PhotoDetailsScreen;

        /// <summary>
        /// View Created
        /// </summary>
        /// <param name="container"></param>
        /// <param name="savedInstanceState"></param>
        /// <param name="inflater"></param>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            InitViews(view);
            SetTitle(Resource.String.photo_screen_title);

            return view;
        }

        private void InitViews(View view)
        {
        }

        public override void OnResume()
        {
            base.OnResume();

            SetVisibleToolBar(true);
        }
    }
}
