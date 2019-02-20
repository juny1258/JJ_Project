using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthOK : MonoBehaviour
{
    public GameObject RebirthPanel;

    public Text RewardText;

    private float[] rewardRebirthStone =
    {
        450, 700, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000,
        9000, 10000, 11500, 13000
    };

    private void OnEnable()
    {
        RewardText.text = "+ " + rewardRebirthStone[DataController.Instance.rebirthLevel-1]
                          * (DataController.Instance.collectionRebirthRising +
                             DataController.Instance.advancedRebirthPer);
    }

    public void RebirthButtonClick()
    {
        RebirthPanel.SetActive(false);

        EventManager.Instance.RebirtButtonClick();
    }
}