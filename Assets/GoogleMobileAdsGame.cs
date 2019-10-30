using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

using System;
using UnityEngine.Events;

public class GoogleMobileAdsGame : MonoBehaviour {

    public BannerView bannerView;
    private RewardBasedVideoAd rewardBasedVideo;
    /*
     #elif UNITY_EDITOR
       string adUnitId = "VillageGameLevel";
       */

    public void Start()
    {
#if UNITY_EDITOR
        string appId = "ca-app-pub-2071661750275930~3645185753";
#elif UNITY_ANDROID
        string appId = "ca-app-pub-2071661750275930~3645185753";
#elif UNITY_IPHONE
                    string appId = "ca-app-pub-2071661750275930~3645185753";
#else
                    string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        

        this.RequestBanner();
        // Get singleton reward based video ad reference.
       // this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        //// Called when an ad request has successfully loaded.
        //rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        //// Called when an ad request failed to load.
        //rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        //// Called when an ad is shown.
        //rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        //// Called when the ad starts to play.
        //rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        //// Called when the user should be rewarded for watching a video.
        //rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        //// Called when the ad is closed.
        //rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        //// Called when the ad click caused the user to leave the application.
        //rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

       // this.RequestRewardBasedVideo();
    }


    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-2071661750275930/1091599633";
#elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-2071661750275930/1091599633";
#elif UNITY_IPHONE
                            string adUnitId = "ca-app-pub-2071661750275930/1091599633";
#else
                            string adUnitId = "unexpected_platform";
#endif

        // #if UNITY_EDITOR
        //        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        //#elif UNITY_ANDROID
        //                string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        //#elif UNITY_IPHONE
        //                            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        //#else
        //                            string adUnitId = "unexpected_platform";
        //#endif

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);





        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        // Create a 320x50 banner at the top of the screen.

        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build(); //when build for googleplay
        //AddTestDevice("52001d4aaef565f3").
        //AddTestDevice("52001d4aaef565f3").
        AdRequest request = new  AdRequest.Builder().Build();

        
        // Load the banner with the request.
        bannerView.LoadAd(request);

        bannerView.OnAdLoaded += HandleOnAdLoaded;


        Debug.Log("show banner");
        bannerView.Show();












    }


//    private void RequestRewardBasedVideo()
//    {
//#if UNITY_EDITOR
//        string adUnitId = "ca-app-pub-2071661750275930/5009010952";
//#elif UNITY_ANDROID
//        string adUnitId = "ca-app-pub-2071661750275930/5009010952";
//#elif UNITY_IPHONE
//                    string adUnitId = "ca-app-pub-2071661750275930/5009010952";
//#else
//                    string adUnitId = "unexpected_platform";
//#endif

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().AddTestDevice("52001d4eeaf565f3").Build();
//        // Load the rewarded video ad with the request.
//        this.rewardBasedVideo.LoadAd(request, adUnitId);
//    }








  //public void Revival()
  //  {
  //      if (rewardBasedVideo.IsLoaded())
  //      {
  //          Debug.Log("Show");
  //          rewardBasedVideo.Show();
  //      }
  //  }














    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        bannerView.Show();

    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    //public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    //}

    //public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MonoBehaviour.print(
    //        "HandleRewardBasedVideoFailedToLoad event received with message: "
    //                         + args.Message);
    //}

    //public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    //}

    //public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    //}

    //public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    //}

    //public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    //{
    //    string type = args.Type;
    //    double amount = args.Amount;
    //    MonoBehaviour.print(
    //        "HandleRewardBasedVideoRewarded event received for "
    //                    + amount.ToString() + " " + type);
    //}

    //public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    //}
}



