using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionItem : MonoBehaviour
{
    public int index;

    public Text AvilityText1;
    public Text AvilityText2;

    private string[] names =
    {
        "트롤의 팔찌", "오래된 방패", "낡은 검", "오우거의 철퇴", "전사의 신발",
        "명사수의 활", "기사의 견장", "기사의 갑옷", "파라오의 문양", "오래된 마법서",
        "기사의 건틀릿", "왕의 장신구", "왕의 밸트", "왕의 무릎보호대", "현자의 지팡이",
        "현자의 장갑"
    };

    private string[] avilityStrings =
    {
        "체력", "크리티컬 확률", "분노 시간", "결계석 획득량", "스킬 쿨타임 감소",
        "분노 데미지", "루비 보상 2배\n획득 확률", "사파이어 보상 2배\n획득 확률", "결계석 획득량", "데빌스톤 보상 2배\n획득확률",
        "환생석 획득량", "크리티컬 데미지", "공격력", "파우스트 공격력", "파우스트 공격력",
        "파우스트 공격력"
    };

    private float[] avilityRising =
    {
        2, 0.5f, 1, 1, 2,
        2, 1, 1, 1, 1,
        2, 3, 3, 2, 2,
        2
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
        EventManager.GetCollectionItemEvent += () =>
        {
            AvilityText1.text = names[index] + "(+" +
                                PlayerPrefs.GetInt("CollectionItem_" + index, 0) + ")";

            AvilityText2.text = "공격력 + " + 3 * PlayerPrefs.GetInt("CollectionItem_" + index, 0) + "%\n" +
                                avilityStrings[index] +
                                " + " + avilityRising[index] *
                                PlayerPrefs.GetInt("CollectionItem_" + index, 0) + "%";
        };
    }

    private void OnEnable()
    {
        AvilityText1.text = names[index] + "(+" +
                            PlayerPrefs.GetInt("CollectionItem_" + index, 0) + ")";

        AvilityText2.text = "공격력 + " + 3 * PlayerPrefs.GetInt("CollectionItem_" + index, 0) + "%\n" +
                            avilityStrings[index] +
                            " + " + avilityRising[index] *
                            PlayerPrefs.GetInt("CollectionItem_" + index, 0) + "%";
    }
}