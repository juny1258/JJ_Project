using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DevilCriticalDamage : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.devilCriticalRisingLevel < 41)
        {
            if (DataController.Instance.devilStone >= startCurrentCost * DataController.Instance.devilCriticalRisingLevel)
            {
                DataController.Instance.devilStone -= startCurrentCost * DataController.Instance.devilCriticalRisingLevel;

                DataController.Instance.devilCriticalRising += 0.03f;

                DataController.Instance.UpdateCritical();

                DataController.Instance.devilCriticalRisingLevel++;

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
        if (DataController.Instance.devilCriticalRisingLevel < 41)
        {
            ProductName.text = "크리티컬 데미지[+" + (DataController.Instance.devilCriticalRisingLevel - 1) + "]";
            PriceText.text = Math.Round(startCurrentCost * DataController.Instance.devilCriticalRisingLevel, 1).ToString();

            UpgradeInfo.text = Math.Round(DataController.Instance.devilCriticalRising * 100, 1) + "% -> " +
                               Math.Round((DataController.Instance.devilCriticalRising
                                           + 0.03f) * 100, 1) + "%";
        }
        else
        {
            ProductName.text = "크리티컬 데미지[+" + (DataController.Instance.devilCriticalRisingLevel - 1) + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.devilCriticalRising * 100, 1) + "%";
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
