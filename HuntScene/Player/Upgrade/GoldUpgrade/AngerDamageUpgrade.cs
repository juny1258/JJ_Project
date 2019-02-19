using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AngerDamageUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.angerDamageLevel < 51)
        {
            if (DataController.Instance.gold >= DataController.Instance.angerDamageCost)
            {
                DataController.Instance.gold -= DataController.Instance.angerDamageCost;

                DataController.Instance.angerDamageAddCost += (int) (DataController.Instance.angerDamageLevel * 50000);
                DataController.Instance.angerDamageCost += DataController.Instance.angerDamageAddCost;

                DataController.Instance.angerDamage += 0.01f;
                
                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.angerDamageLevel++;

                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification("결계석이 부족합니다.");
            }
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.angerDamageLevel < 51)
        {
            ProductName.text = "분노 데미지[+" + (DataController.Instance.angerDamageLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.angerDamageCost);

            UpgradeInfo.text = Math.Round(DataController.Instance.angerDamage, 2) * 100 + "% -> " +
                               Math.Round(DataController.Instance.angerDamage + 0.01f, 2) * 100 + "%";   
        }
        else
        {
            ProductName.text = "분노 데미지[+" + (DataController.Instance.angerDamageLevel - 1) + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.angerDamage, 2) * 100 + "%";
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
