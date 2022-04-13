using UnityEngine;
using UnityEngine.Events;

namespace Me.Yabbi.Ads
{
    public class InterstitialAdContainer : AndroidJavaProxy, IAdEvents
    {
        public class StringEvent : UnityEvent<string> { };

        public UnityEvent onLoaded = new UnityEvent();
        public UnityEvent<string> onFailed = new StringEvent();
        public UnityEvent onShown = new UnityEvent();
        public UnityEvent onClosed = new UnityEvent();
        public UnityEvent onCompleted = new UnityEvent();

        private AndroidJavaObject interstitialAdContainer;

        public InterstitialAdContainer(string publisherID, string placementID) : base(YabbiAdsConstants.YabbiAdEventsClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(YabbiAdsConstants.UnityActivityClassName);
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            interstitialAdContainer = new AndroidJavaObject(YabbiAdsConstants.InterstitialAdContainerClassName, activity, publisherID, placementID);
        }

        public void SetAlwaysRequestLocation(bool isEnabled) => interstitialAdContainer?.Call("setAlwaysRequestLocation", isEnabled);

        public void Load() => interstitialAdContainer?.Call("load", this);

        public bool IsLoaded() => interstitialAdContainer != null && interstitialAdContainer.Call<bool>("isLoaded");

        public void Show()
        {
            if (IsLoaded()) 
                interstitialAdContainer.Call("show");
        }

        public void onLoad() => onLoaded.Invoke();

        public void onFail(string error) => onFailed.Invoke(error);

        public void onShow() => onShown.Invoke();

        public void onClose() => onClosed.Invoke(); 
        public void onComplete() => onCompleted.Invoke();
    }
}
