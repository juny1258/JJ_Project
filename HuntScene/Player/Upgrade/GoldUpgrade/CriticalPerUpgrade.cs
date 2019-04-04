using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CriticalPerUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Text ProductName;
    public Text PriceText;
    public Text UpgradeInfo;

    // 업그레이드 후 데미지
    [HideInInspector] public float criticalPerByUpgrade;

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
            if (DataController.Instance.criticalPerLevel < 61)
            {
                if (DataController.Instance.gold >= DataController.Instance.criticalCost)
                {
                    DataController.Instance.gold -= DataController.Instance.criticalCost;

                    DataController.Instance.criticalAddCost += (int) (DataController.Instance.criticalPerLevel * 80000);
                    DataController.Instance.criticalCost += DataController.Instance.criticalAddCost;

                    DataController.Instance.criticalPercent += 0.2f;

                    DataController.Instance.criticalPerLevel++;

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
        if (DataController.Instance.criticalPerLevel < 61)
        {
            ProductName.text = LocalManager.Instance.CriticalPer + "[+" + (DataController.Instance.criticalPerLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.criticalCost);

            UpgradeInfo.text = Math.Round(DataController.Instance.criticalPercent, 1) + "% -> " +
                               Math.Round(DataController.Instance.criticalPercent + 0.2f, 1) + "%";   
        }
        else
        {
            ProductName.text = LocalManager.Instance.CriticalPer + "[+" + (DataController.Instance.criticalPerLevel - 1) + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.criticalPercent, 1) + "%";
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