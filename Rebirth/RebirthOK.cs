using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthOK : MonoBehaviour
{
    public GameObject RebirthPanel;

    public Text RewardText;

    private int rewardRebirthStone = 100;

    private void OnEnable()
    {
        RewardText.text = "+ " + (float) (rewardRebirthStone * Math.Pow(5, DataController.Instance.rebirthLevel - 1))
                          * (DataController.Instance.collectionRebirthRising +
                             DataController.Instance.advancedRebirthPer);
    }

    public void RebirthButtonClick()
    {
        RebirthPanel.SetActive(false);

        EventManager.Instance.RebirtButtonClick();
    }
}