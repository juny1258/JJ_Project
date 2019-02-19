﻿using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class AdMob : MonoBehaviour {

	private static AdMob _instance;

    public static AdMob Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<AdMob>();

            return _instance;
        }
    }

    private IEnumerator _coroutine;

    public InterstitialAd MenuClickAd;
    public RewardBasedVideoAd CompensationAd;

    private bool isAdsReady;


    private void Start()
    {
        MobileAds.Initialize("ca-app-pub-8345080599263513~3523715760");
        CompensationAd = RewardBasedVideoAd.Instance;

        RequestMenuClickAd();
        RequestCompensationAd();

        _coroutine = ShowAds();
        
        InvokeRepeating("IsReady", 0, 300);
    }

    private void IsReady()
    {
        isAdsReady = true;
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    
    private void RequestMenuClickAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8345080599263513/9312843468";
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        MenuClickAd = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();

        MenuClickAd.LoadAd(request);

        MenuClickAd.OnAdClosed += HandleOnMenuClickAdClosed;
    }
    
    private void RequestCompensationAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8345080599263513/2032995530";
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        AdRequest request = new AdRequest.Builder().Build();

        CompensationAd.LoadAd(request, adUnitId);

        CompensationAd.OnAdClosed += HandleOnCompensationAdAdClosed;
        CompensationAd.OnAdRewarded += HandleOnCompensationAdAdReward;
    }
    
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>

    private void HandleOnMenuClickAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        MenuClickAd.Destroy();

        RequestMenuClickAd();
    }
    
    private void HandleOnCompensationAdAdReward(object sender, EventArgs args)
    {
        DataController.Instance.gold += DataController.Instance.compensationGold;
    }

    private void HandleOnCompensationAdAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        CompensationAd.OnAdClosed -= HandleOnCompensationAdAdClosed;
        CompensationAd.OnAdRewarded -= HandleOnCompensationAdAdReward;

        RequestCompensationAd();
    }

    public void ShowMenuClickAd()
    {
        if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
        {
            if (isAdsReady)
            {
                if (!MenuClickAd.IsLoaded())
                {
                    RequestMenuClickAd();
                    return;
                }

                MenuClickAd.Show();
                
                isAdsReady = false;
            }
        }
    }

    public void ShowCompensationAd()
    {
        StartCoroutine(_coroutine);
    }

    private IEnumerator ShowAds()
    {
        int i = 0;
        while (true)
        {
            if (CompensationAd.IsLoaded())
            {
                CompensationAd.Show();
                StopCoroutine(_coroutine);
            }

            if (i > 20)
            {
                StopCoroutine(_coroutine);
            }

            i++;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
