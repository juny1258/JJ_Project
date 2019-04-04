using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AngerTimeUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
            if (DataController.Instance.angerTimeLevel < 51)
            {
                if (DataController.Instance.gold >= DataController.Instance.angerTimeCost)
                {
                    DataController.Instance.gold -= DataController.Instance.angerTimeCost;

                    DataController.Instance.angerTimeAddCost += (int) (DataController.Instance.angerTimeLevel * 50000);
                    DataController.Instance.angerTimeCost += DataController.Instance.angerTimeAddCost;

                    DataController.Instance.angerTime += 0.1f;

                    DataController.Instance.angerTimeLevel++;

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
        if (DataController.Instance.angerTimeLevel < 51)
        {
            ProductName.text = LocalManager.Instance.AngerTime + "[+" + (DataController.Instance.angerTimeLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.angerTimeCost);

            UpgradeInfo.text = Math.Round(DataController.Instance.angerTime, 1) + "s -> " +
                               Math.Round(DataController.Instance.angerTime + 0.1f, 1) + "s";   
        }
        else
        {
            ProductName.text = LocalManager.Instance.AngerTime + "[+" + (DataController.Instance.angerTimeLevel - 1) + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.angerTime, 1) + "s";
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
