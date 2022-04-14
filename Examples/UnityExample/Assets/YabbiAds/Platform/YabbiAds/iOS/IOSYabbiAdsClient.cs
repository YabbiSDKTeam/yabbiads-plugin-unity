#if UNITY_IPHONE || UNITY_EDITOR
using AOT;
using YabbiAds.Common;

namespace YabbiAds.Platform.iOS
{
    public class IOSYabbiAdsClient : IYabbiAdsClient
    {
        #region Singleton

        private IOSYabbiAdsClient()
        {
        }

        public static IOSYabbiAdsClient Instance { get; } = new IOSYabbiAdsClient();

        #endregion


        private static IInterstitialAdListener _interstitialAdListener;
        private static IVideoAdListener _videoAdListener;


        public void Initialize(string publisherID)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeAd(string unitID, int type)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAdInitialized(int adType)
        {
            throw new System.NotImplementedException();
        }

        public void ShowAd(int adType)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAdLoaded(int adType)
        {
            throw new System.NotImplementedException();
        }

        public void LoadAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiAdsLoadAd(adType);
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            YabbiAdsObjCBridge.YabbiAdsSetAlwaysRequestLocation(adType, isEnabled);
        }

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            _interstitialAdListener = adListener;
            YabbiAdsObjCBridge.YabbiAdsSetInterstitialDelegate(IntestitalListener);
        }

        public void SetVideoCallbacks(IVideoAdListener adListener)
        {
            _videoAdListener = adListener;
            YabbiAdsObjCBridge.YabbiAdsSetVideoDelegate(VideoListener);
        }

        public void DestroyAd(int adType)
        {
            throw new System.NotImplementedException();
        }

        #region Intestital Delegate

        [MonoPInvokeCallback(typeof(YabbiAdsListenerType))]
        internal static void IntestitalListener(string type, string message)
        {
        }

        #endregion

        #region Video Delegate

        [MonoPInvokeCallback(typeof(YabbiAdsListenerType))]
        internal static void VideoListener(string type, string message)
        {
        }

        #endregion


        // private static void nativeCallback(string type, string message, IAdEvents adEvents)
        // {
        //     switch (type)
        //     {
        //         case "onLoad":
        //             adEvents.onLoad();
        //             break;
        //         case "onShow":
        //             adEvents.onShow();
        //             break;
        //         case "onFail":
        //             adEvents.onFail(message);
        //             break;
        //         case "onClose":
        //             adEvents.onClose();
        //             break;
        //         case "onComplete":
        //             adEvents.onComplete();
        //             break;
        //         case "YabbiAdsException":
        //             adEvents.onFail(message);
        //             break;
        //         default:
        //             adEvents.onFail("No case found for " + type + "with message: " + message);
        //             break;
        //     }
        // }
    }
}
#endif