using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGoldRisingPanel : MonoBehaviour
{
    // 비활성화 시 레벨, 활성화 시 시간 표시
    public Text LevelText;

    public GameObject GoldBuff1;
    public GameObject GoldBuff2;

    private void Start()
    {
        DataController.Instance.goldBuffPotion = 0;
    }

    public void OnClick()
    {
        if (DataController.Instance.useGoldBuff == 1)
        {
            if (DataController.Instance.goldBuffPotion > 0)
            {
                // 물약이 있을 때
                GoldBuff2.SetActive(true);
            }
            else
            {
                GoldBuff1.SetActive(true);
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("이미 사용중입니다.");
        }
    }

    private void Update()
    {
        if (DataController.Instance.useGoldBuff == 1.5f)
        {
            DataController.Instance.goldBuffTime -= Time.deltaTime;
            var min = (int) DataController.Instance.goldBuffTime / 60;
            var sec = (int) DataController.Instance.goldBuffTime - 60 * min;
            LevelText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            LevelText.text = "Lv. " + (DataController.Instance.goldBuffLevel + 1);
        }
    }
}