namespace AppodealAds.Unity.Api
{
    public static class YabbiAds
    {
        private static IYabbiAdsClient client;

        private static IYabbiAdsClient getInstance()
        {
            return client ?? (client = YabbiAdsClientFactory.GetYabbiAdsClient());
        }
    }
}

