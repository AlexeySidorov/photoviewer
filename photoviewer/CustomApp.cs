using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using photoviewer.core.DataBaseService;
using photoviewer.core.Services;
using photoviewer.Domain.Dao;
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

            //Создание Базы данных
            Task.Run(() => new DataBase().CreateDataBase(new List<Assembly>() { typeof(UserDao).GetTypeInfo().Assembly })).GetAwaiter().GetResult(); ;

            return NavigationService.Navigate<DashboardViewModel>();
        }
    }
}