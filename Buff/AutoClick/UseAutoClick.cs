using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAutoClick : MonoBehaviour
{
    public GameObject AutoClickPanel;
    public Text PotionCountText;

    public Text InfoText;

    public Slider AutoExpSlider;
    public Text IndexText;

    public int index;

    private void OnEnable()
    {
        InfoText.text = 180 + 30 * DataController.Instance.autoClickLevel + "초 동안 자동으로 공격합니다.";
        if (index == 0)
        {
            PotionCountText.text = DataController.Instance.autoClickPotion.ToString();   
        }
        
        AutoExpSlider.value = DataController.Instance.autoClickIndex;
        IndexText.text = DataController.Instance.autoClickIndex + "/10";
        
        EventManager.StartAutoClickEvent += Reward;
    }

    public void UseItem()
    {
        // 물약 사용하고 자동공격
        DataController.Instance.autoClickPotion--;
        
        StartAutoClick();
    }

    public void ShowAds()
    {
        // 광고 보고 오토클릭
        print("광고");
        AdMob.Instance.ShowAutoClickAd();
    }

    private void Reward()
    {
        StartAutoClick();
    }

    private void StartAutoClick()
    {
        // 자동공격 시작
        DataController.Instance.autoClickTime = 180 + 30 * DataController.Instance.autoClickLevel;
        DataController.Instance.useAutoClick = true;

        // 물약 사용 횟수 증가
        DataController.Instance.autoClickIndex++;
        if (DataController.Instance.autoClickIndex == 10)
        {
            // 사용 횟수 10 달성 시 지속시간 증가
            DataController.Instance.autoClickIndex = 0;
            DataController.Instance.autoClickLevel++;
        }

        // 자동공격 이벤트 호출 (UIManager에서 정령의 축복 이펙트 시작)
        EventManager.Instance.AutoClick();
        AutoClickPanel.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.StartAutoClickEvent -= Reward;
    }
}