using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
//    public Text UpgradeInfo;
//
//    // 업그레이드 후 데미지
//    [HideInInspector] public float damageByUpgrade;
//    public float startDamageByUpgrade = 10;
//
//    // 현재 가격
//    [HideInInspector] public float currentCost;
//    public float startCurrentCost = 100;
//
//    // 업그레이드 후 클릭당 데미지 상승 비율
//    private float upgradePower = 1.12f;
//
//    // 업그레이드 후 업그레이드 가격 상승 비율
//    private float costPow = 1.5f;
//
//    private void Start()
//    {
//        UpdateUpgrade();
//
//        UpdateUI();
//    }
//
//    public void UpgradeButtonClick()
//    {
//        if (DataController.Instance.gold >= currentCost)
//        {
//            DataController.Instance.gold -= currentCost;
//
//            DataController.Instance.damage = damageByUpgrade;
//            if (DataController.Instance.isAnger)
//            {
//                DataController.Instance.masterDamage =
//                    DataController.Instance.damage * DataController.Instance.angerDamage;
//            }
//            else
//            {
//                DataController.Instance.masterDamage = DataController.Instance.damage;
//            }
//
//            DataController.Instance.upgradeLevel++;
//
//            UpdateUpgrade();
//
//            UpdateUI();
//        }
//    }
//
//    private void UpdateUpgrade()
//    {
//        damageByUpgrade = startDamageByUpgrade * Mathf.Pow(upgradePower, DataController.Instance.upgradeLevel);
//        currentCost = startCurrentCost * Mathf.Pow(costPow, DataController.Instance.upgradeLevel - 1);
//    }
//
//    private void UpdateUI()
//    {
//        UpgradeInfo.text = "가격 : " + DataController.Instance.FormatGoldTwo(currentCost) + "G" +
//                           "\n공격력 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.damage) +
//                           "\n다음 공격력 : " + DataController.Instance.FormatGoldTwo(damageByUpgrade);
//    }
}