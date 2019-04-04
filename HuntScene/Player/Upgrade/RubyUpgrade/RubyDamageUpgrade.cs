using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubyDamageUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.rubyRisingDamageLevel < 800)
        {
            if (DataController.Instance.ruby >= (DataController.Instance.rubyRisingDamageLevel + 1) * 10)
            {
                DataController.Instance.ruby -= (DataController.Instance.rubyRisingDamageLevel + 1) * 10;

                DataController.Instance.rubyRisingDamage += (DataController.Instance.rubyRisingDamageLevel + 1) * 0.01f;

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.rubyRisingDamageLevel++;

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
        if (DataController.Instance.rubyRisingDamageLevel < 800)
        {
            ProductName.text = LocalManager.Instance.Damage + "[+" + DataController.Instance.rubyRisingDamageLevel + "]";

            PriceText.text =
                DataController.Instance.FormatGoldTwo((DataController.Instance.rubyRisingDamageLevel + 1) * 10);

            UpgradeInfo.text = Math.Round(100 + DataController.Instance.rubyRisingDamage * 100, 0) +
                               "% -> " +
                               Math.Round(100 +
                                   (DataController.Instance.rubyRisingDamage + 
                                    (DataController.Instance.rubyRisingDamageLevel + 1) * 0.01f) * 100, 0) +
                               "%";
        }
        else
        {
            ProductName.text = LocalManager.Instance.Damage + "[+" + DataController.Instance.rubyRisingDamageLevel + "]";

            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(100 + DataController.Instance.rubyRisingDamage * 100, 0) +
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