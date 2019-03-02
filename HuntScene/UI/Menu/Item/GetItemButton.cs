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

    public void OnPurchaseItem()
    {
        if (DataController.Instance.ruby >= 200)
        {
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
                        ItemInfoText.text = "공격력 + 3%\n" + "체력 + 2%";
                        break;
                    case 1:
                        DataController.Instance.collectionCriticalPer += 0.5f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "크리티컬 확률 + 0.5%";
                        break;
                    case 2:
                        DataController.Instance.collectionAngerTime += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "분노시간 + 1%";
                        break;
                    case 3:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "결계석 획득량 + 1%";
                        break;
                    case 4:
                        DataController.Instance.collectionCoolTime += 2;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "스킬 쿨타임 감소 + 2%";
                        break;
                    case 5:
                        DataController.Instance.collectionAngerDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "분노 데미지 + 2%";
                        break;
                    case 6:
                        DataController.Instance.collectionRubyRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "루비 2배 획득 확률 + 1%";
                        break;
                    case 7:
                        DataController.Instance.collectionSappaireRising += 1;

                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "사파이어 2배 획득 확률 + 1%";
                        break;
                    case 8:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "결계석 획득량 + 1%";
                        break;
                    case 9:
                        DataController.Instance.collectionDevilStoneRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "데빌스톤 2배 획득 확률 + 1%";
                        break;
                    case 10:
                        DataController.Instance.collectionRebirthRising += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "환생석 획득량 + 2%";
                        break;
                    case 11:
                        DataController.Instance.collectionCriticalDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "크리티컬 데미지 + 3%";
                        break;
                    case 12:
                        DataController.Instance.collectionDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "공격력 + 3%";
                        break;
                    case 13:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "파우스트 공격력 + 2%";
                        break;
                    case 14:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "파우스트 공격력 + 2%";
                        break;
                    case 15:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "파우스트 공격력 + 2%";
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
                NotificationManager.Instance.SetNotification("최대 갯수를 넘었습니다. 다시 시도해주세요.");
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("루비가 부족합니다.");
        }
    }

    public void OnPurchaseItem2()
    {
        if (DataController.Instance.sapphire >= 100)
        {
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
                        ItemInfoText.text = "공격력 + 3%\n" + "체력 + 2%";
                        break;
                    case 1:
                        DataController.Instance.collectionCriticalPer += 0.5f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "크리티컬 확률 + 0.5%";
                        break;
                    case 2:
                        DataController.Instance.collectionAngerTime += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "분노시간 + 1%";
                        break;
                    case 3:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "결계석 획득량 + 1%";
                        break;
                    case 4:
                        DataController.Instance.collectionCoolTime += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "스킬 쿨타임 감소 + 1%";
                        break;
                    case 5:
                        DataController.Instance.collectionAngerDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "분노 데미지 + 2%";
                        break;
                    case 6:
                        DataController.Instance.collectionRubyRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "루비 2배 획득 확률 + 1%";
                        break;
                    case 7:
                        DataController.Instance.collectionSappaireRising += 1;

                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "사파이어 2배 획득 확률 + 1%";
                        break;
                    case 8:
                        DataController.Instance.collectionGoldRising += 0.01f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "결계석 획득량 + 1%";
                        break;
                    case 9:
                        DataController.Instance.collectionDevilStoneRising += 1;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "데빌스톤 2배 획득 확률 + 1%";
                        break;
                    case 10:
                        DataController.Instance.collectionRebirthRising += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "환생석 획득량 + 2%";
                        break;
                    case 11:
                        DataController.Instance.collectionCriticalDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "크리티컬 데미지 + 3%";
                        break;
                    case 12:
                        DataController.Instance.collectionDamage += 0.03f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "공격력 + 3%";
                        break;
                    case 13:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "파우스트 공격력 + 2%";
                        break;
                    case 14:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "파우스트 공격력 + 2%";
                        break;
                    case 15:
                        DataController.Instance.collectionFaustDamage += 0.02f;
                        ItemImage.sprite = Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                        ItemInfoText.text = "공격력 + 3%\n" + "파우스트 공격력 + 2%";
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
                NotificationManager.Instance.SetNotification("최대 갯수를 넘었습니다. 다시 시도해주세요.");
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("사파이어가 부족합니다.");
        }
    }
}