using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PetUpgrade5 : MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;

    public Image CostImage;
    public Text CostText;

    public Text ButtonText;

    public GameObject NotPurchasePanel;

    private int purchaseCost = 3000;

    private int startSkillCost = 200;

    private int cost;

    private void OnEnable()
    {
        cost = startSkillCost * (DataController.Instance.petSkill_5 + 1);
        
        UpdateUI();

        ViewNotPurchasePanel();

        EventManager.UpgradeSkillEvent += ViewNotPurchasePanel;
    }

    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.petSkill_5 == -1)
        {
            if (DataController.Instance.petStone >= purchaseCost)
            {
                DataController.Instance.petStone -= purchaseCost;

                DataController.Instance.petSkill_5++;
                cost = startSkillCost * (DataController.Instance.petSkill_5 + 1);
                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification(LocalManager.Instance.NoPetStone);
            }
        }
        else if (DataController.Instance.petSkill_5 < 25)
        {
            if (DataController.Instance.sapphire >= cost)
            {
                DataController.Instance.sapphire -= cost;

                DataController.Instance.petSkill_5++;
                DataController.Instance.pet_skill_5_damage += 0.5f;

                cost = startSkillCost * (DataController.Instance.petSkill_5 + 1);

                UpdateUI();
                EventManager.Instance.UpgradeSkill();
            }
            else
            {
                NotificationManager.Instance.SetNotification(LocalManager.Instance.LessSapphire);
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification(LocalManager.Instance.NoUpgrade);
        }
    }

    private void UpdateUI()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            if (DataController.Instance.petSkill_5 == -1)
            {
                TitleText.text = "번개 드래곤[+0]";
                InfoText.text = "공격력의 " + Math.Round(DataController.Instance.pet_skill_5_damage * 100, 0) + "%로 5번 공격";
                CostImage.sprite = Resources.Load("Gold/PetStone", typeof(Sprite)) as Sprite;
                CostText.text = purchaseCost.ToString();
                ButtonText.text = "구매하기";
            }
            else
            {
                TitleText.text = "번개 드래곤[+" + (DataController.Instance.petSkill_5) + "]";
                InfoText.text = "공격력의 " + Math.Round(DataController.Instance.pet_skill_5_damage * 100, 0) + "%로 5번 공격";
                CostImage.sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
                if (DataController.Instance.petSkill_5 < 25)
                {
                    CostText.text = cost.ToString();
                    ButtonText.text = "업그레이드";
                }
                else
                {
                    CostText.text = "MAX";
                    ButtonText.text = "MAX";
                }
            }
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            
            if (DataController.Instance.petSkill_5 == -1)
            {
                TitleText.text = "雷ドラゴン[+0]";
                InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.pet_skill_5_damage * 100, 0) + "%で5回攻撃";
                CostImage.sprite = Resources.Load("Gold/PetStone", typeof(Sprite)) as Sprite;
                CostText.text = purchaseCost.ToString();
                ButtonText.text = "購入";
            }
            else
            {
                TitleText.text = "雷ドラゴン[+" + (DataController.Instance.petSkill_5) + "]";
                InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.pet_skill_5_damage * 100, 0) + "%で5回攻撃";
                CostImage.sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
                if (DataController.Instance.petSkill_5 < 25)
                {
                    CostText.text = cost.ToString();
                    ButtonText.text = "強化";
                }
                else
                {
                    CostText.text = "MAX";
                    ButtonText.text = "MAX";
                }
            }
        }
        else
        {
            if (DataController.Instance.petSkill_5 == -1)
            {
                TitleText.text = "Lightning Dragon[+0]";
                InfoText.text = "5 attacks\n with " + Math.Round(DataController.Instance.pet_skill_5_damage * 100, 0) +
                                "% of damage";
                CostImage.sprite = Resources.Load("Gold/PetStone", typeof(Sprite)) as Sprite;
                CostText.text = purchaseCost.ToString();
                ButtonText.text = "Buy";
            }
            else
            {
                TitleText.text = "Lightning Dragon[+" + (DataController.Instance.petSkill_5) + "]";
                InfoText.text = "5 attacks\n with " + Math.Round(DataController.Instance.pet_skill_5_damage * 100, 0) +
                                "% of damage";
                CostImage.sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
                if (DataController.Instance.petSkill_5 < 25)
                {
                    CostText.text = cost.ToString();
                    ButtonText.text = "Upgrade";
                }
                else
                {
                    CostText.text = "MAX";
                    ButtonText.text = "MAX";
                }
            }
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.petSkill_4 < 5);
    }
}
