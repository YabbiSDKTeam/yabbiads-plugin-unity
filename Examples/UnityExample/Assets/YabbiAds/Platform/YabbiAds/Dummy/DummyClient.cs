using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Dummy
{
    public class DummyClient : IYabbiAdsClient
    {
        #region YabbiAds

        public void Initialize(string appKey)
        {
            debugLog("YabbiAds.initialize");
        }

        public bool IsInitialized(int adType)
        {
            debugLog("YabbiAds.isInitialized");
            return false;
        }

        public bool Show(int adType)
        {
            debugLog("YabbiAds.show");
            return false;
        }

        public bool IsLoaded(int adType)
        {
            debugLog("YabbiAds.isLoaded");
            return false;
        }

        public void Cache(int adType)
        {
            debugLog("YabbiAds.cache");
        }

        public void DisableLocationPermissionCheck()
        {
            debugLog("YabbiAds.disableLocationPermissionCheck");
        }

        public void SetInterstitialCallbacks(IEventListener listener)
        {
            debugLog("YabbiAds.setInterstitialCallbacks");
        }

        public void SetVideoCallbacks(IEventListener listener)
        {
            debugLog("YabbiAds.setVideoCallbacks");
        }

        public void Destroy(int adTypes)
        {
            debugLog("YabbiAds.destroy");
        }

        #endregion

        #region Debug

        private void debugLog(string method)
        {
            Debug.Log(
                $"Call to {method} on not supported platform. To test advertising, install your application on the Android/iOS device.");
        }

        #endregion
    }
}