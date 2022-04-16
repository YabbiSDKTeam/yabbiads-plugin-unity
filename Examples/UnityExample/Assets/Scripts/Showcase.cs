using System;
using UnityEngine;
using UnityEngine.UI;
using YabbiAds.Api;
using YabbiAds.Common;


public class Showcase : MonoBehaviour, IInterstitialAdListener, IVideoAdListener
{
    public Text logger;
    public InputField pubIDField;
    public InputField interstitialIDField;
    public InputField videoIDField;


    private const string PubID = "d93d006b-7ed0-481e-bf88-76b5d90952e2";
    private const string BannerID = "1fa38071-abbf-40af-81ec-b106880dc789";
    private const string VideoID = "551cb4fd-d20c-4edc-a1e7-8784b4470cbe";


    private void Start()
    {
        pubIDField.text = PubID;
        interstitialIDField.text = BannerID;
        videoIDField.text = VideoID;


        RestartContainers();
    }

    public void RestartContainers()
    {
        try
        {
            Destroy();

            Yabbi.Initialize(PubID);

            Yabbi.InitializeAdContainer(BannerID, YabbiAdsType.Interstitial);
            Yabbi.InitializeAdContainer(VideoID, YabbiAdsType.Video);
            Yabbi.SetInterstitialCallbacks(this);
            Yabbi.SetVideoCallbacks(this);

            WriteNewLog($"PubID: {PubID}\nBannerID: {BannerID}\nVideoID: {VideoID}");
        }
        catch (Exception e)
        {
            WriteNewLog($"{e}", false);
        }
    }

    private void Destroy()
    {
        Yabbi.DestroyAd(YabbiAdsType.Interstitial);
        Yabbi.DestroyAd(YabbiAdsType.Video);
    }


    public void StartInterstitialBanner()
    {
        WriteNewLog("Me.Yabbi.Ads.InterstitialAdContainer | load");
        Yabbi.Load(YabbiAdsType.Interstitial);
    }

    public void StartVideoBanner()
    {
        WriteNewLog("Me.Yabbi.Ads.VideoAdContainer | load");
        Yabbi.Load(YabbiAdsType.Video);
    }

    private void WriteNewLog(string message, bool restart = true)
    {
        if (restart)
        {
            logger.text = message;
        }
        else
        {
            var current = logger.text;
            logger.text = $"{current}\n{message}";
        }
    }

    public void OnInterstitialLoaded()
    {
        WriteNewLog("InterstitialAdContainer | onLoad", false);
        Yabbi.ShowAd(YabbiAdsType.Interstitial);
    }

    public void OnInterstitialFailed(string error)
    {
        WriteNewLog($"InterstitialAdContainer | onFail | {error}", false);
    }

    public void OnInterstitialShown()
    {
        WriteNewLog($"InterstitialAdContainer | onShow", false);
    }

    public void OnInterstitialClosed()
    {
        WriteNewLog($"InterstitialAdContainer | onClose", false);
    }

    public void OnVideoLoaded()
    {
        WriteNewLog($"VideoAdContainer | onLoad", false);
        Yabbi.ShowAd(YabbiAdsType.Video);
    }

    public void OnVideoFailed(string error)
    {
        WriteNewLog($"VideoAdContainer | onFail | {error}", false);
    }

    public void OnVideoShown()
    {
        WriteNewLog($"VideoAdContainer | onShow", false);
    }

    public void OnVideoFinished()
    {
        WriteNewLog($"VideoAdContainer | onFinish", false);
    }

    public void OnVideoClosed()
    {
        WriteNewLog($"VideoAdContainer | onClose", false);
    }
}