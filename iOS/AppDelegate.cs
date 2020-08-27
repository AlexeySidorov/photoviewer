using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace photoviewer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}