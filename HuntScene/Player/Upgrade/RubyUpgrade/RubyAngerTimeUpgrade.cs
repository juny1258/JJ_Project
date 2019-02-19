using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubyAngerTimeUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.rubyAngerTimeLevel < 50)
        {
            if (DataController.Instance.ruby >= (DataController.Instance.rubyAngerTimeLevel + 1) * 10)
            {
                DataController.Instance.ruby -= (DataController.Instance.rubyAngerTimeLevel + 1) * 10;

                DataController.Instance.rubyAngerTime += 0.01f;

                DataController.Instance.rubyAngerTimeLevel++;

                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification("루비가 부족합니다.");
            }
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.rubyAngerTimeLevel < 50)
        {
            ProductName.text = "분노 지속시간[+" + DataController.Instance.rubyAngerTimeLevel + "]";

            PriceText.text =
                DataController.Instance.FormatGoldTwo((DataController.Instance.rubyAngerTimeLevel + 1) * 10);

            UpgradeInfo.text = "+" + Math.Round(DataController.Instance.rubyAngerTime * 100, 0) +
                               "% -> " +
                               "+" + Math.Round((DataController.Instance.rubyAngerTime + 0.01f) * 100, 0) +
                               "%";
        }
        else
        {
            ProductName.text = "분노 지속시간[+" + DataController.Instance.rubyAngerTimeLevel + "]";

            PriceText.text = "Max";

            UpgradeInfo.text = "+" + Math.Round(DataController.Instance.rubyAngerTime * 100, 0) +
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
