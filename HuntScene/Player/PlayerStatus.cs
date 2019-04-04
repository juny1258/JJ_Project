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

        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            Info1.text =
                "공격력 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage) +
                "\n체력 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.GetPlayerHP()) +
                "\n크리티컬 확률 : " + Math.Round((DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                                  DataController.Instance.devilCritical +
                                  DataController.Instance.collectionCriticalPer +
                                  DataController.Instance.advancedCriticalPer +
                                  DataController.Instance.skinCriticalPer), 1) +
                "%\n크리 데미지 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage) +
                "\n분노 시간 : " + Math.Round(DataController.Instance.angerTime +
                                          DataController.Instance.angerTime * DataController.Instance.rubyAngerTime +
                                          DataController.Instance.angerTime *
                                          DataController.Instance.collectionAngerTime,
                    1) +
                "초\n분노 데미지 : " + Math.Round((DataController.Instance.angerDamage +
                                            DataController.Instance.rubyAngerDamage +
                                            DataController.Instance.collectionAngerDamage +
                                            DataController.Instance.advancedAngerDamage) * 100 , 0)+
                "%\n결계석 획득량 : " + Math.Round(DataController.Instance.collectionGoldRising * 100, 0) +
                "%\n스킬 쿨타임 감소 : " + DataController.Instance.collectionCoolTime +
                "%\n루비 2배 획득확률 : " + DataController.Instance.collectionRubyRising +
                "%\n사파이어 2배 획득확률 : " + DataController.Instance.collectionSappaireRising +
                "%\n데빌스톤 2배 획득확률 : " + DataController.Instance.collectionDevilStoneRising + "%";

            Info2.text =
                "힘의 원천 획득량 + " +
                Math.Round(
                    (DataController.Instance.collectionRebirthRising + DataController.Instance.advancedRebirthPer) *
                    100, 0) +
                "%\n파우스트 공격력 + " +
                Math.Round(
                    (DataController.Instance.collectionFaustDamage + DataController.Instance.advancedFaustDamage) * 100,
                    0) +
                "%\n자동클릭 시간 : " + Math.Round(DataController.Instance.advancedAutoTap, 1) + "초";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Info1.text =
                "攻撃力 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage) +
                "\n体力 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.GetPlayerHP()) +
                "\nクリティカル確率 : " + Math.Round((DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                                  DataController.Instance.devilCritical +
                                  DataController.Instance.collectionCriticalPer +
                                  DataController.Instance.advancedCriticalPer +
                                  DataController.Instance.skinCriticalPer), 1) +
                "%\nクリティカル攻撃力 : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage) +
                "\n怒りの時間 : " + Math.Round(DataController.Instance.angerTime +
                                          DataController.Instance.angerTime * DataController.Instance.rubyAngerTime +
                                          DataController.Instance.angerTime *
                                          DataController.Instance.collectionAngerTime,
                    1) +
                "秒\n怒り攻撃力 : " + Math.Round((DataController.Instance.angerDamage +
                                            DataController.Instance.rubyAngerDamage +
                                            DataController.Instance.collectionAngerDamage +
                                            DataController.Instance.advancedAngerDamage) * 100 , 0)+
                "%\n結界石獲得量 : " + Math.Round(DataController.Instance.collectionGoldRising * 100, 0) +
                "%\nスキル待機時間の短縮 : " + DataController.Instance.collectionCoolTime +
                "%\nルビー報酬2倍獲得確率 : " + DataController.Instance.collectionRubyRising +
                "%\nサファイア補償2倍獲得確率 : " + DataController.Instance.collectionSappaireRising +
                "%\n悪魔の石補償2倍獲得確率 : " + DataController.Instance.collectionDevilStoneRising + "%";

            Info2.text =
                "超越の石獲得量 + " +
                Math.Round(
                    (DataController.Instance.collectionRebirthRising + DataController.Instance.advancedRebirthPer) *
                    100, 0) +
                "%\nファウスト攻撃力 + " +
                Math.Round(
                    (DataController.Instance.collectionFaustDamage + DataController.Instance.advancedFaustDamage) * 100,
                    0) +
                "%\n自動タブ時間 : " + Math.Round(DataController.Instance.advancedAutoTap, 1) + "秒";
        }
        else
        {
            Info1.text =
                "Damage : " + DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage) +
                "\nHp : " + DataController.Instance.FormatGoldTwo(DataController.Instance.GetPlayerHP()) +
                "\nCritical Probability : " + (DataController.Instance.criticalPercent +
                                               DataController.Instance.rubyCriticalPer +
                                               DataController.Instance.devilCritical +
                                               DataController.Instance.collectionCriticalPer +
                                               DataController.Instance.advancedCriticalPer +
                                               DataController.Instance.skinCriticalPer) +
                "%\nCritical Damage : " +
                DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage) +
                "\nAnger Time : " + Math.Round(DataController.Instance.angerTime +
                                               DataController.Instance.angerTime *
                                               DataController.Instance.rubyAngerTime +
                                               DataController.Instance.angerTime *
                                               DataController.Instance.collectionAngerTime,
                    0) +
                "s\nAnger Damage : " + Math.Round((DataController.Instance.angerDamage +
                                                  DataController.Instance.rubyAngerDamage +
                                                  DataController.Instance.collectionAngerDamage +
                                                  DataController.Instance.advancedAngerDamage) * 100, 0) +
                "%\nRising Stone : " + Math.Round(DataController.Instance.collectionGoldRising * 100, 0) +
                "%\nReduced Cooltime : " + DataController.Instance.collectionCoolTime +
                "%\nRuby Double : " + DataController.Instance.collectionRubyRising +
                "%\nSapphire Double : " + DataController.Instance.collectionSappaireRising +
                "%\nDevilstone Double : " + DataController.Instance.collectionDevilStoneRising + "%";

            Info2.text =
                "Rebirth Stone + " + Math.Round(DataController.Instance.collectionRebirthRising * 100, 0) +
                "%\nFaust Damage + " +
                Math.Round(
                    (DataController.Instance.collectionFaustDamage + DataController.Instance.advancedFaustDamage) * 100,
                    0) +
                "%\nAutoclick Time : " + Math.Round(DataController.Instance.advancedAutoTap, 1) + "s";
        }
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