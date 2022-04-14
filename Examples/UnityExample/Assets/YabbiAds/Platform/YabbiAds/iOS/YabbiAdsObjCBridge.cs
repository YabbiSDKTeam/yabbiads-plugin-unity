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
        internal static extern long YabbiAdsInitializeAdContainer(string unitId, int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsLoadAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsShowContainer(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsSetAlwaysRequestLocation(int adType, bool isEnabled);

        [DllImport("__Internal")]
        internal static extern bool YabbiAdsIsAdLoaded(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsDispose(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiAdsSetInterstitialDelegate(
            [MarshalAs(UnmanagedType.FunctionPtr)] YabbiAdsListenerType listener);

        internal static extern void YabbiAdsSetVideoDelegate(
            [MarshalAs(UnmanagedType.FunctionPtr)] YabbiAdsListenerType listener);

        #endregion
    }
}
#endif