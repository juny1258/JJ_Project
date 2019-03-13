using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CriticalRisingUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Text ProductName;
    public Text PriceText;
    public Text UpgradeInfo;

    private void OnEnable()
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
        if (DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel == 0)
        {
            if (DataController.Instance.criticalRisingLevel < 61)
            {
                if (DataController.Instance.gold >= DataController.Instance.criticalRisingCost)
                {
                    DataController.Instance.gold -= DataController.Instance.criticalRisingCost;

                    DataController.Instance.criticalRisingAddCost +=
                        (int) (DataController.Instance.criticalRisingLevel * 80000);
                    DataController.Instance.criticalRisingCost += DataController.Instance.criticalRisingAddCost;

                    DataController.Instance.criticalRising += 0.01f;

                    DataController.Instance.UpdateCritical();

                    DataController.Instance.criticalRisingLevel++;

                    UpdateUI();
                }
                else
                {
                    NotificationManager.Instance.SetNotification("결계석이 부족합니다.");
                }
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("결계석의 레벨을 눌러 초월기를 사용하세요.");
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.criticalRisingLevel < 61)
        {
            ProductName.text = "크리티컬 공격력[+" + (DataController.Instance.criticalRisingLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.criticalRisingCost);

            UpgradeInfo.text = DataController.Instance.criticalRising * 100 + "% -> " +
                               (DataController.Instance.criticalRising + 0.01f) * 100 + "%";
        }
        else
        {
            ProductName.text = "크리티컬 공격력[+" + (DataController.Instance.criticalRisingLevel - 1) + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.criticalRising * 100) + "%";
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