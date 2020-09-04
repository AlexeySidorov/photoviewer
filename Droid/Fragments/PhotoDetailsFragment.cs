using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using photoviewer.ViewModels;
using static Android.Views.View;

namespace photoviewer.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class PhotoDetailsFragment : BaseFragment<PhotoDetailsViewModel>, IOnClickListener
    {
        private RelativeLayout _likeBlock;

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
            InitListener();

            return view;
        }

        private void InitViews(View view)
        {
            _likeBlock = view.FindViewById<RelativeLayout>(Resource.Id.like_block);
        }

        private void InitListener()
        {
            _likeBlock.SetOnClickListener(this);
        }

        public override void OnResume()
        {
            base.OnResume();

            SetVisibleToolBar(true);
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public void OnClick(View v)
        {
            ViewModel?.LikeCommand.Execute();
        }
    }
}
