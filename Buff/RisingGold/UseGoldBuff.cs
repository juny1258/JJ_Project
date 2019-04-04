using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseGoldBuff : MonoBehaviour {
    public GameObject GoldBuffPanel;
    public Text PotionCountText;

    public Text InfoText;

    public Slider AutoExpSlider;
    public Text IndexText;

    public GameObject SealStoneGlow;

    public int index;

    private void OnEnable()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            InfoText.text = 180 + 30 * DataController.Instance.goldBuffLevel + "초 동안 결계석 획득량 1.5배";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            InfoText.text = 180 + 30 * DataController.Instance.goldBuffLevel + "秒間結界石獲得量1.5倍";
        }
        else
        {
            InfoText.text = "Increase gold 150% for  " + (180 + 30 * DataController.Instance.goldBuffLevel) + "sec";
        }
        
        if (index == 0)
        {
            PotionCountText.text = DataController.Instance.goldBuffPotion.ToString();   
        }
        
        AutoExpSlider.value = DataController.Instance.goldBuffIndex;
        IndexText.text = DataController.Instance.goldBuffIndex + "/10";

        EventManager.StartGoldRidingEvent += Reward;
    }

    public void UseItem()
    {
        // 물약 사용하고 자동공격
        DataController.Instance.goldBuffPotion--;
        
        StartAutoClick();
    }

    public void ShowAds()
    {
        // 광고 보고 오토클릭
        print("광고");
        PlayerPrefs.SetFloat("AdIndex", 2);
        AdMob.Instance.ShowGoldRisingAd();
    }

    private void Reward()
    {
        StartAutoClick();
    }

    public void StartAutoClick()
    {
        // 자동공격 시작
        DataController.Instance.goldBuffTime = 180 + 30 * DataController.Instance.goldBuffLevel;
        DataController.Instance.useGoldBuff = 1.5f;
        
        Invoke("StopGoldBuff", 180 + 30 * DataController.Instance.goldBuffLevel);
        
        // 물약 사용 횟수 증가
        DataController.Instance.goldBuffIndex++;
        if (DataController.Instance.goldBuffIndex == 10)
        {
            // 사용 횟수 10 달성 시 지속시간 증가
            DataController.Instance.goldBuffIndex = 0;
            DataController.Instance.goldBuffLevel++;
        }
        
        SealStoneGlow.SetActive(true);
        GoldBuffPanel.SetActive(false);
    }

    private void StopGoldBuff()
    {
        DataController.Instance.useGoldBuff = 1;
        SealStoneGlow.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.StartGoldRidingEvent -= Reward;
    }
}
