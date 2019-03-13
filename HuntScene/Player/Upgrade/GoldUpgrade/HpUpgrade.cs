using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HpUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Text ProductName;
    public Text PriceText;
    public Text UpgradeInfo;

    // 업그레이드 후 데미지
    [HideInInspector] public float hpByUpgrade;

    private void OnEnable()
    {
        UpdateUpgrade();

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
            if (DataController.Instance.hpLevel <= 2500)
            {
                if (DataController.Instance.gold >= DataController.Instance.hpCost)
                {
                    DataController.Instance.gold -= DataController.Instance.hpCost;

                    DataController.Instance.playerHP += hpByUpgrade;

                    DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

                    DataController.Instance.hpAddCost += (int) (DataController.Instance.hpLevel * 10);
                    DataController.Instance.hpCost += DataController.Instance.hpAddCost;

                    DataController.Instance.hpLevel++;

                    UpdateUpgrade();

                    UpdateUI();
                }
                else
                {
                    NotificationManager.Instance.SetNotification("결계석이 부족합니다.");
                }
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("결계석의 레벨을 눌러 초월기를 사용하세요.");
        }
    }

    private void UpdateUpgrade()
    {
        hpByUpgrade = ((int) (DataController.Instance.hpLevel) + 1) * 30;
    }

    private void UpdateUI()
    {
        if (DataController.Instance.hpLevel <= 2500)
        {
            ProductName.text = "체력[+" + (DataController.Instance.hpLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.hpCost);

            UpgradeInfo.text = DataController.Instance.FormatGoldTwo(DataController.Instance.playerHP) + "\n-> " +
                               DataController.Instance.FormatGoldTwo(DataController.Instance.playerHP + hpByUpgrade);
        }
        else
        {
            ProductName.text = "체력[+" + (DataController.Instance.hpLevel - 1) + "]";
            PriceText.text = "MAX";

            UpgradeInfo.text = DataController.Instance.FormatGoldTwo(DataController.Instance.playerHP);
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