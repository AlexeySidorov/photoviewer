using Android.Content;
using Android.Util;

namespace photoviewer.Droid.Converters
{
    public static class ConvertScreenValue
    {
        /// <summary>
        /// Êîíâåðòàöèÿ DP to PX
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static float ConvertDpToPixel(int dp, Context context)
        {
            var resources = context.Resources;
            var metrics = resources.DisplayMetrics;
#pragma warning disable 618
            var px = dp * ((float)metrics.DensityDpi / (float)DisplayMetricsDensity.Default);
#pragma warning restore 618

            return px;
        }

        /// <summary>
        ///  Êîíâåðòàöèÿ PX to DP
        /// </summary>
        /// <param name="px"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static float ConvertPixelsToDp(float px, Context context)
        {
            var resources = context.Resources;
            var metrics = resources.DisplayMetrics;
#pragma warning disable 618
            var dp = px / ((float)metrics.DensityDpi / (float)DisplayMetricsDensity.Default);
#pragma warning restore 618

            return dp;
        }
    }
}