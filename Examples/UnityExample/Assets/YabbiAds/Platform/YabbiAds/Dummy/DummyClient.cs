namespace AppodealAds.Unity.Dummy
{
    public class DummyClient : IYabbiAdsClient
    {
        #region YabbiAds
            
            void initialize(string appKey)
            {
                debugLog("YabbiAds.initialize");
            }
            bool isInitialized(int adType)
            {
                debugLog("YabbiAds.isInitialized");
            }
            bool show(int adType)
            {
                debugLog("YabbiAds.show");
            }
            bool isLoaded(int adType)
            {
                debugLog("YabbiAds.isLoaded");
            }
            void cache(int adType)
            {
                debugLog("YabbiAds.cache");
            }
            void disableLocationPermissionCheck()
            {
                debugLog("YabbiAds.disableLocationPermissionCheck");
            }
            void setInterstitialCallbacks(IEventListener listener)
            {
                debugLog("YabbiAds.setInterstitialCallbacks");
            }
            void setVideoCallbacks(IEventListener listener)
            {
                debugLog("YabbiAds.setVideoCallbacks");
            }
            void destroy(int adTypes)
            {
                debugLog("YabbiAds.destroy");
            }

            #endregion
            
            #region Debug

            private void debugLog(string method)
            {
                Debug.Log($"Call to {method} on not supported platform. To test advertising, install your application on the Android/iOS device.");
            }
            
            #endregion
    }
}

