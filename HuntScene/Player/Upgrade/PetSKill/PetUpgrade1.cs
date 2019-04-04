using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUpgrade1 : MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;

    public Image CostImage;
    public Text CostText;

    public Text ButtonText;

    private int purchaseCost = 300;

    private int startSkillCost = 80;

    private int cost;

    private void OnEnable()
    {
        cost = startSkillCost * (DataController.Instance.petSkill_1 + 1);

        UpdateUI();
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.petSkill_1 == -1)
        {
            if (DataController.Instance.petStone >= purchaseCost)
            {
                DataController.Instance.petStone -= purchaseCost;
                
                DataController.Instance.petSkill_1++;
                cost = startSkillCost * (DataController.Instance.petSkill_1 + 1);
                UpdateUI();
            }
            else
            {
                NotificationManager.Instance.SetNotification(LocalManager.Instance.NoPetStone);
            }
        }
        else if (DataController.Instance.petSkill_1 < 25)
        {
            if (DataController.Instance.sapphire >= cost)
            {
                DataController.Instance.sapphire -= cost;

                DataController.Instance.petSkill_1++;
                DataController.Instance.pet_skill_1_damage += 0.2f;

                cost = startSkillCost * (DataController.Instance.petSkill_1 + 1);

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
            
            if (DataController.Instance.petSkill_1 == -1)
            {
                TitleText.text = "파이어 해츨링[+0]";
                InfoText.text = "공격력의 " + Math.Round(DataController.Instance.pet_skill_1_damage * 100, 0) + "%로 3번 공격";
                CostImage.sprite = Resources.Load("Gold/PetStone", typeof(Sprite)) as Sprite;
                CostText.text = purchaseCost.ToString();
                ButtonText.text = "구매하기";
            }
            else
            {
                TitleText.text = "파이어 해츨링[+" + (DataController.Instance.petSkill_1) + "]";
                InfoText.text = "공격력의 " + Math.Round(DataController.Instance.pet_skill_1_damage * 100, 0) + "%로 3번 공격";
                CostImage.sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
                if (DataController.Instance.petSkill_1 < 25)
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
            
            if (DataController.Instance.petSkill_1 == -1)
            {
                TitleText.text = "花火ハッチリンc[+0]";
                InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.pet_skill_1_damage * 100, 0) + "%で3回攻撃";
                CostImage.sprite = Resources.Load("Gold/PetStone", typeof(Sprite)) as Sprite;
                CostText.text = purchaseCost.ToString();
                ButtonText.text = "購入";
            }
            else
            {
                TitleText.text = "花火ハッチリンc[+" + (DataController.Instance.petSkill_1) + "]";
                InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.pet_skill_1_damage * 100, 0) + "%で3回攻撃";
                CostImage.sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
                if (DataController.Instance.petSkill_1 < 25)
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
            
            if (DataController.Instance.petSkill_1 == -1)
            {
                TitleText.text = "Fire Haetling[+0]";
                InfoText.text = "3 attacks\n with " + Math.Round(DataController.Instance.pet_skill_1_damage * 100, 0) +
                                "% of damage";
                CostImage.sprite = Resources.Load("Gold/PetStone", typeof(Sprite)) as Sprite;
                CostText.text = purchaseCost.ToString();
                ButtonText.text = "Buy";
            }
            else
            {
                TitleText.text = "Fire Haetling[+" + (DataController.Instance.petSkill_1) + "]";
                InfoText.text = "3 attacks\n with " + Math.Round(DataController.Instance.pet_skill_1_damage * 100, 0) +
                                "% of damage";
                CostImage.sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
                if (DataController.Instance.petSkill_1 < 25)
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
}