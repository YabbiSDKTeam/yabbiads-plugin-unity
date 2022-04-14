using System.Collections.Generic;

namespace YabbiAds.Common
{
    public interface IYabbiAdsClient
    {
        public void Initialize(string publisherID);
        public void InitializeAdContainer(string unitID, int adType);
        bool IsAdInitialized(int adType);
        void Show(int adType);
        bool IsLoaded(int adType);
        void Load(int adType);
        public void SetAlwaysRequestLocation(int adType, bool isEnabled);
        void SetInterstitialCallbacks(IInterstitialAdListener adListener);
        void SetVideoCallbacks(IVideoAdListener adListener);
        void Destroy(int adType);
    }
}