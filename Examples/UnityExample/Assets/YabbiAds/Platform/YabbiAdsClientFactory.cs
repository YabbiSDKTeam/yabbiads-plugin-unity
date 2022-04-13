using YabbiAds.Unity.Common;

namespace YabbiAds.Unity
{
    internal static class YabbiAdsClientFactory
    {
        internal static IAYabbiAdsClient GetYabbiAdsClient()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new Android.AndroidYabbiClient ();
#elif UNITY_IPHONE && !UNITY_EDITOR
			return iOS.iOSYabbiAdsClient.Instance;
#else
            return new Dummy.DummyClient();
#endif
        }
    }
}