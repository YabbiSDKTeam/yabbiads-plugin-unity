#if UNITY_IPHONE || UNITY_EDITOR
using System.Runtime.InteropServices;


namespace YabbiAds.Platform.iOS
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void YabbiAdsListenerType([MarshalAs(UnmanagedType.LPStr), In] string type, string message);

    internal static class YabbiAdsObjCBridge
    {
        #region Declare external C interface

        [DllImport("__Internal")]
        internal static extern long YabbiAdsInitialize(string publisherID);

        [DllImport("__Internal")]
        internal static extern long YabbiAdsInitializeAdContainer(string unitId, long adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsLoadAd(long adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsShowContainer(long adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsSetAlwaysRequestLocation(bool isEnabled, long adType);

        [DllImport("__Internal")]
        internal static extern bool YabbiAdsIsAdLoaded(long adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsDispose(long adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsSetInterstitialDelegate(
            [MarshalAs(UnmanagedType.FunctionPtr)] YabbiAdsListenerType listener);

        #endregion
    }
}
#endif