using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using photoviewer.ViewModels;

namespace photoviewer
{
    public class CustomApp : MvxAppStart
    {
        public CustomApp(IMvxApplication app, IMvxNavigationService navigationService)
            : base(app, navigationService)
        {

        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<DashboardViewModel>();
        }
    }
}
