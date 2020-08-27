using AndroidX.AppCompat.Widget;
using AndroidX.DrawerLayout.Widget;

namespace photoviewer.Droid.Navigations
{
    public interface INavigationActivity
    {
        /// <summary>
        /// Drawer layout base view
        /// </summary>
        DrawerLayout DrawerLayout { get; set; }

        /// <summary>
        /// Toolbar base view      
        /// </summary>
        Toolbar Toolbar { get; set; }
    }
}