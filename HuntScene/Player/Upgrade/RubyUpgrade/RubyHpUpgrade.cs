using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubyHpUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.rubyRisingHPLevel < 300)
        {
            if (DataController.Instance.ruby >= (DataController.Instance.rubyRisingHPLevel + 1) * 10)
            {
                DataController.Instance.ruby -= (DataController.Instance.rubyRisingHPLevel + 1) * 10;

                DataController.Instance.rubyRisingHP += (DataController.Instance.rubyRisingHPLevel + 1) * 0.006f;

                DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

                DataController.Instance.rubyRisingHPLevel++;

                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification(LocalManager.Instance.LessRuby);
            }
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.rubyRisingHPLevel < 300)
        {
            ProductName.text = LocalManager.Instance.Hp + "[+" + DataController.Instance.rubyRisingHPLevel + "]";

            PriceText.text =
                DataController.Instance.FormatGoldTwo((DataController.Instance.rubyRisingHPLevel + 1) * 10);

            UpgradeInfo.text = Math.Round(DataController.Instance.rubyRisingHP * 100, 1) +
                               "% -> " +
                               Math.Round(
                                   (DataController.Instance.rubyRisingHP +
                                    (DataController.Instance.rubyRisingHPLevel + 1) * 0.006f) * 100, 1) +
                               "%";
        }
        else
        {
            ProductName.text = LocalManager.Instance.Hp + "[+" + DataController.Instance.rubyRisingHPLevel + "]";

            PriceText.text = "Max";

            UpgradeInfo.text = Math.Truncate(DataController.Instance.rubyRisingHP * 100) +
                               "%";
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