using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController _instance;

    public static DataController Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<DataController>();
            if (_instance != null) return _instance;
            var container = new GameObject("DataController");

            _instance = container.AddComponent<DataController>();

            return _instance;
        }
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (Debug.isDebugBuild)
        {
//            PlayerPrefs.DeleteAll();

            gold = 99999999999f;
            ruby = 500000;
            sapphire = 20000;
            devilStone = 20000;
            rebirthStone = 10000;

//            couponTime = 1;
        }

        Monsters = GameObject.Find("Monsters").GetComponent<Transform>();

        UpdateDamage();
        UpdateCritical();
    }
    
    // 오토클릭 데이터
    public int autoClickLevel
    {
        get { return PlayerPrefs.GetInt("AutoClickLevel", 0); }
        set { PlayerPrefs.SetInt("AutoClickLevel", value); }
    }

    public float autoClickTime;
    
    public bool useAutoClick;
    
    public int autoClickIndex
    {
        get { return PlayerPrefs.GetInt("AutoClickIndex", 0); }
        set { PlayerPrefs.SetInt("AutoClickIndex", value); }
    }

    public int autoClickPotion
    {
        get { return PlayerPrefs.GetInt("AutoClickPotion", 0); }
        set { PlayerPrefs.SetInt("AutoClickPotion", value); }
    }
    
    // 획득 골드 증가 데이터
    public int goldBuffLevel
    {
        get { return PlayerPrefs.GetInt("GoldBuffLevel", 0); }
        set { PlayerPrefs.SetInt("GoldBuffLevel", value); }
    }

    public float goldBuffTime;
    
    public int useGoldBuff = 1;
    
    public int goldBuffIndex
    {
        get { return PlayerPrefs.GetInt("GoldBuffIndex", 0); }
        set { PlayerPrefs.SetInt("GoldBuffIndex", value); }
    }

    public int goldBuffPotion
    {
        get { return PlayerPrefs.GetInt("GoldBuffPotion", 0); }
        set { PlayerPrefs.SetInt("GoldBuffPotion", value); }
    }
    
    
    // 튜토리얼 진행 여부
    public bool isTutorial;
    
    // 업적

    public float monsterKillCount
    {
        get { return PlayerPrefs.GetFloat("MonsterKillCount", 0); }
        set { PlayerPrefs.SetFloat("MonsterKillCount", value); }
    }

    public int monsterKillLevel
    {
        get { return PlayerPrefs.GetInt("MonsterKillLevel", 0); }
        set { PlayerPrefs.SetInt("MonsterKillLevel", value); }
    }
    
    public float attackCount
    {
        get { return PlayerPrefs.GetFloat("AttackCount", 0); }
        set { PlayerPrefs.SetFloat("AttackCount", value); }
    }

    public int firstRebirth
    {
        get { return PlayerPrefs.GetInt("FirstRebirth", 0); }
        set { PlayerPrefs.SetInt("FirstRebirth", value); }
    }

    public float highFaustDamage // 리더보드 포함
    {
        get { return PlayerPrefs.GetFloat("HighFaustDamage", 0); }
        set { PlayerPrefs.SetFloat("HighFaustDamage", value); }
    }
    
    public int highFaustDamageLevel // 리더보드 포함
    {
        get { return PlayerPrefs.GetInt("HighFaustDamageLevel", 0); }
        set { PlayerPrefs.SetInt("HighFaustDamageLevel", value); }
    }
    
    // 리더보드

    public int relicCount
    {
        get { return PlayerPrefs.GetInt("RelicCount", 0); }
        set { PlayerPrefs.SetInt("RelicCount", value); }
    }

    // 고대 유물 상자 레벨
    public int advancedItemBoxLevel
    {
        get { return PlayerPrefs.GetInt("AdvancedItemBoxLevel", 0); }
        set { PlayerPrefs.SetInt("AdvancedItemBoxLevel", value); }
    }

    public int finalClearHunt
    {
        get { return PlayerPrefs.GetInt("FinalClearHunt", 0); }
        set { PlayerPrefs.SetInt("FinalClearHunt", value); }
    }

    public int finalClearBoss
    {
        get { return PlayerPrefs.GetInt("FinalClearBoss", 0); }
        set { PlayerPrefs.SetInt("FinalClearBoss", value); }
    }

    public bool isFight;

    // 시간 측정
    public float lastAttendance
    {
        // 마지막 접속 시간
        get { return PlayerPrefs.GetFloat("LastAttendance", 0); }
        set { PlayerPrefs.SetFloat("LastAttendance", value); }
    }

    public float attendanceIndex
    {
        // 연속 출석한 일 수
        get { return PlayerPrefs.GetFloat("AttendanceIndex", 0); }
        set { PlayerPrefs.SetFloat("AttendanceIndex", value); }
    }

    public float lastPlayTime
    {
        get { return PlayerPrefs.GetFloat("LastPlayTime", 0); }
        set { PlayerPrefs.SetFloat("LastPlayTime", value); }
    }

    // 인앱

    public int finalHuntLevel
    {
        get { return PlayerPrefs.GetInt("FinalHuntLevel", 0); }
        set { PlayerPrefs.SetInt("FinalHuntLevel", value); }
    }

    public int huntLevel
    {
        get { return PlayerPrefs.GetInt("HuntLevel", 0); }
        set { PlayerPrefs.SetInt("HuntLevel", value); }
    }

    public float nowStage
    {
        get { return PlayerPrefs.GetFloat("NowStage", 1); }
        set { PlayerPrefs.SetFloat("NowStage", value); }
    }

    // 보스
    public int bossLevel
    {
        get { return PlayerPrefs.GetInt("BossLevel", 0); }
        set { PlayerPrefs.SetInt("BossLevel", value); }
    }

    public int finalBossLevel
    {
        get { return PlayerPrefs.GetInt("FinalBossLevel", 0); }
        set { PlayerPrefs.SetInt("FinalBossLevel", value); }
    }

    // 던전
    public int dungeonLevel
    {
        get { return PlayerPrefs.GetInt("DungeonLevel", 0); }
        set { PlayerPrefs.SetInt("DungeonLevel", value); }
    }

    public int finalDungeonLevel
    {
        get { return PlayerPrefs.GetInt("FinalDungeonLevel", 0); }
        set { PlayerPrefs.SetInt("FinalDungeonLevel", value); }
    }

    public Transform Monsters;

    // 재화

    public float masterDamage;

    public float gold
    {
        get { return PlayerPrefs.GetFloat("Gold", 0); }
        set { PlayerPrefs.SetFloat("Gold", value); }
    }

    public float compensationGold;

    public Queue<float> goldQueue = new Queue<float>();

    public float getGold;
    public float getRuby;
    public float getSapphire;

    public float ruby
    {
        get { return PlayerPrefs.GetFloat("Ruby", 0); }
        set { PlayerPrefs.SetFloat("Ruby", value); }
    }

    public float sapphire
    {
        get { return PlayerPrefs.GetFloat("Sapphire", 0); }
        set { PlayerPrefs.SetFloat("Sapphire", value); }
    }

    public float devilStone
    {
        get { return PlayerPrefs.GetFloat("DevilStone", 0); }
        set { PlayerPrefs.SetFloat("DevilStone", value); }
    }

    public float rebirthStone
    {
        get { return PlayerPrefs.GetFloat("RebirthStone", 0); }
        set { PlayerPrefs.SetFloat("RebirthStone", value); }
    }

    public float skipCoupon
    {
        get { return PlayerPrefs.GetFloat("SkipCoupon", 0); }
        set { PlayerPrefs.SetFloat("SkipCoupon", value); }
    }
    
    public float couponTime
    {
        get { return PlayerPrefs.GetFloat("CouponTime", 0); }
        set { PlayerPrefs.SetFloat("CouponTime", value); }
    }

    // 환생

    public int rebirthLevel
    {
        get { return PlayerPrefs.GetInt("RebirthLevel", 0); }
        set { PlayerPrefs.SetInt("RebirthLevel", value); }
    }

    // 메피의 능력치

    public void RebirthAvilityReset()
    {
        // 결계석 데이터 초기화

        gold = 0;
        
        damage = 10;
        damageLevel = 1;
        damageAddCost = 0;
        damageCost = 100;
        
        playerHP = 200;
        hpLevel = 1;
        hpAddCost = 0;
        hpCost = 100;

        criticalPercent = 1;
        criticalPerLevel = 1;
        criticalAddCost = 0;
        criticalCost = 50000;

        criticalRising = 1.20f;
        criticalRisingLevel = 1;
        criticalRisingAddCost = 0;
        criticalRisingCost = 50000;

        angerTime = 3;
        angerTimeLevel = 1;
        angerTimeAddCost = 0;
        angerTimeCost = 50000;

        angerDamage = 1.1f;
        angerDamageLevel = 1;
        angerDamageAddCost = 0;
        angerDamageCost = 50000;
        
        finalHuntLevel = 0;
        finalBossLevel = 0;
        
        UpdateDamage();
        UpdateCritical();

        nowPlayerHP = GetPlayerHP();
    }
    
    // 업그레이드

    public float damageLevel
    {
        get { return PlayerPrefs.GetFloat("DamageLevel", 1); }
        set { PlayerPrefs.SetFloat("DamageLevel", value); }
    }

    public float damageAddCost
    {
        get { return PlayerPrefs.GetFloat("DamageAddCost", 0); }
        set { PlayerPrefs.SetFloat("DamageAddCost", value); }
    }

    public float damageCost
    {
        get { return PlayerPrefs.GetFloat("DamageCost", 100); }
        set { PlayerPrefs.SetFloat("DamageCost", value); }
    }

    public float hpLevel
    {
        get { return PlayerPrefs.GetFloat("HpLevel", 1); }
        set { PlayerPrefs.SetFloat("HpLevel", value); }
    }

    public float hpAddCost
    {
        get { return PlayerPrefs.GetFloat("HpAddCost", 0); }
        set { PlayerPrefs.SetFloat("HpAddCost", value); }
    }

    public float hpCost
    {
        get { return PlayerPrefs.GetFloat("HpCost", 100); }
        set { PlayerPrefs.SetFloat("HpCost", value); }
    }

    public float criticalPerLevel
    {
        get { return PlayerPrefs.GetFloat("CriticalPerLevel", 1); }
        set { PlayerPrefs.SetFloat("CriticalPerLevel", value); }
    }

    public float criticalAddCost
    {
        get { return PlayerPrefs.GetFloat("CriticalAddCost", 0); }
        set { PlayerPrefs.SetFloat("CriticalAddCost", value); }
    }

    public float criticalCost
    {
        get { return PlayerPrefs.GetFloat("CriticalCost", 50000); }
        set { PlayerPrefs.SetFloat("CriticalCost", value); }
    }

    public float criticalRisingLevel
    {
        get { return PlayerPrefs.GetFloat("CriticalRisingLevel", 1); }
        set { PlayerPrefs.SetFloat("CriticalRisingLevel", value); }
    }

    public float criticalRisingAddCost
    {
        get { return PlayerPrefs.GetFloat("CriticalRisingAddCost", 0); }
        set { PlayerPrefs.SetFloat("CriticalRisingAddCost", value); }
    }

    public float criticalRisingCost
    {
        get { return PlayerPrefs.GetFloat("CriticalRisingCost", 50000); }
        set { PlayerPrefs.SetFloat("CriticalRisingCost", value); }
    }

    public float angerTimeLevel
    {
        get { return PlayerPrefs.GetFloat("AngerTimeLevel", 1); }
        set { PlayerPrefs.SetFloat("AngerTimeLevel", value); }
    }

    public float angerTimeAddCost
    {
        get { return PlayerPrefs.GetFloat("AngerTimeAddCost", 0); }
        set { PlayerPrefs.SetFloat("AngerTimeAddCost", value); }
    }

    public float angerTimeCost
    {
        get { return PlayerPrefs.GetFloat("AngerTimeCost", 50000); }
        set { PlayerPrefs.SetFloat("AngerTimeCost", value); }
    }

    public float angerDamageLevel
    {
        get { return PlayerPrefs.GetFloat("AngerDamageLevel", 1); }
        set { PlayerPrefs.SetFloat("AngerDamageLevel", value); }
    }

    public float angerDamageAddCost
    {
        get { return PlayerPrefs.GetFloat("AngerDamageAddCost", 0); }
        set { PlayerPrefs.SetFloat("AngerDamageAddCost", value); }
    }

    public float angerDamageCost
    {
        get { return PlayerPrefs.GetFloat("AngerDamageCost", 50000); }
        set { PlayerPrefs.SetFloat("AngerDamageCost", value); }
    }

    // 다이아로 올리는 능력치

    public float rubyRisingDamage
    {
        get { return PlayerPrefs.GetFloat("RubyRisingDamage", 0); }
        set { PlayerPrefs.SetFloat("RubyRisingDamage", value); }
    }

    public float rubyRisingDamageLevel
    {
        get { return PlayerPrefs.GetFloat("RubyRisingDamageLevel", 0); }
        set { PlayerPrefs.SetFloat("RubyRisingDamageLevel", value); }
    }

    public float rubyRisingHP
    {
        get { return PlayerPrefs.GetFloat("RubyRisingHP", 0); }
        set { PlayerPrefs.SetFloat("RubyRisingHP", value); }
    }

    public float rubyRisingHPLevel
    {
        get { return PlayerPrefs.GetFloat("RubyRisingHPLevel", 0); }
        set { PlayerPrefs.SetFloat("RubyRisingHPLevel", value); }
    }

    public float rubyCriticalPer
    {
        get { return PlayerPrefs.GetFloat("RubyCriticalPer", 0); }
        set { PlayerPrefs.SetFloat("RubyCriticalPer", value); }
    }

    public float rubyCriticalPerLevel
    {
        get { return PlayerPrefs.GetFloat("RubyCriticalPerLevel", 0); }
        set { PlayerPrefs.SetFloat("RubyCriticalPerLevel", value); }
    }

    public float rubyCriticalRising
    {
        get { return PlayerPrefs.GetFloat("RubyCriticalRising", 0); }
        set { PlayerPrefs.SetFloat("RubyCriticalRising", value); }
    }

    public float rubyCriticalRisingLevel
    {
        get { return PlayerPrefs.GetFloat("RubyCriticalRisingLevel", 0); }
        set { PlayerPrefs.SetFloat("RubyCriticalRisingLevel", value); }
    }

    public float rubyAngerTime
    {
        get { return PlayerPrefs.GetFloat("RubyAngerTime", 0); }
        set { PlayerPrefs.SetFloat("RubyAngerTime", value); }
    }

    public float rubyAngerTimeLevel
    {
        get { return PlayerPrefs.GetFloat("RubyAngerTimeLevel", 0); }
        set { PlayerPrefs.SetFloat("RubyAngerTimeLevel", value); }
    }

    public float rubyAngerDamage
    {
        get { return PlayerPrefs.GetFloat("RubyAngerDamage", 0); }
        set { PlayerPrefs.SetFloat("RubyAngerDamage", value); }
    }

    public float rubyAngerDamageLevel
    {
        get { return PlayerPrefs.GetFloat("RubyAngerDamageLevel", 0); }
        set { PlayerPrefs.SetFloat("RubyAngerDamageLevel", value); }
    }

    // 데빌스톤으로 올리는 능력치

    public float legendDevilStone
    {
        get { return PlayerPrefs.GetFloat("LegendDevilStone", 0); }
        set { PlayerPrefs.SetFloat("LegendDevilStone", value); }
    }

    public float devilDamageLevel
    {
        get { return PlayerPrefs.GetFloat("DevilDamageLevel", 1); }
        set { PlayerPrefs.SetFloat("DevilDamageLevel", value); }
    }

    public float devilHpLevel
    {
        get { return PlayerPrefs.GetFloat("DevilHpLevel", 1); }
        set { PlayerPrefs.SetFloat("DevilHpLevel", value); }
    }

    public float devilCriticalLevel
    {
        get { return PlayerPrefs.GetFloat("DevilCriticalLevel", 1); }
        set { PlayerPrefs.SetFloat("DevilCriticalLevel", value); }
    }

    public float devilCriticalRisingLevel
    {
        get { return PlayerPrefs.GetFloat("DevilCriticalRisingLevel", 1); }
        set { PlayerPrefs.SetFloat("DevilCriticalRisingLevel", value); }
    }

    // 메피 능력치

    public float damage
    {
        get { return PlayerPrefs.GetFloat("Damage", 10); }
        set { PlayerPrefs.SetFloat("Damage", value); }
    }

    public float devilDamage
    {
        get { return PlayerPrefs.GetFloat("DevilDamage", 0); }
        set { PlayerPrefs.SetFloat("DevilDamage", value); }
    }

    public float devilHp
    {
        get { return PlayerPrefs.GetFloat("DevilHp", 1); }
        set { PlayerPrefs.SetFloat("DevilHp", value); }
    }

    public float devilCritical
    {
        get { return PlayerPrefs.GetFloat("DevilCritical", 0); }
        set { PlayerPrefs.SetFloat("DevilCritical", value); }
    }

    public float devilCriticalRising
    {
        get { return PlayerPrefs.GetFloat("DevilCriticalRising", 0); }
        set { PlayerPrefs.SetFloat("DevilCriticalRising", value); }
    }

    public int masterSkillIndex
    {
        get { return PlayerPrefs.GetInt("MasterSkillIndex", 0); }
        set { PlayerPrefs.SetInt("MasterSkillIndex", value); }
    }

    public int skillIndex
    {
        get { return PlayerPrefs.GetInt("SkillIndex", 0); }
        set { PlayerPrefs.SetInt("SkillIndex", value); }
    }
    
    public int masterCostumeIndex
    {
        get { return PlayerPrefs.GetInt("MasterCostumeIndex", 0); }
        set { PlayerPrefs.SetInt("MasterCostumeIndex", value); }
    }

    public int costumeIndex
    {
        get { return PlayerPrefs.GetInt("CostumeIndex", 0); }
        set { PlayerPrefs.SetInt("CostumeIndex", value); }
    }

    // 유물

    public float collectionDamage
    {
        get { return PlayerPrefs.GetFloat("CollectionDamage", 0); }
        set { PlayerPrefs.SetFloat("CollectionDamage", value); }
    }

    public float collectionCriticalPer
    {
        get { return PlayerPrefs.GetFloat("CollectionCriticalPer", 0); }
        set { PlayerPrefs.SetFloat("CollectionCriticalPer", value); }
    }

    public float collectionHp
    {
        get { return PlayerPrefs.GetFloat("CollectionHp", 0); }
        set { PlayerPrefs.SetFloat("CollectionHp", value); }
    }

    public float collectionAngerTime
    {
        get { return PlayerPrefs.GetFloat("CollectionAngerTime", 0); }
        set { PlayerPrefs.SetFloat("CollectionAngerTime", value); }
    }

    public float collectionGoldRising
    {
        get { return PlayerPrefs.GetFloat("CollectionGoldRising", 1); }
        set { PlayerPrefs.SetFloat("CollectionGoldRising", value); }
    }

    public float collectionCoolTime
    {
        get { return PlayerPrefs.GetFloat("CollectionCoolTime", 0); }
        set { PlayerPrefs.SetFloat("CollectionCoolTime", value); }
    }

    public float collectionAngerDamage
    {
        get { return PlayerPrefs.GetFloat("CollectionAngerDamage", 0); }
        set { PlayerPrefs.SetFloat("CollectionAngerDamage", value); }
    }

    public float collectionRubyRising
    {
        get { return PlayerPrefs.GetFloat("CollectionRubyRising", 0); }
        set { PlayerPrefs.SetFloat("CollectionRubyRising", value); }
    }

    public float collectionSappaireRising
    {
        get { return PlayerPrefs.GetFloat("CollectionSappaireRising", 0); }
        set { PlayerPrefs.SetFloat("CollectionSappaireRising", value); }
    }

    public float collectionDevilStoneRising
    {
        get { return PlayerPrefs.GetFloat("CollectionDevilStoneRising", 0); }
        set { PlayerPrefs.SetFloat("CollectionDevilStoneRising", value); }
    }

    public float collectionRebirthRising
    {
        get { return PlayerPrefs.GetFloat("CollectionRebirthRising", 1); }
        set { PlayerPrefs.SetFloat("CollectionRebirthRising", value); }
    }

    public float collectionCriticalDamage
    {
        get { return PlayerPrefs.GetFloat("CollectionCriticalDamage", 0); }
        set { PlayerPrefs.SetFloat("CollectionCriticalDamage", value); }
    }

    public float collectionFaustDamage
    {
        get { return PlayerPrefs.GetFloat("CollectionFaustDamage", 0.5f); }
        set { PlayerPrefs.SetFloat("CollectionFaustDamage", value); }
    }

    // 고대유물

    public float advancedDamage
    {
        get { return PlayerPrefs.GetFloat("AdvancedDamage", 0); }
        set { PlayerPrefs.SetFloat("AdvancedDamage", value); }
    }

    public float advancedFaustDamage
    {
        get { return PlayerPrefs.GetFloat("AdvancedFaustDamage", 0.5f); }
        set { PlayerPrefs.SetFloat("AdvancedFaustDamage", value); }
    }

    public float advancedHp
    {
        get { return PlayerPrefs.GetFloat("AdvancedHp", 0); }
        set { PlayerPrefs.SetFloat("AdvancedHp", value); }
    }

    public float advancedAutoTap
    {
        get { return PlayerPrefs.GetFloat("AdvancedAutoTap", 2); }
        set { PlayerPrefs.SetFloat("AdvancedAutoTap", value); }
    }

    public float advancedCriticalPer
    {
        get { return PlayerPrefs.GetFloat("AdvancedCriticalPer", 0); }
        set { PlayerPrefs.SetFloat("AdvancedCriticalPer", value); }
    }

    public float advancedCriticalRising
    {
        get { return PlayerPrefs.GetFloat("AdvancedCriticalRising", 0); }
        set { PlayerPrefs.SetFloat("AdvancedCriticalRising", value); }
    }

    public float advancedRebirthPer
    {
        get { return PlayerPrefs.GetFloat("AdvancedRebirthPer", 0); }
        set { PlayerPrefs.SetFloat("AdvancedRebirthPer", value); }
    }

    public float advancedAngerDamage
    {
        get { return PlayerPrefs.GetFloat("AdvancedAngerDamage", 0); }
        set { PlayerPrefs.SetFloat("AdvancedAngerDamage", value); }
    }


    public void UpdateDamage()
    {
        if (isAnger)
        {
            masterDamage = (
                               damage
                               + damage * rubyRisingDamage
                               + damage * masterSkillIndex * 0.2f
                               + damage * collectionDamage
                               + damage * devilDamage
                               + damage * advancedDamage
                           )
                           * (angerDamage + rubyAngerDamage + collectionAngerDamage + advancedAngerDamage);
        }
        else
        {
            masterDamage = (
                damage
                + damage * rubyRisingDamage
                + damage * masterSkillIndex * 0.2f
                + damage * collectionDamage
                + damage * devilDamage
                + damage * advancedDamage
            );
        }
    }

    public float masterCriticalDamage;

    public void UpdateCritical()
    {
        masterCriticalDamage = masterDamage *
                               (criticalRising + rubyCriticalRising + devilCriticalRising + collectionCriticalDamage +
                                advancedCriticalRising);
    }

    public float playerHP
    {
        get { return PlayerPrefs.GetFloat("PlayerHP", 200); }
        set { PlayerPrefs.SetFloat("PlayerHP", value); }
    }

    public float GetPlayerHP()
    {
        return (PlayerPrefs.GetFloat("PlayerHP", 200)
                + PlayerPrefs.GetFloat("PlayerHP", 200) * rubyRisingHP)
               * (devilHp + collectionHp + advancedHp + 0.2f * masterCostumeIndex);
    }

    public float nowPlayerHP;

    public float angerGauge;

    public bool isAnger;

    public bool isMenuOpen;

    public float angerDamage
    {
        get { return PlayerPrefs.GetFloat("AngerDamage", 1.1f); }
        set { PlayerPrefs.SetFloat("AngerDamage", value); }
    }

    public float angerTime
    {
        get { return PlayerPrefs.GetFloat("AngerTime", 3); }
        set { PlayerPrefs.SetFloat("AngerTime", value); }
    }

    public float criticalPercent
    {
        get { return PlayerPrefs.GetFloat("CriticalPercent", 1); }
        set { PlayerPrefs.SetFloat("CriticalPercent", value); }
    }

    public float criticalRising
    {
        get { return PlayerPrefs.GetFloat("CriticalRising", 1.20f); }
        set { PlayerPrefs.SetFloat("CriticalRising", value); }
    }

    public float autoClick
    {
        get { return PlayerPrefs.GetFloat("AutoClick", 0); }
        set { PlayerPrefs.SetFloat("AutoClick", value); }
    }

    // 스킬

    public int skill_1
    {
        get { return PlayerPrefs.GetInt("Skill_1", 0); }
        set { PlayerPrefs.SetInt("Skill_1", value); }
    }

    public int skill_2
    {
        get { return PlayerPrefs.GetInt("Skill_2", 0); }
        set { PlayerPrefs.SetInt("Skill_2", value); }
    }

    public int skill_3
    {
        get { return PlayerPrefs.GetInt("Skill_3", 0); }
        set { PlayerPrefs.SetInt("Skill_3", value); }
    }

    public int skill_4
    {
        get { return PlayerPrefs.GetInt("Skill_4", 0); }
        set { PlayerPrefs.SetInt("Skill_4", value); }
    }

    public int skill_5
    {
        get { return PlayerPrefs.GetInt("Skill_5", 0); }
        set { PlayerPrefs.SetInt("Skill_5", value); }
    }

    public int skill_6
    {
        get { return PlayerPrefs.GetInt("Skill_6", 0); }
        set { PlayerPrefs.SetInt("Skill_6", value); }
    }

    public float skill_1_damage
    {
        get { return PlayerPrefs.GetFloat("skill_1_damage", 0.5f); }
        set { PlayerPrefs.SetFloat("skill_1_damage", value); }
    }

    public float skill_2_damage
    {
        get { return PlayerPrefs.GetFloat("skill_2_damage", 0.8f); }
        set { PlayerPrefs.SetFloat("skill_2_damage", value); }
    }

    public float skill_3_time
    {
        get { return PlayerPrefs.GetFloat("skill_3_time", 5); }
        set { PlayerPrefs.SetFloat("skill_3_time", value); }
    }

    public float skill_4_damage
    {
        get { return PlayerPrefs.GetFloat("skill_4_damage", 2f); }
        set { PlayerPrefs.SetFloat("skill_4_damage", value); }
    }

    public float skill_5_damage
    {
        get { return PlayerPrefs.GetFloat("skill_5_damage", 1.2f); }
        set { PlayerPrefs.SetFloat("skill_5_damage", value); }
    }

    public float skill_6_damage
    {
        get { return PlayerPrefs.GetFloat("skill_6_damage", 1.2f); }
        set { PlayerPrefs.SetFloat("skill_6_damage", value); }
    }

    public float skill_1_cooltime
    {
        get { return PlayerPrefs.GetFloat("skill_1_cooltime", 0); }
        set { PlayerPrefs.SetFloat("skill_1_cooltime", value); }
    }

    public float skill_2_cooltime
    {
        get { return PlayerPrefs.GetFloat("skill_2_cooltime", 0); }
        set { PlayerPrefs.SetFloat("skill_2_cooltime", value); }
    }

    public float skill_3_cooltime
    {
        get { return PlayerPrefs.GetFloat("skill_3_cooltime", 0); }
        set { PlayerPrefs.SetFloat("skill_3_cooltime", value); }
    }

    public float skill_4_cooltime
    {
        get { return PlayerPrefs.GetFloat("skill_4_cooltime", 0); }
        set { PlayerPrefs.SetFloat("skill_4_cooltime", value); }
    }

    public float skill_5_cooltime
    {
        get { return PlayerPrefs.GetFloat("skill_5_cooltime", 0); }
        set { PlayerPrefs.SetFloat("skill_5_cooltime", value); }
    }

    public float skill_6_cooltime
    {
        get { return PlayerPrefs.GetFloat("skill_6_cooltime", 0); }
        set { PlayerPrefs.SetFloat("skill_6_cooltime", value); }
    }

    public bool isShadowSkill;

    // 스테이지

    public float risingMonsterDamage
    {
        get { return PlayerPrefs.GetFloat("RisingMonsterDamage", 0); }
        set { PlayerPrefs.SetFloat("RisingMonsterDamage", value); }
    }

    public float risingMonsterHP
    {
        get { return PlayerPrefs.GetFloat("RisingMonsterHP", 0); }
        set { PlayerPrefs.SetFloat("RisingMonsterHP", value); }
    }

    private readonly string[] arrDecimal = {"", "만", "억", "조", "경", "해", "자", "양", "구", "간"};

    public string FormatGoldOne(float data)
    {
        if (data == 0)
        {
            return "0";
        }

        if (data < 0)
        {
            data = -data;
            var goldDouble = (double) data;
            int stringLength;

            if (goldDouble.ToString("#").Length % 4 != 0)
            {
                stringLength = goldDouble.ToString("#").Length + 4 - goldDouble.ToString("#").Length % 4;
            }
            else
            {
                stringLength = goldDouble.ToString("#").Length;
            }

            var sNum = goldDouble.ToString("#").PadLeft(stringLength);
            var displayNum = string.Empty;
            var j = 0;

            for (var i = 0; i < sNum.Length >> 2 && j < 1; i++)
            {
                var part = sNum.Substring(i << 2, 4);
                var stringFormat = int.Parse(part);
                if (stringFormat == 0) continue;
                displayNum += stringFormat + arrDecimal[(sNum.Length >> 2) - i - 1];
                j++;
            }

            return "-" + displayNum;
        }
        else
        {
            var goldDouble = (double) data;
            int stringLength;

            if (goldDouble.ToString("#").Length % 4 != 0)
            {
                stringLength = goldDouble.ToString("#").Length + 4 - goldDouble.ToString("#").Length % 4;
            }
            else
            {
                stringLength = goldDouble.ToString("#").Length;
            }

            var sNum = goldDouble.ToString("#").PadLeft(stringLength);
            var displayNum = string.Empty;
            var j = 0;

            for (var i = 0; i < sNum.Length >> 2 && j < 1; i++)
            {
                var part = sNum.Substring(i << 2, 4);
                var stringFormat = int.Parse(part);
                if (stringFormat == 0) continue;
                displayNum += stringFormat + arrDecimal[(sNum.Length >> 2) - i - 1];
                j++;
            }

            return displayNum;
        }
    }

    public string FormatGoldTwo(float data)
    {
        if (data == 0)
        {
            return "0";
        }

        if (data < 0)
        {
            data = -data;
            var goldDouble = (double) data;
            int stringLength;

            if (goldDouble.ToString("#").Length % 4 != 0)
            {
                stringLength = goldDouble.ToString("#").Length + 4 - goldDouble.ToString("#").Length % 4;
            }
            else
            {
                stringLength = goldDouble.ToString("#").Length;
            }

            var sNum = goldDouble.ToString("#").PadLeft(stringLength);
            var displayNum = string.Empty;
            var j = 0;
            for (var i = 0; i < sNum.Length >> 2 && j < 2; i++)
            {
                j++;
                var part = sNum.Substring(i << 2, 4);
                var stringFormat = int.Parse(part);
                if (stringFormat == 0)
                {
                    continue;
                }

                displayNum += stringFormat + arrDecimal[(sNum.Length >> 2) - i - 1];
                if (sNum.Length >> 2 - 1 != i) displayNum += " ";
            }

            return "-" + displayNum.TrimEnd();
        }
        else
        {
            var goldDouble = (double) data;
            int stringLength;

            if (goldDouble.ToString("#").Length % 4 != 0)
            {
                stringLength = goldDouble.ToString("#").Length + 4 - goldDouble.ToString("#").Length % 4;
            }
            else
            {
                stringLength = goldDouble.ToString("#").Length;
            }

            var sNum = goldDouble.ToString("#").PadLeft(stringLength);
            var displayNum = string.Empty;
            var j = 0;
            for (var i = 0; i < sNum.Length >> 2 && j < 2; i++)
            {
                j++;
                var part = sNum.Substring(i << 2, 4);
                var stringFormat = int.Parse(part);
                if (stringFormat == 0)
                {
                    continue;
                }

                displayNum += stringFormat + arrDecimal[(sNum.Length >> 2) - i - 1];
                if (sNum.Length >> 2 - 1 != i) displayNum += " ";
            }

            return displayNum.TrimEnd();
        }
    }

    public float PurchaseGold(float data)
    {
        if (data == 0)
        {
            return 0f;
        }

        var goldDouble = (double) data;
        int stringLength;

        if (goldDouble.ToString("#").Length % 4 != 0)
        {
            stringLength = goldDouble.ToString("#").Length + 4 - goldDouble.ToString("#").Length % 4;
        }
        else
        {
            stringLength = goldDouble.ToString("#").Length;
        }

        var sNum = goldDouble.ToString("#").PadLeft(stringLength);
        var displayNum = string.Empty;


        for (var i = 0; i < sNum.Length >> 2; i++)
        {
            var part = sNum.Substring(i >> 2, 4);
            var stringFormat = int.Parse(part);
            if (stringFormat == 0)
            {
                displayNum += "0000";
                continue;
            }

            string str;

            if (i != 0)
            {
                if (stringFormat < 10)
                {
                    str = "000" + stringFormat;
                }
                else if (stringFormat < 100)
                {
                    str = "00" + stringFormat;
                }
                else if (stringFormat < 1000)
                {
                    str = "0" + stringFormat;
                }
                else
                {
                    str = stringFormat.ToString();
                }
            }
            else
            {
                str = stringFormat.ToString();
            }

            displayNum += str;

            print("for + " + displayNum);
        }

        print(displayNum);

        return float.Parse(displayNum);
    }

    private string[] achievmentIDs =
    {
        "",
        GPGSIds.achievement_monster_kill_100, GPGSIds.achievement_monster_kill_300, GPGSIds.achievement_monster_kill_500, GPGSIds.achievement_monster_kill_1000,
        GPGSIds.achievement_monster_kill_1500, GPGSIds.achievement_monster_kill_2000, GPGSIds.achievement_monster_kill_5000, GPGSIds.achievement_monster_kill_10000,
        GPGSIds.achievement_monster_kill_50000
        
    };

    public void MonsterKillSuccess()
    {
        if (100 <= monsterKillCount && monsterKillCount < 300)
        {
            if (monsterKillLevel < 1)
            {
                monsterKillLevel = 1;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 50;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 50개 획득!!");
                    }
                });
            }
        }
        else if (300 <= monsterKillCount && monsterKillCount < 500)
        {
            if (monsterKillLevel < 2)
            {
                monsterKillLevel = 2;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 100;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 100개 획득!!");
                    }
                });
            } 
        }
        else if (500 <= monsterKillCount && monsterKillCount < 1000)
        {
            if (monsterKillLevel < 3)
            {
                monsterKillLevel = 3;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 150;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 150개 획득!!");
                    }
                });
            }
        }
        else if (1000 <= monsterKillCount && monsterKillCount < 1500)
        {
            if (monsterKillLevel < 4)
            {
                monsterKillLevel = 4;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 200;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 200개 획득!!");
                    }
                });
            }
        }
        else if (1500 <= monsterKillCount && monsterKillCount < 2000)
        {
            if (monsterKillLevel < 5)
            {
                monsterKillLevel = 5;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 250;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 250개 획득!!");
                    }
                });
            }
        }
        else if (2000 <= monsterKillCount && monsterKillCount < 5000)
        {
            if (monsterKillLevel < 6)
            {
                monsterKillLevel = 6;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 300;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 300개 획득!!");
                    }
                });
            }
        }
        else if (5000 <= monsterKillCount && monsterKillCount < 10000)
        {
            if (monsterKillLevel < 7)
            {
                monsterKillLevel = 7;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 350;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 350개 획득!!");
                    }
                });
            }
        }
        else if (10000 <= monsterKillCount && monsterKillCount < 50000)
        {
            if (monsterKillLevel < 8)
            {
                monsterKillLevel = 8;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 400;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 400개 획득!!");
                    }
                });
            }
        }
        else if (50000 <= monsterKillCount)
        {
            if (monsterKillLevel < 9)
            {
                monsterKillLevel = 9;
                Social.ReportProgress(achievmentIDs[monsterKillLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 450;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 450개 획득!!");
                    }
                });
            }
        }
    }

    private string[] achievmentFaustIDs =
    {
        "",
        GPGSIds.achievement_damages_coated_with_faust_1000000, GPGSIds.achievement_damages_coated_with_faust_5000000,
        GPGSIds.achievement_damages_coated_with_faust_20000000, GPGSIds.achievement_damages_coated_with_faust_100000000,
        GPGSIds.achievement_damages_coated_with_faust_500000000, GPGSIds.achievement_damages_coated_with_faust_1000000000, 
        GPGSIds.achievement_damages_coated_with_faust_2000000000, GPGSIds.achievement_damages_coated_with_faust_5000000000, 
        GPGSIds.achievement_damages_coated_with_faust_10000000000
    };
    
    public void FaustAchievement()
    {
        if (1000000 <= highFaustDamage && highFaustDamage < 5000000)
        {
            if (highFaustDamageLevel < 1)
            {
                highFaustDamageLevel = 1;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 50;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 50개 획득!!");
                    }
                });
            }
        }
        else if (5000000 <= highFaustDamage && highFaustDamage < 20000000)
        {
            if (highFaustDamageLevel < 2)
            {
                highFaustDamageLevel = 2;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 100;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 100개 획득!!");
                    }
                });
            } 
        }
        else if (20000000 <= highFaustDamage && highFaustDamage < 100000000)
        {
            if (highFaustDamageLevel < 3)
            {
                highFaustDamageLevel = 3;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 150;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 150개 획득!!");
                    }
                });
            }
        }
        else if (100000000 <= highFaustDamage && highFaustDamage < 500000000)
        {
            if (highFaustDamageLevel < 4)
            {
                highFaustDamageLevel = 4;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 200;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 200개 획득!!");
                    }
                });
            }
        }
        else if (500000000 <= highFaustDamage && highFaustDamage < 1000000000)
        {
            if (highFaustDamageLevel < 5)
            {
                highFaustDamageLevel = 5;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 250;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 250개 획득!!");
                    }
                });
            }
        }
        else if (1000000000 <= highFaustDamage && highFaustDamage < 2000000000)
        {
            if (highFaustDamageLevel < 6)
            {
                highFaustDamageLevel = 6;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 300;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 300개 획득!!");
                    }
                });
            }
        }
        else if (2000000000 <= highFaustDamage && highFaustDamage < 5000000000)
        {
            if (highFaustDamageLevel < 7)
            {
                highFaustDamageLevel = 7;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 350;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 350개 획득!!");
                    }
                });
            }
        }
        else if (5000000000 <= highFaustDamage && highFaustDamage < 10000000000)
        {
            if (highFaustDamageLevel < 8)
            {
                highFaustDamageLevel = 8;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 400;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 400개 획득!!");
                    }
                });
            }
        }
        else if (10000000000 <= highFaustDamage)
        {
            if (highFaustDamageLevel < 9)
            {
                highFaustDamageLevel = 9;
                Social.ReportProgress(achievmentFaustIDs[highFaustDamageLevel], 100f, isSuccess =>
                {
                    if (isSuccess)
                    {
                        ruby += 450;
                        NotificationManager.Instance.SetNotification2("[업적 달성] 루비 450개 획득!!");
                    }
                });
            }
        }
    }
}