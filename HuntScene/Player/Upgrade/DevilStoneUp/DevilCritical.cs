﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DevilCritical : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        if (DataController.Instance.devilCriticalLevel < 41)
        {
            if (DataController.Instance.devilStone >= startCurrentCost * DataController.Instance.devilCriticalLevel)
            {
                DataController.Instance.devilStone -= startCurrentCost * DataController.Instance.devilCriticalLevel;

                DataController.Instance.devilCritical += 0.5f;

                DataController.Instance.UpdateCritical();

                DataController.Instance.devilCriticalLevel++;

                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification(LocalManager.Instance.LessDevilstone);
            }
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.devilCriticalLevel < 41)
        {
            ProductName.text = LocalManager.Instance.CriticalPer + "[+" + (DataController.Instance.devilCriticalLevel - 1) + "]";
            PriceText.text = Math.Round(startCurrentCost * DataController.Instance.devilCriticalLevel, 1).ToString();

            UpgradeInfo.text = Math.Round(DataController.Instance.devilCritical, 1) + "% -> " +
                               Math.Round(DataController.Instance.devilCritical + 0.5f, 1) + "%";
        }
        else
        {
            ProductName.text = LocalManager.Instance.CriticalPer + "[+" + (DataController.Instance.devilCriticalLevel - 1) + "]";
            PriceText.text = "Max";

            UpgradeInfo.text = Math.Round(DataController.Instance.devilCritical, 1) + "%";
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