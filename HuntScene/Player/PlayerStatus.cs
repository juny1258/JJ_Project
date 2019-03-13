using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Text Info1;
    public Text Info2;

    public Image PlayerStateImage;

    private void OnEnable()
    {
        DataController.Instance.isStatus = true;
        SetCostume();

        Info1.text =
            "공격력 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage) +
            "\n체력 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.GetPlayerHP()) +
            "\n크리티컬 확률 : " + (DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                              DataController.Instance.devilCritical + DataController.Instance.collectionCriticalPer +
                              DataController.Instance.advancedCriticalPer + DataController.Instance.skinCriticalPer) +
            "%\n크리 데미지 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage) +
            "\n분노 시간 : " + (DataController.Instance.angerTime +
                            DataController.Instance.angerTime * DataController.Instance.rubyAngerTime +
                            DataController.Instance.angerTime * DataController.Instance.collectionAngerTime) +
            "초\n분노 데미지 : " + (DataController.Instance.angerDamage +
                              DataController.Instance.rubyAngerDamage +
                              DataController.Instance.collectionAngerDamage +
                              DataController.Instance.advancedAngerDamage) * 100 +
            "%\n결계석 획득량 : " + DataController.Instance.collectionGoldRising * 100 +
            "%\n스킬 쿨타임 감소 : " + DataController.Instance.collectionCoolTime +
            "%\n루비 2배 획득확률 : " + DataController.Instance.collectionRubyRising +
            "%\n사파이어 2배 획득확률 : " + DataController.Instance.collectionSappaireRising +
            "%\n데빌스톤 2배 획득확률 : " + DataController.Instance.collectionDevilStoneRising + "%";

        Info2.text =
            "힘의 원천 획득량 + " + DataController.Instance.collectionRebirthRising +
            "%\n파우스트 공격력 + " +
            Math.Round(
                (DataController.Instance.collectionFaustDamage + DataController.Instance.advancedFaustDamage) * 100,
                0) +
            "%\n자동클릭 시간 : " + DataController.Instance.advancedAutoTap + "초";
    }

    private void OnDisable()
    {
        DataController.Instance.isStatus = false;
    }

    private void SetCostume()
    {
        if (DataController.Instance.skinIndex == 0)
        {
            PlayerStateImage.sprite =
                Resources.Load("Player/Costume" + DataController.Instance.costumeIndex + "/Costume",
                    typeof(Sprite)) as Sprite;
        }
        else
        {
            PlayerStateImage.sprite =
                Resources.Load("Player/Skin" + DataController.Instance.skinIndex + "/Costume",
                    typeof(Sprite)) as Sprite;
        }
    }
}