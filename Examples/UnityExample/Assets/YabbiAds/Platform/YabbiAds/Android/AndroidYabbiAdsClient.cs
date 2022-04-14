using YabbiAds.Common;

namespace YabbiAds.Platform.Android
{
    public class AndroidYabbiAdsClient : IYabbiAdsClient
    {   
        #region Singleton

        private AndroidYabbiAdsClient()
        {
        }

        public static AndroidYabbiAdsClient Instance { get; } = new AndroidYabbiAdsClient();

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