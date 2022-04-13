namespace YabbiAds.Unity.Common
{
    public interface IYabbiAdsClient
    {
        void initialize(string appKey);
        bool isInitialized(int adType);
        bool show(int adTypes);
        bool isLoaded(int adType);
        void cache(int adType);
        void disableLocationPermissionCheck();
        void setInterstitialCallbacks(IEventListener listener);
        void setVideoCallbacks(IEventListener listener);
        void destroy(int adType);
    }
}