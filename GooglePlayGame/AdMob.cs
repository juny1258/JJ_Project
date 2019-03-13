using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class AdMob : MonoBehaviour
{
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
    public RewardBasedVideoAd AutoClickAd;
    public RewardBasedVideoAd GoldRisingAd;
    public RewardBasedVideoAd PvpAd;

    private bool isAdsReady;


    private void Start()
    {
        MobileAds.Initialize("ca-app-pub-8345080599263513~3523715760");
        CompensationAd = RewardBasedVideoAd.Instance;
        AutoClickAd = RewardBasedVideoAd.Instance;
        GoldRisingAd = RewardBasedVideoAd.Instance;
        PvpAd = RewardBasedVideoAd.Instance;
        
        RequestMenuClickAd();
        RequestCompensationAd();
        RequestAutoClickAd();
        RequestGoldRisingAd();
        RequestPvpAd();

        _coroutine = ShowAds();

        InvokeRepeating("IsReady", 10, 600);
    }

    private void IsReady()
    {
        isAdsReady = false;
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    ///
    /// 
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

    private void RequestAutoClickAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8345080599263513/6325168143";
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        AdRequest request = new AdRequest.Builder().Build();

        AutoClickAd.LoadAd(request, adUnitId);

        AutoClickAd.OnAdClosed += HandleOnAutoClickAdAdClosed;
        AutoClickAd.OnAdRewarded += HandleOnAutoClickAdAdReward;
    }
    
    private void RequestGoldRisingAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8345080599263513/5942024764";
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        AdRequest request = new AdRequest.Builder().Build();

        GoldRisingAd.LoadAd(request, adUnitId);

        GoldRisingAd.OnAdClosed += HandleOnGoldRisingAdAdClosed;
        GoldRisingAd.OnAdRewarded += HandleOnGoldRisingAdAdReward;
    }
    
    private void RequestPvpAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8345080599263513/6465149814";
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        AdRequest request = new AdRequest.Builder().Build();

        PvpAd.LoadAd(request, adUnitId);

        PvpAd.OnAdClosed += HandleOnPvpAdClosed;
        PvpAd.OnAdRewarded += HandleOnPvpdReward;
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    ///
    /// 
    private void HandleOnMenuClickAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        MenuClickAd.Destroy();

        RequestMenuClickAd();
    }

    private static void HandleOnCompensationAdAdReward(object sender, EventArgs args)
    {
        if (PlayerPrefs.GetFloat("AdIndex", 0) == 0)
        {
            NotificationManager.Instance.SetNotification2("비접속 보상 획득!!");
            DataController.Instance.gold += DataController.Instance.compensationGold;   
        }
    }

    private static void HandleOnAutoClickAdAdReward(object sender, EventArgs args)
    {
        // 오토클릭
        if (PlayerPrefs.GetFloat("AdIndex", 0) == 1)
        {
            EventManager.Instance.StartAutoClick();
        }
    }
    
    private static void HandleOnGoldRisingAdAdReward(object sender, EventArgs args)
    {
        // 골드 버프
        if (PlayerPrefs.GetFloat("AdIndex", 0) == 2)
        {
            EventManager.Instance.StartGoldRising();
        }
    }
    
    private static void HandleOnPvpdReward(object sender, EventArgs args)
    {
        // 골드 버프
        if (PlayerPrefs.GetFloat("AdIndex", 0) == 3)
        {
            DataController.Instance.pvpCount += 10;
            NotificationManager.Instance.SetNotification2("pvp입장권 10개 증가!!");
            EventManager.Instance.PvpAds();
        }
    }

    private void HandleOnCompensationAdAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        CompensationAd.OnAdClosed -= HandleOnCompensationAdAdClosed;
        CompensationAd.OnAdRewarded -= HandleOnCompensationAdAdReward;

        RequestCompensationAd();
    }

    private void HandleOnAutoClickAdAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        AutoClickAd.OnAdClosed -= HandleOnAutoClickAdAdClosed;
        AutoClickAd.OnAdRewarded -= HandleOnAutoClickAdAdReward;

        RequestAutoClickAd();
    }
    
    private void HandleOnGoldRisingAdAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        GoldRisingAd.OnAdClosed -= HandleOnGoldRisingAdAdClosed;
        GoldRisingAd.OnAdRewarded -= HandleOnGoldRisingAdAdReward;

        RequestGoldRisingAd();
    }
    
    private void HandleOnPvpAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        PvpAd.OnAdClosed -= HandleOnPvpAdClosed;
        PvpAd.OnAdRewarded -= HandleOnPvpdReward;

        RequestGoldRisingAd();
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
        if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
        {
            StartCoroutine(_coroutine);
        }
        else
        {
            NotificationManager.Instance.SetNotification2("비접속 보상 획득!!");
            DataController.Instance.gold += DataController.Instance.compensationGold;
        }
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

    public void ShowAutoClickAd()
    {
        if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
        {
            if (!AutoClickAd.IsLoaded())
            {
                RequestAutoClickAd();
                return;
            }

            AutoClickAd.Show();
        }
        else
        {
            EventManager.Instance.StartAutoClick();
        }
    }
    
    public void ShowGoldRisingAd()
    {
        if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
        {
            if (!GoldRisingAd.IsLoaded())
            {
                RequestGoldRisingAd();
                return;
            }

            GoldRisingAd.Show();
        }
        else
        {
            EventManager.Instance.StartGoldRising();
        }
    }
    
    public void ShowPvpAd()
    {
        if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
        {
            if (!PvpAd.IsLoaded())
            {
                RequestPvpAd();
                return;
            }

            PvpAd.Show();
        }
        else
        {
            DataController.Instance.pvpCount += 10;
            NotificationManager.Instance.SetNotification2("pvp입장권 10개 증가!!");
            EventManager.Instance.PvpAds();
        }
    }
}