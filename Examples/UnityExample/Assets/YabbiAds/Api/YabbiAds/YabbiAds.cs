using YabbiAds.Common;
using YabbiAds.Platform.Factory;
namespace AppodealAds.Unity.Api
{
    public static class YabbiAds
    {
        private static IYabbiAdsClient _client;

        private static IYabbiAdsClient GetInstance()
        {
            return _client ?? (_client = YabbiAdsClientFactory.GetYabbiAdsClient());
        }
    }
}

