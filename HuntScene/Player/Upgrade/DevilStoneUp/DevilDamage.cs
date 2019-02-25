using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DevilDamage : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Text ProductName;
    public Text PriceText;
    public Text UpgradeInfo;

    private float startCurrentCost = 10;

    // 업그레이드 후 데미지
    [HideInInspector] public float damageByUpgrade;

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
        if (DataController.Instance.devilDamageLevel <= 100)
        {
            if (DataController.Instance.devilStone >= startCurrentCost * DataController.Instance.devilDamageLevel)
            {
                DataController.Instance.devilStone -= startCurrentCost * DataController.Instance.devilDamageLevel;

                DataController.Instance.devilDamage += 0.03f * DataController.Instance.devilDamageLevel;

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.devilDamageLevel++;

                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification("데빌스톤이 부족합니다.");
            }
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.devilDamageLevel <= 100)
        {
            ProductName.text = "공격력[+" + (DataController.Instance.devilDamageLevel - 1) + "]";
            PriceText.text = Math.Round(startCurrentCost * DataController.Instance.devilDamageLevel, 0).ToString();

            UpgradeInfo.text = Math.Round(DataController.Instance.devilDamage * 100, 0) + "% -> " +
                               Math.Round((DataController.Instance.devilDamage
                                           + 0.03f * DataController.Instance.devilDamageLevel) * 100, 0) + "%";   
        }
        else
        {
            ProductName.text = "공격력[+" + (DataController.Instance.devilDamageLevel - 1) + "]";
            PriceText.text = "MAX";

            UpgradeInfo.text = Math.Round(DataController.Instance.devilDamage * 100, 0) + "%";
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