using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class LoadSave : MonoBehaviour
{
    private DatabaseReference userReference;

    public GameObject LoadSuccessPanel;

    private void Start()
    {
        userReference = FirebaseManager.Instance.Reference.Child("saveData");
    }

    public void SaveButton()
    {
        NotificationManager.Instance.SetNotification2("클라우드에 저장하는 중입니다\n잠시만 기다려주세요.");
        SaveDataManager.Instance.xmlData = "";

        // 버프 데이터
        SaveDataManager.Instance.GetInt("AutoClickLevel", 0);
        SaveDataManager.Instance.GetInt("AutoClickIndex", 0);
        SaveDataManager.Instance.GetInt("AutoClickPotion", 0);

        SaveDataManager.Instance.GetInt("GoldBuffLevel", 0);
        SaveDataManager.Instance.GetInt("GoldBuffIndex", 0);
        SaveDataManager.Instance.GetInt("GoldBuffPotion", 0);

        SaveDataManager.Instance.GetInt("FaustCount", 0);

        SaveDataManager.Instance.GetInt("MonsterKillLevel", 0);
        SaveDataManager.Instance.GetInt("FirstRebirth", 0);

        SaveDataManager.Instance.GetFloat("HighFaustDamage", 0);
        SaveDataManager.Instance.GetInt("HighFaustDamageLevel", 0);

        SaveDataManager.Instance.GetInt("RelicCount", 0);
        SaveDataManager.Instance.GetInt("AdvancedItemBoxLevel", 0);

        SaveDataManager.Instance.GetFloat("LastPlayTime", 0);

        SaveDataManager.Instance.GetInt("FinalHuntLevel", 0);
        SaveDataManager.Instance.GetInt("HuntLevel", 0);

        SaveDataManager.Instance.GetFloat("NowStage", 0);

        SaveDataManager.Instance.GetInt("BossLevel", 0);
        SaveDataManager.Instance.GetInt("FinalBossLevel", 0);

        SaveDataManager.Instance.GetFloat("Gold", 0);
        SaveDataManager.Instance.GetFloat("Ruby", 0);
        SaveDataManager.Instance.GetFloat("Sapphire", 0);
        SaveDataManager.Instance.GetFloat("DevilStone", 0);
        SaveDataManager.Instance.GetFloat("RebirthStone", 0);
        SaveDataManager.Instance.GetFloat("SkipCoupon", 0);
        SaveDataManager.Instance.GetFloat("CouponTime", 0);


        SaveDataManager.Instance.GetInt("RebirthLevel", 0);
        SaveDataManager.Instance.GetInt("NowRebirthLevel", 0);


        SaveDataManager.Instance.GetFloat("DamageLevel", 1);
        SaveDataManager.Instance.GetFloat("DamageAddCost", 0);
        SaveDataManager.Instance.GetFloat("DamageCost", 100);
        SaveDataManager.Instance.GetFloat("HpLevel", 1);
        SaveDataManager.Instance.GetFloat("HpAddCost", 0);
        SaveDataManager.Instance.GetFloat("HpCost", 100);
        SaveDataManager.Instance.GetFloat("CriticalPerLevel", 1);
        SaveDataManager.Instance.GetFloat("CriticalAddCost", 0);
        SaveDataManager.Instance.GetFloat("CriticalCost", 50000);
        SaveDataManager.Instance.GetFloat("CriticalRisingLevel", 1);
        SaveDataManager.Instance.GetFloat("CriticalRisingAddCost", 0);
        SaveDataManager.Instance.GetFloat("CriticalRisingCost", 50000);
        SaveDataManager.Instance.GetFloat("AngerTimeLevel", 1);
        SaveDataManager.Instance.GetFloat("AngerTimeAddCost", 0);
        SaveDataManager.Instance.GetFloat("AngerTimeCost", 50000);
        SaveDataManager.Instance.GetFloat("AngerDamageLevel", 1);
        SaveDataManager.Instance.GetFloat("AngerDamageAddCost", 0);
        SaveDataManager.Instance.GetFloat("AngerDamageCost", 50000);
        SaveDataManager.Instance.GetFloat("RubyRisingDamage", 0);
        SaveDataManager.Instance.GetFloat("RubyRisingDamageLevel", 0);
        SaveDataManager.Instance.GetFloat("RubyRisingHP", 0);
        SaveDataManager.Instance.GetFloat("RubyRisingHPLevel", 0);
        SaveDataManager.Instance.GetFloat("RubyCriticalPer", 0);
        SaveDataManager.Instance.GetFloat("RubyCriticalPerLevel", 0);
        SaveDataManager.Instance.GetFloat("RubyCriticalRising", 0);
        SaveDataManager.Instance.GetFloat("RubyCriticalRisingLevel", 0);
        SaveDataManager.Instance.GetFloat("RubyAngerTime", 0);
        SaveDataManager.Instance.GetFloat("RubyAngerTimeLevel", 0);
        SaveDataManager.Instance.GetFloat("RubyAngerDamage", 0);
        SaveDataManager.Instance.GetFloat("RubyAngerDamageLevel", 0);

        SaveDataManager.Instance.GetFloat("LegendDevilStone", 0);
        SaveDataManager.Instance.GetFloat("DevilDamageLevel", 1);
        SaveDataManager.Instance.GetFloat("DevilHpLevel", 1);
        SaveDataManager.Instance.GetFloat("DevilCriticalLevel", 1);
        SaveDataManager.Instance.GetFloat("DevilCriticalRisingLevel", 1);
        SaveDataManager.Instance.GetFloat("Damage", 10);
        SaveDataManager.Instance.GetFloat("DevilDamage", 0);
        SaveDataManager.Instance.GetFloat("DevilHp", 1);
        SaveDataManager.Instance.GetFloat("DevilCritical", 0);
        SaveDataManager.Instance.GetFloat("DevilCriticalRising", 0);


        SaveDataManager.Instance.GetInt("MasterSkillIndex", 0);
        SaveDataManager.Instance.GetInt("SkillIndex", 0);
        SaveDataManager.Instance.GetInt("SkinIndex", 0);
        SaveDataManager.Instance.GetInt("MasterCostumeIndex", 0);
        SaveDataManager.Instance.GetInt("CostumeIndex", 0);
        SaveDataManager.Instance.GetInt("FirstOpenGame", 0);

        SaveDataManager.Instance.GetFloat("CollectionDamage", 0);
        SaveDataManager.Instance.GetFloat("CollectionCriticalPer", 0);
        SaveDataManager.Instance.GetFloat("CollectionHp", 0);
        SaveDataManager.Instance.GetFloat("CollectionAngerTime", 0);
        SaveDataManager.Instance.GetFloat("CollectionGoldRising", 1);
        SaveDataManager.Instance.GetFloat("CollectionCoolTime", 0);
        SaveDataManager.Instance.GetFloat("CollectionAngerDamage", 0);
        SaveDataManager.Instance.GetFloat("CollectionRubyRising", 0);
        SaveDataManager.Instance.GetFloat("CollectionSappaireRising", 0);
        SaveDataManager.Instance.GetFloat("CollectionDevilStoneRising", 0);
        SaveDataManager.Instance.GetFloat("CollectionRebirthRising", 1);
        SaveDataManager.Instance.GetFloat("CollectionCriticalDamage", 0);
        SaveDataManager.Instance.GetFloat("CollectionFaustDamage", 0.5f);

        SaveDataManager.Instance.GetFloat("AdvancedDamage", 0);
        SaveDataManager.Instance.GetFloat("AdvancedFaustDamage", 0.5f);
        SaveDataManager.Instance.GetFloat("AdvancedHp", 0);
        SaveDataManager.Instance.GetFloat("AdvancedAutoTap", 2);
        SaveDataManager.Instance.GetFloat("AdvancedCriticalPer", 0);
        SaveDataManager.Instance.GetFloat("AdvancedCriticalRising", 0);
        SaveDataManager.Instance.GetFloat("AdvancedRebirthPer", 0);
        SaveDataManager.Instance.GetFloat("AdvancedAngerDamage", 0);
        SaveDataManager.Instance.GetFloat("SkinDamage", 0);
        SaveDataManager.Instance.GetFloat("SkinCriticalPer", 0);
        
        SaveDataManager.Instance.GetFloat("PlayerHP", 200);
        
        SaveDataManager.Instance.GetFloat("AngerDamage", 1.1f);
        SaveDataManager.Instance.GetFloat("AngerTime", 3);
        SaveDataManager.Instance.GetFloat("CriticalPercent", 1);
        SaveDataManager.Instance.GetFloat("CriticalRising", 1.20f);

        SaveDataManager.Instance.GetInt("Skill_1", 0);
        SaveDataManager.Instance.GetInt("Skill_2", 0);
        SaveDataManager.Instance.GetInt("Skill_3", 0);
        SaveDataManager.Instance.GetInt("Skill_4", 0);
        SaveDataManager.Instance.GetInt("Skill_5", 0);
        SaveDataManager.Instance.GetInt("Skill_6", 0);
        SaveDataManager.Instance.GetInt("InAppPurchase", 0);

        SaveDataManager.Instance.GetFloat("skill_1_damage", 0.5f);
        SaveDataManager.Instance.GetFloat("skill_2_damage", 0.8f);
        SaveDataManager.Instance.GetFloat("skill_3_time", 5);
        SaveDataManager.Instance.GetFloat("skill_4_damage", 2);
        SaveDataManager.Instance.GetFloat("skill_5_damage", 1.2f);
        SaveDataManager.Instance.GetFloat("skill_6_damage", 1.2f);

        SaveDataManager.Instance.GetFloat("skill_1_cooltime", 0);
        SaveDataManager.Instance.GetFloat("skill_2_cooltime", 0);
        SaveDataManager.Instance.GetFloat("skill_3_cooltime", 0);
        SaveDataManager.Instance.GetFloat("skill_4_cooltime", 0);
        SaveDataManager.Instance.GetFloat("skill_5_cooltime", 0);
        SaveDataManager.Instance.GetFloat("skill_6_cooltime", 0);

        SaveDataManager.Instance.GetFloat("Merchant", 0);
        SaveDataManager.Instance.GetFloat("IsSkillPurchase", 0);
        SaveDataManager.Instance.GetFloat("Skin_1", 0);
        SaveDataManager.Instance.GetFloat("Skin_2", 0);
        SaveDataManager.Instance.GetFloat("Skin_100", 0);
        
        SaveDataManager.Instance.GetFloat("SsuckSso", 0);
        SaveDataManager.Instance.GetFloat("RecordFaustDamage", 0);

        // Reverse

        for (int i = 0; i < 16; i++)
        {
            SaveDataManager.Instance.GetInt("CollectionItem_" + i, 0);
        }

        for (int i = 0; i < 8; i++)
        {
            SaveDataManager.Instance.GetInt("AdvancedCollectionItem_" + i, 0);
        }

        // 출석체크 데이터
        SaveDataManager.Instance.GetFloat("AttendanceIndex", 0);
        SaveDataManager.Instance.GetFloat("LastAttendance", 0);

        SaveDataManager.Instance.GetFloat("OverlapCoupon", 0);

        SaveDataManager.Instance.GetString("PlayerID", "");

        SaveDataManager.Instance.GetFloat("NoAds", 0);
        SaveDataManager.Instance.GetFloat("PlayTime", 0);


        if (PlayGamesPlatform.Instance.localUser.id != "")
        {
            userReference.Child(PlayGamesPlatform.Instance.localUser.id)
                .SetValueAsync(SaveDataManager.Instance.xmlData)
                .ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        NotificationManager.Instance.SetNotification2("데이터 저장 완료");
                    }
                    else
                    {
                        NotificationManager.Instance.SetNotification("인터넷 연결을 확인하세요.");
                    }
                });
        }
        else
        {
            NotificationManager.Instance.SetNotification("Login Fail");
        }
    }

    public void LoadButton()
    {
        if (PlayGamesPlatform.Instance.localUser.id != "")
        {
            LoadSuccessPanel.SetActive(true);
            LoadSuccessPanel.GetComponentInChildren<Text>().text = "데이터를 불러오는 중입니다\n잠시만 기다려주세요.";
            userReference.Child(PlayGamesPlatform.Instance.localUser.id).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    SaveDataManager.Instance.GetData(task.Result.Value.ToString());
                }
                else
                {
                    LoadSuccessPanel.GetComponentInChildren<Text>().text = "인터넷 연결을 확인하세요.";
                    LoadSuccessPanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
                    {
                        Application.Quit();
                        LoadSuccessPanel.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                    });
                }
            });
        }
        else
        {
            NotificationManager.Instance.SetNotification("Login Fail");
        }
    }
}