#if UNITY_ANDROID || UNITY_EDITOR
using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Android
{
    public class AndroidYabbiAdsClient : IYabbiAdsClient
    {
        private AndroidJavaObject _activity;

        private string _publisherID;

        private AndroidJavaObject _videoAdContainer;
        private AndroidJavaObject _interstitialAdContainer;
        
        private static IInterstitialAdListener _interstitialAdListener;
        private static IVideoAdListener _videoAdListener;

        #region Singleton

        private AndroidYabbiAdsClient()
        {
        }

        public static AndroidYabbiAdsClient Instance { get; } = new AndroidYabbiAdsClient();

        #endregion

        public void Initialize(string publisherID)
        {
            _publisherID = publisherID;
        }

        public void InitializeAdContainer(string unitID, int adType)
        {
            switch (adType)
            {
                case YabbiAdsType.INTERSTITIAL:
                    _interstitialAdContainer = new AndroidJavaObject(YabbiAdsConstants.InterstitialAdContainerClassName, GetActivity(), _publisherID, unitID);
                    break;
                case YabbiAdsType.VIDEO:
                    _videoAdContainer = new AndroidJavaObject(YabbiAdsConstants.VideoAdContainerClassName, GetActivity(), _publisherID, unitID);
                    break;
            }
        }

        private AndroidJavaObject GetAdByType(int adType)
        {
            return adType switch
            {
                YabbiAdsType.INTERSTITIAL => _interstitialAdContainer,
                YabbiAdsType.VIDEO => _videoAdContainer,
                _ => null
            };
        }

        private AndroidJavaObject GetActivity()
        {
            if (_activity != null) return _activity;
            var playerClass = new AndroidJavaClass(YabbiAdsConstants.UnityActivityClassName);
            _activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");

            return _activity;
        }

        private static AndroidJavaObject BoolToAndroid(bool value)
        {
            var boleanClass = new AndroidJavaClass("java.lang.Boolean");
            var boolean = boleanClass.CallStatic<AndroidJavaObject>("valueOf", value);
            return boolean;
        }

        public bool IsAdInitialized(int adType) => GetAdByType(adType) != null;

        public void Show(int adType) => GetAdByType(adType)?.Call("show");

        public bool IsLoaded(int adType)
        {
            var container = GetAdByType(adType);
            return container != null && container.Call<bool>("isLoaded");
        }

        public void Load(int adType)
        {
            switch (adType)
            {
                case YabbiAdsType.INTERSTITIAL:
                    _interstitialAdContainer?.Call("load", new YabbiAdsInterstitialCallbacks(_interstitialAdListener));
                    break;
                case YabbiAdsType.VIDEO:
                    _videoAdContainer?.Call("load", new YabbiAdsVideoCallbacks(_videoAdListener));
                    break;
            }
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled) =>  GetAdByType(adType)?.Call("setAlwaysRequestLocation", BoolToAndroid(isEnabled));

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            _interstitialAdListener = adListener;
        }

        public void SetVideoCallbacks(IVideoAdListener adListener)
        {
            _videoAdListener = adListener;
        }

        public void Destroy(int adType)
        {
            switch (adType)
            {
                case YabbiAdsType.INTERSTITIAL:
                    _interstitialAdContainer = null;
                    break;
                case YabbiAdsType.VIDEO:
                    _videoAdContainer = null;
                    break;
            }
        }
    }
}
#endif