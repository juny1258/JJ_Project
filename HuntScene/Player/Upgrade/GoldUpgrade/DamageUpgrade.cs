using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DamageUpgrade : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Text ProductName;
    public Text PriceText;
    public Text UpgradeInfo;

    // 업그레이드 후 데미지
    [HideInInspector] public float damageByUpgrade;

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
            if (DataController.Instance.damageLevel <= 12000)
            {
                if (DataController.Instance.gold >= DataController.Instance.damageCost)
                {
                    DataController.Instance.gold -= DataController.Instance.damageCost;

                    DataController.Instance.damage += damageByUpgrade;

                    DataController.Instance.damageAddCost += (int) ((DataController.Instance.damageLevel) * 10);
                    DataController.Instance.damageCost += DataController.Instance.damageAddCost;

                    DataController.Instance.UpdateDamage();
                    DataController.Instance.UpdateCritical();

                    DataController.Instance.damageLevel++;

                    UpdateUpgrade();

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

    private void UpdateUpgrade()
    {
        damageByUpgrade = (int) (DataController.Instance.damageLevel * 3) + 1;
    }

    private void UpdateUI()
    {
        if (DataController.Instance.damageLevel <= 12000)
        {
            ProductName.text = LocalManager.Instance.Damage + "[+" + (DataController.Instance.damageLevel - 1) + "]";
            PriceText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.damageCost);

            UpgradeInfo.text = DataController.Instance.FormatGoldTwo(DataController.Instance.damage) + "\n-> " +
                               DataController.Instance.FormatGoldTwo(DataController.Instance.damage + damageByUpgrade);
        }
        else
        {
            ProductName.text = LocalManager.Instance.Damage + "[+" + (DataController.Instance.damageLevel - 1) + "]";
            PriceText.text = "MAX";

            UpgradeInfo.text = DataController.Instance.FormatGoldTwo(DataController.Instance.damage);
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