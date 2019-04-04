using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubyCriticalPerUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.rubyCriticalPerLevel < 50)
        {
            if (DataController.Instance.ruby >= (DataController.Instance.rubyCriticalPerLevel + 1) * 10)
            {
                DataController.Instance.ruby -= (DataController.Instance.rubyCriticalPerLevel + 1) * 10;

                DataController.Instance.rubyCriticalPer += 0.4f;
                
                DataController.Instance.UpdateCritical();

                DataController.Instance.rubyCriticalPerLevel++;

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
        if (DataController.Instance.rubyCriticalPerLevel < 50)
        {
            ProductName.text = LocalManager.Instance.CriticalPer + "[+" + DataController.Instance.rubyCriticalPerLevel + "]";

            PriceText.text =
                DataController.Instance.FormatGoldTwo((DataController.Instance.rubyCriticalPerLevel + 1) * 10);

            UpgradeInfo.text = Math.Round(DataController.Instance.rubyCriticalPer, 1) +
                               "% -> " +
                               Math.Round(DataController.Instance.rubyCriticalPer + 0.4f, 1) +
                               "%";
        }
        else
        {
            ProductName.text = LocalManager.Instance.CriticalPer + "[+" + DataController.Instance.rubyCriticalPerLevel + "]";

            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.rubyCriticalPer, 1) +
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
