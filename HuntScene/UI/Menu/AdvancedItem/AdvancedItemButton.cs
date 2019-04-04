using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedItemButton : MonoBehaviour
{
    public GameObject GetItemPanel;
    public Image ItemImage;
    public Text ItemInfoText;
    
    private string[] avilityStrings =
    {
        "공격력", "파우스트 공격력", "체력", "자동클릭 시간 감소", "크리티컬 확률",
        "크리티컬 데미지", "환생석 획득량", "분노 데미지",
        "공격력", "파우스트 공격력", "체력", "자동클릭 시간 감소", "크리티컬 확률",
        "크리티컬 데미지", "환생석 획득량", "분노 데미지"
    };

    private string[] avilityStrings2 =
    {
        "Damage", "Faust Damage", "Health ", "Autoclick Time Reduced", "Critical Probability",
        "Critical Damage", "Get RebirthStone", "Anger damage",
        "Damage", "Faust Damage", "Health ", "Autoclick Time Reduced", "Critical Probability",
        "Critical Damage", "Get RebirthStone", "Anger damage"
    };
    
    private string[] avilityStrings3 =
    {
        "攻撃力", "ファウスト攻撃力", "体力", "自動クリックの時間の減少", "クリティカル確率",
        "クリティカル攻撃力", "転生石獲得量", "怒り攻撃力",
        "攻撃力", "ファウスト攻撃力", "体力", "自動クリックの時間の減少", "クリティカル確率",
        "クリティカル攻撃力", "転生石獲得量", "怒り攻撃力"
    };

    private string[] name;
    private string[] avility;
    private string damage;

    private int[] price =
    {
        50, 100, 200, 400, 600, 800, 1000,
        1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500, 6000
    };

    public Text PriceText;

    private void Start()
    {
        EventManager.GetAdvancedItemEvent += GetItem;
    }

    private void OnDestroy()
    {
        EventManager.GetAdvancedItemEvent -= GetItem;
    }

    private void GetItem()
    {
        if (DataController.Instance.advancedItemBoxLevel < 16)
        {
            PriceText.text = price[DataController.Instance.advancedItemBoxLevel].ToString();   
        }
        else
        {
            PriceText.text = "MAX";
        }
    }

    private void OnEnable()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            avility = avilityStrings;
            damage = "데미지";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            avility = avilityStrings3;
            damage = "攻撃力";
        }
        else
        {
            avility = avilityStrings2;
            damage = "Damage";
        }
        
        if (DataController.Instance.advancedItemBoxLevel < 16)
        {
            PriceText.text = price[DataController.Instance.advancedItemBoxLevel].ToString();   
        }
        else
        {
            PriceText.text = "MAX";
        }
    }

    public void PurchaseItem()
    {
        if (DataController.Instance.advancedItemBoxLevel < 16)
        {
            if (DataController.Instance.rebirthStone >= price[DataController.Instance.advancedItemBoxLevel])
            {
                var randInt = Random.Range(0, 16);

                if (PlayerPrefs.GetInt("AdvancedCollectionItem_" + randInt, 0) == 0)
                {
                    DataController.Instance.rebirthStone -= price[DataController.Instance.advancedItemBoxLevel];

                    switch (randInt)
                    {
                        case 0:
                            DataController.Instance.advancedDamage += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 5%";
                            break;
                        case 1:
                            DataController.Instance.advancedFaustDamage += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 5%";
                            break;
                        case 2:
                            DataController.Instance.advancedHp += 0.04f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text =damage + " + 5%\n" + avility[randInt] + " + 4%";
                            break;
                        case 3:
                            DataController.Instance.advancedAutoTap -= 0.06f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 0.3%";
                            break;
                        case 4:
                            DataController.Instance.advancedCriticalPer += 1f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 1%";
                            break;
                        case 5:
                            DataController.Instance.advancedCriticalRising += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 5%";
                            break;
                        case 6:
                            DataController.Instance.advancedRebirthPer += 0.02f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 2%";
                            break;
                        case 7:
                            DataController.Instance.advancedAngerDamage += 0.03f;

                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 3%";
                            break;
                        case 8:
                            DataController.Instance.advancedDamage += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 5%";
                            break;
                        case 9:
                            DataController.Instance.advancedFaustDamage += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 5%";
                            break;
                        case 10:
                            DataController.Instance.advancedHp += 0.04f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text =damage + " + 5%\n" + avility[randInt] + " + 4%";
                            break;
                        case 11:
                            DataController.Instance.advancedAutoTap -= 0.02f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 0.3%";
                            break;
                        case 12:
                            DataController.Instance.advancedCriticalPer += 1f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 1%";
                            break;
                        case 13:
                            DataController.Instance.advancedCriticalRising += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 5%";
                            break;
                        case 14:
                            DataController.Instance.advancedRebirthPer += 0.02f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 2%";
                            break;
                        case 15:
                            DataController.Instance.advancedAngerDamage += 0.03f;

                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = damage + " + 5%\n" + avility[randInt] + " + 3%";
                            break;
                    }

                    DataController.Instance.advancedItemBoxLevel++;

                    GetItemPanel.SetActive(true);

                    DataController.Instance.advancedDamage += 0.05f;

                    print(DataController.Instance.advancedDamage);
                    PlayerPrefs.SetInt("AdvancedCollectionItem_" + randInt, 1);

                    DataController.Instance.UpdateDamage();
                    DataController.Instance.UpdateCritical();

                    DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

                    EventManager.Instance.GetAdvancedItem();
                }
                else
                {
                    if (Application.systemLanguage == SystemLanguage.Korean)
                    {
                        NotificationManager.Instance.SetNotification("중복되었습니다. 다시 시도해주세요.");
                    }
                    else if (Application.systemLanguage == SystemLanguage.Japanese)
                    {
                        NotificationManager.Instance.SetNotification("重複しました。再試行してください。");
                    }
                    else
                    {
                        NotificationManager.Instance.SetNotification("Duplicate. Please try again.");
                    }
                    
                }
            }
            else
            {
                if (Application.systemLanguage == SystemLanguage.Korean)
                {
                    NotificationManager.Instance.SetNotification("힘의 원천이 부족합니다.");
                }
                else if (Application.systemLanguage == SystemLanguage.Japanese)
                {
                    NotificationManager.Instance.SetNotification("超越の石不足します。");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("There are insufficient rebirth stone.");
                }
            }
        }
    }
}