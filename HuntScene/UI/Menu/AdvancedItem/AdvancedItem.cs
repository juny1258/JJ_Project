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
        "창조주의 망치", "창조주의 갑옷", "지옥의 수갑"
    };

    private string[] avilityStrings =
    {
        "공격력", "파우스트 공격력", "체력", "자동클릭 시간 감소", "크리티컬 확률",
        "크리티컬 데미지", "환생석 획득량", "분노 데미지"
    };

    private float[] avilityRising =
    {
        5, 5, 4, 0.3f, 1,
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
        AvilityText1.text = names[index] + "(+" +
                            PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + ")";

        AvilityText2.text = "공격력 + " + 5 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + "%\n" +
                            avilityStrings[index] +
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
        AvilityText1.text = names[index] + "(+" +
                            PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + ")";

        AvilityText2.text = "공격력 + " + 5 * PlayerPrefs.GetInt("AdvancedCollectionItem_" + index, 0) + "%\n" +
                            avilityStrings[index] +
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
                NotificationManager.Instance.SetNotification("환생석이 부족합니다.");
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("더 이상 업그레이드 할 수 없습니다.");
        }
    }
}