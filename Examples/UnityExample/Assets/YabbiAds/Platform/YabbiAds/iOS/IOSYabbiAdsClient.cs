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
        
        
        public bool IsInitialized(int adType)
        {
            throw new System.NotImplementedException();
        }

        public bool Show(int adTypes)
        {
            throw new System.NotImplementedException();
        }

        public bool IsLoaded(int adType)
        {
            throw new System.NotImplementedException();
        }

        public void Cache(int adType)
        {
            throw new System.NotImplementedException();
        }

        public void DisableLocationPermissionCheck()
        {
            throw new System.NotImplementedException();
        }

        public void SetInterstitialCallbacks(IEventListener listener)
        {
            throw new System.NotImplementedException();
        }

        public void SetVideoCallbacks(IEventListener listener)
        {
            throw new System.NotImplementedException();
        }

        public void Destroy(int adType)
        {
            throw new System.NotImplementedException();
        }
    }
}