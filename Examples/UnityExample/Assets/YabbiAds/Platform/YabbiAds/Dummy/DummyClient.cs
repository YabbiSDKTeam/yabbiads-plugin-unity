using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Dummy
{
    public class DummyClient : IYabbiAdsClient
    {
        #region YabbiAds

        public void Initialize(string publisherId)
        {
            debugLog("YabbiAds.initialize");
        }

        public void InitializeAdContainer(string unitId, int adType)
        {
            debugLog("YabbiAds.InitializeAdContainer");
        }

        public bool IsAdInitialized(int adType)
        {
            debugLog("YabbiAds.isInitialized");
            return false;
        }

        public void Show(int adType)
        {
            debugLog("YabbiAds.show");
        }

        public bool IsLoaded(int adType)
        {
            debugLog("YabbiAds.isLoaded");
            return false;
        }

        public void Load(int adType)
        {
            debugLog("YabbiAds.Load");
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            debugLog("YabbiAds.SetAlwaysRequestLocation");
        }

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            debugLog("YabbiAds.setInterstitialCallbacks");
        }

        public void SetVideoCallbacks(IVideoAdListener adListener)
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