using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using photoviewer.core.Services;
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
            //Инициализирует RootViewController
            if (Mvx.IoCProvider.Resolve<IPlatformService>().Platform == Platform.Ios)
                NavigationService.Navigate<SplashViewModel>().GetAwaiter().GetResult();

            return NavigationService.Navigate<DashboardViewModel>();
        }
    }
}