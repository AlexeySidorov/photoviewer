using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using photoviewer.core.DataBaseService;
using photoviewer.Core;
using photoviewer.Domain.Dao;
using photoviewer.Domain.models;
using photoviewer.Services;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace photoviewer
{
    public class App : MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override async void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<IRestApiService, RestApiService>();
            Mvx.IoCProvider.RegisterType<IAsyncRepository<UserDao>, AsyncRepository<UserDao>>();
            Mvx.IoCProvider.RegisterType<IAsyncRepository<PhotoDao>, AsyncRepository<PhotoDao>>();
            Mvx.IoCProvider.RegisterType<IAsyncRepository<SyncDao>, AsyncRepository<SyncDao>>();
            Mvx.IoCProvider.RegisterType<IAsyncRepository<PhotoUrlDao>, AsyncRepository<PhotoUrlDao>>();
            Mvx.IoCProvider.RegisterType<IAsyncRepository<UserImageUrlDao>, AsyncRepository<UserImageUrlDao>>();

            typeof(SyncService).GetTypeInfo().Assembly.CreatableTypes().Where(t => t.Name.EndsWith("Service")).AsInterfaces();

            ProjectSettings.DbName = "photoviewer.db";

            //Создание Базы данных
            await Task.Run(() => new DataBase().CreateDataBase(new List<Assembly>() { typeof(User).GetTypeInfo().Assembly }));

            RegisterCustomAppStart<CustomApp>();
        }
    }
}
