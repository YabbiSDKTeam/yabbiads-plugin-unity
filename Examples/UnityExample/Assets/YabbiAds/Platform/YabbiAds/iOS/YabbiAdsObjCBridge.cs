#if UNITY_IPHONE || UNITY_EDITOR
using System.Runtime.InteropServices;


namespace YabbiAds.Platform.iOS
{
    // [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    // internal delegate void YabbiAdsListenerType([MarshalAs(UnmanagedType.LPStr), In] string type, string message);
    internal delegate void YabbiCallbacks();

    internal delegate void YabbiFailedCallbacks(string messgae);


    internal static class YabbiAdsObjCBridge
    {
        #region Declare external C interface

        [DllImport("__Internal")]
        internal static extern void YabbiInitialize(string publisherID);

        [DllImport("__Internal")]
        internal static extern void YabbiInitializeAd(string unitID, int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiLoadAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiShowAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiSetAlwaysRequestLocation(int adType, bool isEnabled);

        [DllImport("__Internal")]
        internal static extern bool YabbiIsAdLoaded(int adType);

        [DllImport("__Internal")]
        internal static extern bool YabbiIsAdInitialized(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiDestroAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiSetInterstitialDelegate(
            YabbiCallbacks onLoaded,
            YabbiCallbacks onShown,
            YabbiCallbacks onClosed,
            YabbiFailedCallbacks onFailed
        );

        [DllImport("__Internal")]
        internal static extern void YabbiSetVideoDelegate(
            YabbiCallbacks onLoaded,
            YabbiCallbacks onShown,
            YabbiCallbacks onClosed,
            YabbiCallbacks onFinished,
            YabbiFailedCallbacks onFailed
        );

        #endregion
    }
}
#endif