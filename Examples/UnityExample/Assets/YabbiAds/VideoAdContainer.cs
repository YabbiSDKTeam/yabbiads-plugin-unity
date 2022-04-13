using UnityEngine;
using UnityEngine.Events;

namespace Me.Yabbi.Ads
{
    public class VideoAdContainer : AndroidJavaProxy, IAdEvents
    {
        public class StringEvent : UnityEvent<string> { };

        public UnityEvent onLoaded = new UnityEvent();
        public UnityEvent<string> onFailed = new StringEvent();
        public UnityEvent onShown = new UnityEvent();
        public UnityEvent onClosed = new UnityEvent();
        public UnityEvent onCompleted = new UnityEvent();

        private AndroidJavaObject videoAdContainer;

        public VideoAdContainer(string publisherID, string placementID) : base(YabbiAdsConstants.YabbiAdEventsClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(YabbiAdsConstants.UnityActivityClassName);
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            videoAdContainer = new AndroidJavaObject(YabbiAdsConstants.VideoAdContainerClassName, activity, publisherID, placementID);
        }

        public void SetAlwaysRequestLocation(bool isEnabled) => videoAdContainer?.Call("setAlwaysRequestLocation", isEnabled);

        public void Load() => videoAdContainer?.Call("load", this);

        public bool IsLoaded() => videoAdContainer != null && videoAdContainer.Call<bool>("isLoaded");

        public void Show()
        {
            Debug.Log($"IsLoaded() - {IsLoaded()}");
            if (IsLoaded()) 
                videoAdContainer.Call("show");
        }

        public void onLoad() => onLoaded.Invoke();
        public void onFail(string error) => onFailed.Invoke(error);
        public void onShow() => onShown.Invoke();
        public void onClose() => onClosed.Invoke();
        public void onComplete() => onCompleted.Invoke();
    }
}
