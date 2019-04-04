using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubyAngerDamageUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.rubyAngerDamageLevel < 50)
        {
            if (DataController.Instance.ruby >= (DataController.Instance.rubyAngerDamageLevel + 1) * 10)
            {
                DataController.Instance.ruby -= (DataController.Instance.rubyAngerDamageLevel + 1) * 10;

                DataController.Instance.rubyAngerDamage += 0.03f;

                DataController.Instance.rubyAngerDamageLevel++;
                
                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

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
        if (DataController.Instance.rubyAngerDamageLevel < 50)
        {
            ProductName.text = LocalManager.Instance.AngerDamage + "[+" + DataController.Instance.rubyAngerDamageLevel + "]";

            PriceText.text =
                DataController.Instance.FormatGoldTwo((DataController.Instance.rubyAngerDamageLevel + 1) * 10);

            UpgradeInfo.text = "+" + Math.Round(DataController.Instance.rubyAngerDamage * 100, 0) +
                               "% -> " +
                               "+" + Math.Round((DataController.Instance.rubyAngerDamage + 0.03f) * 100, 0) +
                               "%";
        }
        else
        {
            ProductName.text = LocalManager.Instance.AngerDamage + "[+" + DataController.Instance.rubyAngerDamageLevel + "]";

            PriceText.text = "Max";

            UpgradeInfo.text = "+" + Math.Round(DataController.Instance.rubyAngerDamage * 100, 0) +
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
