using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text GoldView;
    public Text RubyView;
    public Text SapphaireView;
    public Text SapphaireView2;
    public Text DevilStoneView;
    public Text RebirthStoneView;
    public Text SkipCouponView;
    
    public Slider HpSlider;
    public Text HpText;

    public Transform Panels;
    public GameObject RankPanel;

    private void OnEnable()
    {
        GoldView.text = DataController.Instance.FormatGoldTwo(DataController.Instance.gold) + " G";
        RubyView.text = Math.Round(DataController.Instance.ruby, 0).ToString();
        SapphaireView.text = Math.Round(DataController.Instance.sapphire, 0).ToString();
        SapphaireView2.text = Math.Round(DataController.Instance.sapphire, 0).ToString();
        DevilStoneView.text = Math.Round(DataController.Instance.devilStone, 0).ToString();
        RebirthStoneView.text = Math.Round(DataController.Instance.rebirthStone, 0).ToString();
        SkipCouponView.text = Math.Round(DataController.Instance.skipCoupon, 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GoldView.text = DataController.Instance.FormatGoldTwo(DataController.Instance.gold) + " G";
        RubyView.text = Math.Round(DataController.Instance.ruby, 0).ToString();
        SapphaireView.text = Math.Round(DataController.Instance.sapphire, 0).ToString();
        SapphaireView2.text = Math.Round(DataController.Instance.sapphire, 0).ToString();
        DevilStoneView.text = Math.Round(DataController.Instance.devilStone, 0).ToString();
        RebirthStoneView.text = Math.Round(DataController.Instance.rebirthStone, 0).ToString();
        SkipCouponView.text = Math.Round(DataController.Instance.skipCoupon, 0).ToString();
        
        HpSlider.maxValue = DataController.Instance.GetPlayerHP();
        HpSlider.value = DataController.Instance.nowPlayerHP;
        HpText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.GetPlayerHP()) + "/" +
                      DataController.Instance.FormatGoldTwo(DataController.Instance.nowPlayerHP);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var i = 0;
            foreach (Transform panel in Panels)
            {
                if (!panel.gameObject.active)
                {
                    i++;
                    if (i == Panels.childCount && !RankPanel.active)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}