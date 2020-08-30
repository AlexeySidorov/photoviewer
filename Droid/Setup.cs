using System.Collections.Generic;
using System.Reflection;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Plugin;
using photoviewer.core.Services;

namespace photoviewer.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(MvxRecyclerView).Assembly
            };

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);
        }

        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterType<IMvxBindingContext, MvxBindingContext>();
            Mvx.IoCProvider.RegisterSingleton<IDialogService> (new DialogService());
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IDataBaseService, DataBaseService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IPlatformService, PlatformService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IConnectionService, ConnectionService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IProgressDialogService, ProgressDialogService>();

            base.InitializeFirstChance();
        }
    }
}