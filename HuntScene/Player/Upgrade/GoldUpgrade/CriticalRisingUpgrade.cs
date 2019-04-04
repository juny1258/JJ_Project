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
                    NotificationManager.Instance.SetNotification(LocalManager.Instance.LessGold);
                }
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification(LocalManager.Instance.UseRebirth);
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.criticalRisingLevel < 61)
        {
            ProductName.text = LocalManager.Instance.CriticalRising + "[+" + (DataController.Instance.criticalRisingLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.criticalRisingCost);

            UpgradeInfo.text = DataController.Instance.criticalRising * 100 + "% -> " +
                               (DataController.Instance.criticalRising + 0.01f) * 100 + "%";
        }
        else
        {
            ProductName.text = LocalManager.Instance.CriticalRising + "[+" + (DataController.Instance.criticalRisingLevel - 1) + "]";
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