﻿using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using photoviewer.Domain.models;
using photoviewer.Droid.Adapters;
using photoviewer.Droid.Listeners;
using photoviewer.ViewModels;

namespace photoviewer.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class DashboardFragment : BaseFragment<DashboardViewModel>, IPhotoListener
    {
        private MvxRecyclerView _photos;

        protected override int FragmentId => Resource.Layout.DashboardScreen;

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
            InitData();

            return view;
        }

        private void InitViews(View view)
        {
            _photos = view.FindViewById<MvxRecyclerView>(Resource.Id.photos);
        }

        private void InitData()
        {
            var adapter = new PhotoAdapter((IMvxAndroidBindingContext)BindingContext);
            adapter.SetItemClickListener(this);
            _photos.SetLayoutManager(new LinearLayoutManager(Activity));
            _photos.HasFixedSize = true;
            _photos.SetAdapter(adapter);
        }

        public override void OnResume()
        {
            base.OnResume();

            SetVisibleToolBar(false);
        }

        public void ItemClick(Photo photo)
        {
            ViewModel?.SelectPhotoCommand.Execute(photo);
        }

        public void SetLike(string photoId)
        {
            throw new System.NotImplementedException();
        }
    }
}