using YabbiAds.Common;
using YabbiAds.Platform.Factory;

namespace YabbiAds.Api
{
    public static class Yabbi
    {
        private static IYabbiAdsClient _client;

        private static IYabbiAdsClient GetInstance()
        {
            return _client ?? (_client = YabbiAdsClientFactory.GetYabbiAdsClient());
        }

        public static void Initialize(string publisherID)
        {
            GetInstance().Initialize(publisherID);
        }

        public static void InitializeAdContainer(string unitID, int adType)
        {
            GetInstance().InitializeAdContainer(unitID, adType);
        }

        public static bool IsAdInitialized(int adType)
        {
            return GetInstance().IsAdInitialized(adType);
        }

        public static void Show(int adType)
        {
            GetInstance().Show(adType);
        }

        public static bool IsLoaded(int adType)
        {
            return GetInstance().IsLoaded(adType);
        }

        public static void Load(int adType)
        {
            GetInstance().Load(adType);
        }

        public static void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            GetInstance().SetAlwaysRequestLocation(adType, isEnabled);
        }

        public static void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            GetInstance().SetInterstitialCallbacks(adListener);
        }

        public static void SetVideoCallbacks(IVideoAdListener adListener)
        {
            GetInstance().SetVideoCallbacks(adListener);
        }

        public static void Destroy(int adType)
        {
            GetInstance().Destroy(adType);
        }
    }
}