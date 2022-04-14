using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

using Me.Yabbi.Ads;

enum AdType 
{
  banner,
  video
}

public class Showcase : MonoBehaviour
{
    public Text logger;
    public InputField pubIDField;
    public InputField interstitialIDField;
    public InputField videoIDField;

    private InterstitialAdContainer interstitialAdContainer;
    private VideoAdContainer videoAdContainer;


    private const string pubID = "d93d006b-7ed0-481e-bf88-76b5d90952e2";
    private const string bannerID = "1fa38071-abbf-40af-81ec-b106880dc789";
    private const string videoID = "551cb4fd-d20c-4edc-a1e7-8784b4470cbe";


    void Start()
    {   
        pubIDField.text = pubID;
        interstitialIDField.text = bannerID;
        videoIDField.text = videoID;


        RestartContainers();
    }

    public void RestartContainers(){
        try
        {
            Dispose();

            interstitialAdContainer = new InterstitialAdContainer(pubIDField.text, interstitialIDField.text);

           
            videoAdContainer = new VideoAdContainer(pubIDField.text, videoIDField.text);
            WriteNewLog($"PubID: {pubID}\nBannerID: {bannerID}\nVideoID: {videoID}",  true);
        }
        catch (Exception e)
        {
            WriteNewLog($"{e}", false);
        }
       


    }

    public void Dispose(){
        // if(interstitialAdContainer != null){
        //     interstitialAdContainer.Dispose();
        // }
        //  if(videoAdContainer != null){
        //     videoAdContainer.Dispose();
        // }
        
        interstitialAdContainer = null;
        videoAdContainer = null;
    }


    public void StartInterstitialBanner()
    {
        WriteNewLog("Me.Yabbi.Ads.InterstitialAdContainer | load", true);
        interstitialAdContainer.onFailed.AddListener((error)=> HandleFailed(error, AdType.banner));
        interstitialAdContainer.onClosed.AddListener(()=> HandleClosed(AdType.banner));
        interstitialAdContainer.onLoaded.AddListener(()=> HandleLoaded(AdType.banner));
        interstitialAdContainer.Load();
    }
     public void StartVideoBanner()
    {
        WriteNewLog("Me.Yabbi.Ads.VideoAdContainer | load", true);
        videoAdContainer.onFailed.AddListener((error)=> HandleFailed(error, AdType.video));
        videoAdContainer.onClosed.AddListener(()=> HandleClosed(AdType.video));
        videoAdContainer.onLoaded.AddListener(()=> HandleLoaded(AdType.video));
        videoAdContainer.Load();   
    }

     private void WriteNewLog(string message, bool restart = true)
     {
        if(restart){
                logger.text = message;
        } else {
            var current = logger.text;
            logger.text = $"{current}\n{message}";
        }
    }

     private void HandleLoaded(AdType type)
    {

        if(type == AdType.banner){
            WriteNewLog("InterstitialAdContainer | onLoad", false);
            interstitialAdContainer.Show();
        } else {
            WriteNewLog("VideoAdContainer | onLoad", false);
            videoAdContainer.Show();
        }

       
    }

    private void HandleFailed(string error, AdType type)
    {
        if(type == AdType.banner){
            WriteNewLog($"InterstitialAdContainer | onFail | {error}", false);
        } else {
            WriteNewLog($"VideoAdContainer | onFail | {error}", false);
        }
      
    }

     private void HandleClosed(AdType type)
    {
        if(type == AdType.banner){
            WriteNewLog("InterstitialAdContainer | onClose", false);

        } else {
            WriteNewLog("VideoAdContainer | onClose", false);
        }
    }
}

// public class AutoShowAdEvents : IAdEvents {
//     InterstitialAdContainer container;
//     Text logger; 

//     public AutoShowAdEvents(InterstitialAdContainer adContainer, Text loggerObject){
//         container = adContainer;
//         logger = loggerObject;
//     }
//      public void onLoad(){
//         WriteNewLog($"{container.GetType()} | onLoad", false);

//         container.Show();
//     }
//      public void onFail(string error){
//         WriteNewLog($"{container.GetType()} | onFail | {error}", false);
//     }
//      public void onShow(){
//         WriteNewLog($"{container.GetType()} | onShow", false);
//     }
//      public void onClose(){
//         WriteNewLog($"{container.GetType()} | onClose", false);
//     }
//      public void onComplete(){
//         WriteNewLog($"{container.GetType()} | onComplete", false);
//     }

//      private void WriteNewLog(string message, bool restart = true)
//      {
//         if(restart){
//             logger.text = message;
//         }else {
//             var current = logger.text;
//             logger.text = $"{current}\n{message}";
//         }
//     }
// }



// public class InterstitialAdContainer : AndroidJavaProxy, IAdEvents
//     {
//         // public class StringEvent : UnityEvent<string> { };

//         IAdEvents adEvents;

//         private AndroidJavaObject interstitialAdContainer;

//         public InterstitialAdContainer(string publisherID, string placementID) : base(YabbiAdsConstants.YabbiAdEventsClassName)
//         {
//             AndroidJavaClass playerClass = new AndroidJavaClass(YabbiAdsConstants.UnityActivityClassName);
//             AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
//             interstitialAdContainer = new AndroidJavaObject(YabbiAdsConstants.InterstitialAdContainerClassName, activity, publisherID, placementID);
//         }

//         public void SetAlwaysRequestLocation(bool isEnabled)
//         {
//             interstitialAdContainer?.Call("setAlwaysRequestLocation", isEnabled);
//         }

//         public void Load(IAdEvents events)
//         {   
//             adEvents = events;
//             interstitialAdContainer?.Call("load", this);
//         }

//         public bool IsLoaded()
//         {
//             return interstitialAdContainer != null && interstitialAdContainer.Call<bool>("isLoaded");
//         }

//         public void Show()
//         {
//             if (IsLoaded())
//             {
//                 interstitialAdContainer.Call("show");
//             }
//         }

//         public void onLoad()
//         {   
//             adEvents?.onLoad();
//             // onLoaded.Invoke();
//         }

//         public void onFail(string error)
//         {   
//             adEvents?.onFail(error);
//             // onFailed.Invoke(error);
//         }

//         public void onShow()
//         {   
//             adEvents?.onShow();
//             // onShown.Invoke();
//         }

//         public void onClose()
//         {   
//             adEvents?.onClose();
//             // onClosed.Invoke();
//         }

//         public void onComplete()
//         {   
//             adEvents?.onComplete();
//             // onCompleted.Invoke();
//         }
//     }


//  public static class YabbiAdsConstants
//     {
//         public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";
//         public const string YabbiAdEventsClassName = "me.yabbi.ads.sdk.AdEvents";
//         public const string InterstitialAdContainerClassName = "me.yabbi.ads.sdk.InterstitialAdContainer";
//         public const string VideoAdContainerClassName = "me.yabbi.ads.sdk.VideoAdContainer";
//     }
