using System;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using photoviewer.ViewModels;

namespace photoviewer.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class PhotoDetailsFragment : BaseFragment<PhotoDetailsViewModel>
    {
        protected override int FragmentId => Resource.Layout.PhotoDetailsScreen;
    }
}
