using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedItemButton : MonoBehaviour
{
    public GameObject GetItemPanel;
    public Image ItemImage;
    public Text ItemInfoText;

    private int[] price =
    {
        50, 100, 200, 400, 600, 800, 1000, 2000
    };

    public Text PriceText;

    private void Start()
    {
        EventManager.GetAdvancedItemEvent += () =>
        {
            if (DataController.Instance.advancedItemBoxLevel < 8)
            {
                PriceText.text = price[DataController.Instance.advancedItemBoxLevel].ToString();   
            }
            else
            {
                PriceText.text = "MAX";
            }
        };
    }

    private void OnEnable()
    {
        if (DataController.Instance.advancedItemBoxLevel < 8)
        {
            PriceText.text = price[DataController.Instance.advancedItemBoxLevel].ToString();   
        }
        else
        {
            PriceText.text = "구매 완료";
        }
    }

    public void PurchaseItem()
    {
        if (DataController.Instance.advancedItemBoxLevel < 8)
        {
            if (DataController.Instance.rebirthStone >= price[DataController.Instance.advancedItemBoxLevel])
            {
                var randInt = Random.Range(0, 8);

                if (PlayerPrefs.GetInt("AdvancedCollectionItem_" + randInt, 0) == 0)
                {
                    DataController.Instance.rebirthStone -= price[DataController.Instance.advancedItemBoxLevel];

                    switch (randInt)
                    {
                        case 0:
                            DataController.Instance.advancedDamage += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "공격력 + 5%";
                            break;
                        case 1:
                            DataController.Instance.advancedFaustDamage += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "파우스트 공격력 + 5%";
                            break;
                        case 2:
                            DataController.Instance.advancedHp += 0.04f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "체력 + 4%";
                            break;
                        case 3:
                            DataController.Instance.advancedAutoTap -= 0.06f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "자동클릭 시간 감소 + 0.3%";
                            break;
                        case 4:
                            DataController.Instance.advancedCriticalPer += 1f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "크리티컬 확률 + 1%";
                            break;
                        case 5:
                            DataController.Instance.advancedCriticalRising += 0.05f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "크리티컬 데미지 + 5%";
                            break;
                        case 6:
                            DataController.Instance.advancedRebirthPer += 0.02f;
                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "환생석 획득량 + 2%";
                            break;
                        case 7:
                            DataController.Instance.advancedAngerDamage += 0.03f;

                            ItemImage.sprite = Resources.Load("UI/AdvancedItem/relic" + randInt, typeof(Sprite)) as Sprite;
                            ItemInfoText.text = "공격력 + 5%\n" + "분노 데미지 + 3%";
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
                    NotificationManager.Instance.SetNotification("중복되었습니다. 다시 시도해주세요.");
                }
            }
            else
            {
                NotificationManager.Instance.SetNotification("환생석이 부족합니다.");
            }
        }
    }
}