using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedItem : MonoBehaviour
{
    public int index;

    public Text AvilityText1;
    public Text AvilityText2;

    public Text Price;

    private string[] names =
    {
        "파우스트의 뿔", "파우스트의 견장", "파우스트의 머리장식", "파우스트의 심장", "파우스트의 장갑",
        "창조주의 망치", "창조주의 갑옷", "지옥의 수갑",
        "힘의 반지", "용의 눈 반지", "마력 반지", "정령의 반지", "용의 눈물", "전설의 목걸이",
        "에메랄드 목걸이", "파라오의 목걸이"
    };

    private string[] names2 =
    {
        "Faust's Horns", "Faust's Strap", "Faust's Crown", "Faust's Heart", "Faust's Gloves",
        "Creator's Hammer", "Creator's Armor", "Hell's Handcuffs",
        "The Ring of Power", "The Ring of the Dragon", "The Ring of the Horse", "The Ring of the Spirit",
        "The Tears of the Dragon", "The necklace of the Legend",
        "Emerald's necklace", "Parao's necklace"
    };
    
    private string[] names3 =
    {
        "ファウストの角", "ファウストの紐", "ファウストの髪飾り", "ファウストの心臓", "ファウストの手袋",
        "創造のハンマー", "創造の鎧", "地獄の手錠",
        "力のリング", "用の目リング", "魔力リング", "精霊の指輪", "龍の涙", "伝説のネックレス",
        "エメラルドネックレス", "ファラオのネックレス"
    };

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

    private float[] avilityRising =
    {
        5, 5, 4, 3f, 1,
        5, 2, 3,
        5, 5, 4, 1f, 1,
        5, 2, 3
    };

    // 공격력
    // 체력
    // 결계석 획득량 증가
    // 크리티컬 확률
    // 크리티컬 데미지
    // 사파이어 획득량
    // 스킬 쿨타임 감소(박쥐 토네이도 그림자분신 지진 메테오 빅뱅)
    // 분노 시간 증가
    // 분노 데미지 증가
    // 확률적으로 에메랄드 획득량 2배
    // 확률적으로 루비 획득량 2배
    // 확률적으로 결계석 획득량 2배
    // 환생 

    private void Start()
    {
        EventManager.GetAdvancedItemEvent += Setting;
    }

    private void OnDestroy()
    {
        EventManager.GetAdvancedItemEvent -= Setting;
    }

    public void Setting()
    {
        AvilityText1.text = name[index] + "(+" +
                            PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + ")";

        AvilityText2.text = damage + " + " + 5 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + "%\n" +
                            avility[index] +
                            " + " + avilityRising[index] *
                            PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + "%";

        if (PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) < 20)
        {
            Price.text = (50 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0)).ToString();
        }
        else
        {
            Price.text = "MAX";
        }
    }

    private void OnEnable()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            name = names;
            avility = avilityStrings;
            damage = "데미지";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            name = names3;
            avility = avilityStrings3;
            damage = "攻撃力";
        }
        else
        {
            name = names2;
            avility = avilityStrings2;
            damage = "Damage";
        }

        AvilityText1.text = name[index] + "(+" +
                            PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + ")";

        AvilityText2.text = damage + " + " + 5 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + "%\n" +
                            avility[index] +
                            " + " + avilityRising[index] *
                            PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + "%";

        if (PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) < 20)
        {
            Price.text = (50 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0)).ToString();
        }
        else
        {
            Price.text = "MAX";
        }
    }

    public void UpgradeButtonClick()
    {
        if (PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) < 20)
        {
            if (DataController.Instance.rebirthStone >= 50 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0))
            {
                DataController.Instance.rebirthStone -= 50 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0);

                switch (index)
                {
                    case 0:
                        DataController.Instance.advancedDamage += 0.05f;
                        break;
                    case 1:
                        DataController.Instance.advancedFaustDamage += 0.05f;
                        break;
                    case 2:
                        DataController.Instance.advancedHp += 0.04f;
                        break;
                    case 3:
                        DataController.Instance.advancedAutoTap -= 0.06f;
                        break;
                    case 4:
                        DataController.Instance.advancedCriticalPer += 1f;
                        break;
                    case 5:
                        DataController.Instance.advancedCriticalRising += 0.05f;
                        break;
                    case 6:
                        DataController.Instance.advancedRebirthPer += 0.02f;
                        break;
                    case 7:
                        DataController.Instance.advancedAngerDamage += 0.03f;
                        break;
                    case 8:
                        DataController.Instance.advancedDamage += 0.05f;
                        break;
                    case 9:
                        DataController.Instance.advancedFaustDamage += 0.05f;
                        break;
                    case 10:
                        DataController.Instance.advancedHp += 0.04f;
                        break;
                    case 11:
                        DataController.Instance.advancedAutoTap -= 0.02f;
                        break;
                    case 12:
                        DataController.Instance.advancedCriticalPer += 1f;
                        break;
                    case 13:
                        DataController.Instance.advancedCriticalRising += 0.05f;
                        break;
                    case 14:
                        DataController.Instance.advancedRebirthPer += 0.02f;
                        break;
                    case 15:
                        DataController.Instance.advancedAngerDamage += 0.03f;
                        break;
                }

                DataController.Instance.advancedDamage += 0.05f;
                print(DataController.Instance.advancedDamage);

                PlayerPrefs.SetInt("AdvancedCollectionItem_" + index,
                    PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + 1);

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

                EventManager.Instance.GetAdvancedItem();
            }
            else
            {
                // 환생석 부족
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
        else
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                NotificationManager.Instance.SetNotification("더 이상 업그레이드 할 수 없습니다.");
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                NotificationManager.Instance.SetNotification("これ以上アップグレードすることができません。");
            }
            else
            {
                NotificationManager.Instance.SetNotification("You can't upgrade anymore");
            }
        }
    }
}