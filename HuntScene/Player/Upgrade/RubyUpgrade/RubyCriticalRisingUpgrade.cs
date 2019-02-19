using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubyCriticalRisingUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Text ProductName;
    public Text PriceText;
    public Text UpgradeInfo;

    private void Start()
    {
        UpdateUI();
    }

    private IEnumerator UpgradeCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            UpgradeButtonClick();

            yield return new WaitForSeconds(0.02f);
        }
    }

    public void UpgradeButtonClick()
    {
        if (DataController.Instance.rubyCriticalRisingLevel < 50)
        {
            if (DataController.Instance.ruby >= (DataController.Instance.rubyCriticalRisingLevel + 1) * 10)
            {
                DataController.Instance.ruby -= (DataController.Instance.rubyCriticalRisingLevel + 1) * 10;

                DataController.Instance.rubyCriticalRising += 0.02f;

                DataController.Instance.rubyCriticalRisingLevel++;
                
                DataController.Instance.UpdateCritical();

                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification("루비가 부족합니다.");
            }
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.rubyCriticalRisingLevel < 50)
        {
            ProductName.text = "추가 크리티컬 공격력[+" + DataController.Instance.rubyCriticalRisingLevel + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo((DataController.Instance.rubyCriticalRisingLevel + 1) * 10);

            UpgradeInfo.text = Math.Round(DataController.Instance.rubyCriticalRising * 100, 0) + "% -> " +
                               Math.Round((DataController.Instance.rubyCriticalRising + 0.02f) * 100, 0) + "%";
        }
        else
        {
            ProductName.text = "추가 크리티컬 공격력[+" + DataController.Instance.rubyCriticalRisingLevel + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.rubyCriticalRising * 100, 0) + "%";
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("UpgradeCoroutine");
    }
}
