using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using photoviewer.Services;

namespace photoviewer
{
    public class App : MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<IRestApiService, RestApiService>();

            RegisterCustomAppStart<CustomApp>();
        }
    }
}
