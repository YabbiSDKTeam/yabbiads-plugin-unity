namespace YabbiAds.Common
{
    public interface IYabbiAdsClient
    {
        bool IsInitialized(int adType);
        bool Show(int adTypes);
        bool IsLoaded(int adType);
        void Cache(int adType);
        void DisableLocationPermissionCheck();
        void SetInterstitialCallbacks(IEventListener listener);
        void SetVideoCallbacks(IEventListener listener);
        void Destroy(int adType);
    }
}