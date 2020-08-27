using MvvmCross.Platforms.Android.Presenters.Attributes;
using photoviewer.ViewModels;

namespace photoviewer.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class DashboardFragment : BaseFragment<DashboardViewModel>
    {
        protected override int FragmentId => Resource.Layout.DashboardScreen;
    }
}
