using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GetItemButton : MonoBehaviour
{
    public GameObject GetItemPanel;
    public Image ItemImage;
    public Text ItemInfoText;

    private string[] avilityStrings =
    {
        "체력", "크리티컬 확률", "분노 시간", "결계석 획득량", "스킬 쿨타임 감소",
        "분노 데미지", "루비 보상 2배\n획득 확률", "사파이어 보상 2배\n획득 확률", "결계석 획득량", "데빌스톤 보상 2배\n획득확률",
        "환생석 획득량", "크리티컬 데미지", "공격력", "파우스트 공격력", "파우스트 공격력",
        "파우스트 공격력"
    };
    
    private string[] avilityStrings2 =
    {
        "Health", "Critical Probability", "Anger Time", "Rising Gold", "Reduced Cooltime",
        "Anger Damage", "Ruby Compensation\nDouble", "Sapphire Compensation\nDouble", "Rising Gold",
        "Devil Stone Compensation\nDouble",
        "Amount of Rebirth Stone", "Critical Damage", "Damage", "Faust Damage", "Faust Damage",
        "Faust Damage"
    };
    
    private string[] avilityStrings3 =
    {
        "体力", "クリティカル確率", "怒りの時間", "お金獲得量", "スキル待機時間の短縮",
        "怒りの攻撃力", "ルビー報酬2倍\n獲得確率", "サファイア補償2倍\n獲得確率", "お金獲得量", "悪魔の石補償2倍\n獲得確率",
        "超越の石獲得量", "クリティカル攻撃力", "攻撃力", "ファウスト攻撃力", "ファウスト攻撃力",
        "ファウスト攻撃力"
    };

    public void OnPurchaseItem()
    {
        if (DataController.Instance.ruby >= 200)
        {
            string[] strings;
            string damage;

            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                strings = avilityStrings;
                damage = "공격력";
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                strings = avilityStrings3;
                damage = "攻撃力";
            }
            else
            {
                strings = avilityStrings2;
                damage = "Damage";
            }
            
            var random = new Random();

            var randInt = random.Next(0, 16);

            if (PlayerPrefs.GetInt("CollectionItem_" + randInt, 0) < 20)
            {
                DataController.Instance.ruby -= 200;
                // 뽑은 유물이 20개를 넘지 않았을 때
                switch (randInt)
                {
                    case 0:
                        DataController.Instance.collectionHp += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 1:
                        DataController.Instance.collectionCriticalPer += 0.5f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 0.5%";
                        break;
                    case 2:
                        DataController.Instance.collectionAngerTime += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 3:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 4:
                        DataController.Instance.collectionCoolTime += 2;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 5:
                        DataController.Instance.collectionAngerDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 6:
                        DataController.Instance.collectionRubyRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 7:
                        DataController.Instance.collectionSappaireRising += 1;

                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 8:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 9:
                        DataController.Instance.collectionDevilStoneRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 10:
                        DataController.Instance.collectionRebirthRising += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 11:
                        DataController.Instance.collectionCriticalDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 3%";
                        break;
                    case 12:
                        DataController.Instance.collectionDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 3%";
                        break;
                    case 13:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 14:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 15:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                }

                GetItemPanel.SetActive(true);

                DataController.Instance.collectionDamage += 0.03f;
                PlayerPrefs.SetInt("CollectionItem_" + randInt, PlayerPrefs.GetInt("CollectionItem_" + randInt) + 1);

                if (Social.localUser.authenticated)
                {
                    if (DataController.Instance.relicCount == 0)
                    {
                        Social.ReportProgress(GPGSIds.achievement_relic_acquisition, 100f, isSuccess =>
                        {
                        });
                    }

                    Social.ReportScore(DataController.Instance.relicCount, GPGSIds.leaderboard_5, success =>
                    {
                        if (success)
                        {
                            print("Success");
                        }
                    });
                }


                DataController.Instance.relicCount++;

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

                EventManager.Instance.GetCollectionItem();
            }
            else
            {
                // 유물이 20개 이상일 경우 다시 돌리기 및 취소
                if (Application.systemLanguage == SystemLanguage.Korean)
                {
                    NotificationManager.Instance.SetNotification("최대 갯수를 넘었습니다. 다시 시도해주세요.");
                }
                else if (Application.systemLanguage == SystemLanguage.Japanese)
                {
                    NotificationManager.Instance.SetNotification("最大数を超えました。再試行してください。");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("The maximum item index. Please try again.");
                }
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification(LocalManager.Instance.LessRuby);
        }
    }

    public void OnPurchaseItem2()
    {
        if (DataController.Instance.sapphire >= 100)
        {
            string[] strings;
            string damage;

            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                strings = avilityStrings;
                damage = "공격력";
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                strings = avilityStrings3;
                damage = "攻撃力";
            }
            else
            {
                strings = avilityStrings2;
                damage = "Damage";
            }
            
            var random = new Random();

            var randInt = random.Next(0, 16);

            if (PlayerPrefs.GetInt("CollectionItem_" + randInt, 0) < 20)
            {
                DataController.Instance.sapphire -= 100;
                // 뽑은 유물이 20개를 넘지 않았을 때
                switch (randInt)
                {
                    case 0:
                        DataController.Instance.collectionHp += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 1:
                        DataController.Instance.collectionCriticalPer += 0.5f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 0.5%";
                        break;
                    case 2:
                        DataController.Instance.collectionAngerTime += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 3:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 4:
                        DataController.Instance.collectionCoolTime += 2;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 5:
                        DataController.Instance.collectionAngerDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 6:
                        DataController.Instance.collectionRubyRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 7:
                        DataController.Instance.collectionSappaireRising += 1;

                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 8:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 9:
                        DataController.Instance.collectionDevilStoneRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 1%";
                        break;
                    case 10:
                        DataController.Instance.collectionRebirthRising += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 11:
                        DataController.Instance.collectionCriticalDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 3%";
                        break;
                    case 12:
                        DataController.Instance.collectionDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 3%";
                        break;
                    case 13:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 14:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                    case 15:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = damage + " + 3%\n" + strings[randInt] + " + 2%";
                        break;
                }

                GetItemPanel.SetActive(true);

                DataController.Instance.collectionDamage += 0.03f;
                PlayerPrefs.SetInt("CollectionItem_" + randInt, PlayerPrefs.GetInt("CollectionItem_" + randInt) + 1);
                
                if (Social.localUser.authenticated)
                {
                    if (DataController.Instance.relicCount == 0)
                    {
                        Social.ReportProgress(GPGSIds.achievement_relic_acquisition, 100f, isSuccess =>
                        {
                        });
                    }

                    Social.ReportScore(DataController.Instance.relicCount, GPGSIds.leaderboard_5, success =>
                    {
                        if (success)
                        {
                            print("Success");
                        }
                    });
                }

                DataController.Instance.relicCount++;

                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();

                DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

                EventManager.Instance.GetCollectionItem();
            }
            else
            {
                // 유물이 20개 이상일 경우 다시 돌리기 및 취소
                if (Application.systemLanguage == SystemLanguage.Korean)
                {
                    NotificationManager.Instance.SetNotification("최대 갯수를 넘었습니다. 다시 시도해주세요.");
                }
                else if (Application.systemLanguage == SystemLanguage.Japanese)
                {
                    NotificationManager.Instance.SetNotification("最大数を超えました。再試行してください。");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("The maximum item index. Please try again.");
                }
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification(LocalManager.Instance.LessSapphire);
        }
    }
}