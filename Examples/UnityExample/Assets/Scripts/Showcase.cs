using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Me.Yabbi.Ads;

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
        Dispose();

        interstitialAdContainer = new InterstitialAdContainer(pubIDField.text, interstitialIDField.text);
        videoAdContainer = new VideoAdContainer(pubIDField.text, videoIDField.text);

        WriteNewLog($"PubID: {pubID}\nBannerID: {bannerID}\nVideoID: {videoID}",  true);
    }

    public void Dispose(){
        if(interstitialAdContainer != null){
            interstitialAdContainer.Dispose();
        }
         if(videoAdContainer != null){
            videoAdContainer.Dispose();
        }
        
        interstitialAdContainer = null;
        videoAdContainer = null;
    }


    public void StartInterstitialBanner()
    {
        WriteNewLog("Me.Yabbi.Ads.InterstitialAdContainer | load", true);
        interstitialAdContainer.Load(new AutoShowAdEvents(interstitialAdContainer, logger));
    }
     public void StartVideoBanner()
    {
        WriteNewLog("Me.Yabbi.Ads.VideoAdContainer | load", true);
        videoAdContainer.Load(new AutoShowAdEvents(videoAdContainer, logger));   
    }

     private void WriteNewLog(string message, bool restart = true)
     {
        if(restart){
                logger.text = message;
        }else {
            var current = logger.text;
            logger.text = $"{current}\n{message}";
        }
    }
}

public class AutoShowAdEvents : IAdEvents {
    BaseAdContainer container;
    Text logger; 

    public AutoShowAdEvents(BaseAdContainer adContainer, Text loggerObject){
        container = adContainer;
        logger = loggerObject;
    }
     public void onLoad(){
        WriteNewLog($"{container.GetType()} | onLoad", false);

        container.Show();
    }
     public void onFail(string error){
        WriteNewLog($"{container.GetType()} | onFail | {error}", false);
    }
     public void onShow(){
        WriteNewLog($"{container.GetType()} | onShow", false);
    }
     public void onClose(){
        WriteNewLog($"{container.GetType()} | onClose", false);
    }
     public void onComplete(){
        WriteNewLog($"{container.GetType()} | onComplete", false);
    }

     private void WriteNewLog(string message, bool restart = true)
     {
        if(restart){
            logger.text = message;
        }else {
            var current = logger.text;
            logger.text = $"{current}\n{message}";
        }
    }
}
