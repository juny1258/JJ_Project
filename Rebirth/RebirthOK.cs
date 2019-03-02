using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthOK : MonoBehaviour
{
    public GameObject RebirthPanel;

    public Text RewardText;
    public Text PriceText;

    public int index;

    private float[] rewardRebirthStone =
    {
        450, 700, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000,
        9000, 10000, 11500, 13000
    };

    private int[] advancedRuby =
    {
        200, 300, 400, 500, 800, 1000, 1500, 2000, 2500, 3000,
        3500, 4000, 4500, 5000
    };

    private void OnEnable()
    {
        RewardText.text = "+ " + rewardRebirthStone[DataController.Instance.rebirthLevel-1]
                          * (DataController.Instance.collectionRebirthRising +
                             DataController.Instance.advancedRebirthPer);

        if (index == 1)
        {
            PriceText.text = "X " + advancedRuby[DataController.Instance.nowRebirthLevel];   
        }
    }

    public void RebirthButtonClick()
    {
        RebirthPanel.SetActive(false);

        EventManager.Instance.RebirtButtonClick();
    }

    public void AdvancedRebirthButton()
    {
        if (DataController.Instance.ruby >= advancedRuby[DataController.Instance.nowRebirthLevel])
        {
            DataController.Instance.ruby -= advancedRuby[DataController.Instance.nowRebirthLevel];
            
            RebirthPanel.SetActive(false);

            DataController.Instance.isAdvancedRebirth = true;

            EventManager.Instance.RebirtButtonClick();
        }
    }
}