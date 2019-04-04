using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalManager : MonoBehaviour
{
    private static LocalManager _instance;

    public static LocalManager Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<LocalManager>();
            if (_instance != null) return _instance;
            var container = new GameObject("LocalManager");

            _instance = container.AddComponent<LocalManager>();

            return _instance;
        }
    }

    public string Damage;
    public string Hp;
    public string CriticalPer;
    public string CriticalRising;
    public string AngerDamage;
    public string AngerTime;
    
    public string Victory;
    public string Lose;
    public string Draw;
     
    // 알림
    public string LessGold;
    public string LessRuby;
    public string LessSapphire;
    public string LessDevilstone;
    public string UseRebirth;
    public string NoUpgrade;
    public string Internet;
    public string MaxLevel;
    public string RebirthYet;
    public string NoMenu1;
    public string NoMenu2;
    public string IsRebirth;
    public string RebirthNoti;
    public string RebirthNoti2;
    public string NoPetStone;
    
    // 인앱
    public string[] GetRuby = new string[10];
    public string[] GetSapphire = new string[10];
    public string[] GetScroll = new string[10];
    public string[] GetPotion = new string[10];
    public string[] GetPackage = new string[10];
    
    // 사냥터
    public string LessScroll;
    public string NoEnter;
    public string AfterClear;
    public string ChallengeCount;

    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            Damage = "공격력";
            Hp = "체력";
            CriticalPer = "크리티컬 확률";
            CriticalRising = "크리티컬 공격력";
            AngerTime = "분노 지속시간";
            AngerDamage = "분노 데미지";
            
            Victory = "승리!!";
            Lose = "패배";
            Draw = "무승부";
            
            LessGold = "결계석이 부족합니다.";
            LessRuby = "루비가 부족합니다.";
            LessSapphire = "사파이어가 부족합니다.";
            LessDevilstone = "데빌스톤이 부족합니다.";
            UseRebirth = "결계석의 레벨을 눌러 초월기를 사용하세요.";
            NoUpgrade = "더 이상 업그레이드 할 수 없습니다.";
            Internet = "인터넷 연결을 확인하세요.";
            MaxLevel = "최고 레벨입니다.";
            RebirthYet = "아직 초월할 수 없습니다.";
            NoMenu1 = "사냥중에는 메뉴를 열 수 없습니다.";
            NoMenu2 = "지금은 메뉴를 열 수 없습니다.";
            IsRebirth = "환생중에는 할 수 없습니다.";
            RebirthNoti = "초월 레벨 12 이상부터 도전 가능합니다.";
            RebirthNoti2 = "초월 레벨 12 이상부터 사용 가능합니다.";
            NoPetStone = "영혼석이 부족합니다.";

            GetRuby[0] = "루비 400개 획득!!";
            GetRuby[1] = "루비 2,400개 획득!!";
            GetRuby[2] = "루비 5,000개 획득!!";
            GetRuby[3] = "루비 28,000개 획득!!";
            GetRuby[4] = "루비 60,000개 획득!!";

            GetSapphire[0] = "사파이어 200개 획득!!";
            GetSapphire[1] = "사파이어 1,200개 획득!!";
            GetSapphire[2] = "사파이어 2,500개 획득!!";
            GetSapphire[3] = "사파이어 14,000개 획득!!";
            GetSapphire[4] = "사파이어 30,000개 획득!!";

            GetScroll[0] = "소탕권 5개 획득!!";
            GetScroll[1] = "소탕권 30개 획득!!";
            GetScroll[2] = "소탕권 65개 획득!!";
            GetScroll[3] = "소탕권 350개 획득!!";

            GetPotion[0] = "결계 무력화 5개 획득!!";
            GetPotion[1] = "결계 무력화 30개 획득!!";
            GetPotion[2] = "정령의 가호 5개 획득!!";
            GetPotion[3] = "정령의 가호 30개 획득!!";

            GetPackage[0] = "악마 패키지1 구매완료!!";
            GetPackage[1] = "악마 패키지2 구매완료!!";
            GetPackage[2] = "악마 패키지3 구매완료!!";
            GetPackage[3] = "물약 패키지 구매완료!!";
            GetPackage[4] = "상단 메뉴에서 스킨을 바꿀 수 있습니다.";
            GetPackage[5] = "스타터 패키지 구매완료!!";
            GetPackage[6] = "스킬 패키지 구매완료!!";
            
            LessScroll = "소탕권이 부족합니다.";
            NoEnter = "지금은 입장할 수 없습니다.";
            AfterClear = "클리어 후 소탕할 수 있습니다.";
            ChallengeCount = "도전 횟수가 부족합니다.";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Damage = "攻撃力";
            Hp = "体力";
            CriticalPer = "クリティカル確率";
            CriticalRising = "クリティカル攻撃力";
            AngerTime = "怒り持続時間";
            AngerDamage = "怒りダメージ";
            
            Victory = "勝利!!";
            Lose = "敗北";
            Draw = "引き分け";
            
            LessGold = "結界石不足します。";
            LessRuby = "ルビーが不足します。";
            LessSapphire = "サファイアが不足します。";
            LessDevilstone = "デビルストーンが不足します。";
            UseRebirth = "結界席レベルをクリックして、超越器を使用してください。";
            NoUpgrade = "これ以上アップグレードすることはできません。";
            Internet = "インターネット接続を確認してください。";
            MaxLevel = "最高レベルです。";
            RebirthYet = "まだ超越することはできません。";
            NoMenu1 = "狩猟中のメニューを開くことができません。";
            NoMenu2 = "今はメニューを開くことができません。";
            IsRebirth = "生まれ変わる中できません。";
            RebirthNoti = "超越レベル12以上から挑戦可能です。";
            RebirthNoti2 = "超越レベル12以上から使用可能です。";
            NoPetStone = "魂石が不足します。";

            GetRuby [0] = "ルビー400個獲得!!";
            GetRuby [1] = "ルビー2,400個獲得!!";
            GetRuby [2] = "ルビー5000個獲得!!";
            GetRuby [3] = "ルビー28,000個獲得!!";
            GetRuby [4] = "ルビー60,000個獲得!!";

            GetSapphire [0] = "サファイア200個獲得!!";
            GetSapphire [1] = "サファイア1,200個獲得!!";
            GetSapphire [2] = "サファイア2,500個獲得!!";
            GetSapphire [3] = "サファイア14,000個獲得!!";
            GetSapphire [4] = "サファイア30,000個獲得!!";

            GetScroll [0] = "掃討巻5個獲得!!";
            GetScroll [1] = "掃討巻30個獲得!!";
            GetScroll [2] = "掃討巻65個獲得!!";
            GetScroll [3] = "掃討巻350個獲得!!";

            GetPotion [0] = "結界無力化5個獲得!!";
            GetPotion [1] = "結界無力化30個獲得!!";
            GetPotion [2] = "精霊の加護5個獲得!!";
            GetPotion [3] = "精霊の加護30個獲得!!";

            GetPackage [0] = "悪魔パッケージ1を購入完了！";
            GetPackage [1] = "悪魔のパッケージ2を購入完了！";
            GetPackage [2] = "悪魔のパッケージ3購入完了！";
            GetPackage [3] = "ポーションパッケージ購入完了！";
            GetPackage [4] = "上部のメニューからスキンを変更することができます。";
            GetPackage [5] = "スターターパッケージ購入完了！";
            GetPackage [6] = "スキルパッケージ購入完了！";
            
            LessScroll = "掃討権が不足します。";
            NoEnter = "今は入場できません。";
            AfterClear = "クリア後の掃討することができます。";
            ChallengeCount = "挑戦回数が不足します。";
        }
        else
        {
            Damage = "Damage";
            Hp = "Hp";
            CriticalPer = "Critical Probability";
            CriticalRising = "Critical Damage";
            AngerTime = "Anger Time";
            AngerDamage = "Anger Damage";
            
            Victory = "Victory!!";
            Lose = "Lose";
            Draw = "Draw";
            
            LessGold = "There are insufficient stone.";
            LessRuby = "There are insufficient ruby.";
            LessSapphire = "There are insufficient sapphire.";
            LessDevilstone = "There are insufficient devilstone.";
            UseRebirth = "Click the level of stone to use rebirth";
            UseRebirth = "You cannot upgrade any more.";
            Internet = "Please check your Internet connection.";
            MaxLevel = "Max Level.";
            RebirthYet = "You can't rebirth yet";
            NoMenu1 = "You can't open the menu while hunting.";
            NoMenu2 = "You can't open the menu now";
            IsRebirth = "You can't do it during rebirth.";
            RebirthNoti = "you need 12 level of rebirth to challenge.";
            RebirthNoti2 = "you need 12 level of rebirth to use menu.";
            NoPetStone = "There are insufficient petStone.";
            
            GetRuby[0] = "Get 400 Ruby!!";
            GetRuby[1] = "Get 2,400 Ruby!!";
            GetRuby[2] = "Get 5,000 Ruby!!";
            GetRuby[3] = "Get 28,000 Ruby!!";
            GetRuby[4] = "Get 60,000 Ruby!!";

            GetSapphire[0] = "Get 400 Sapphire!!";
            GetSapphire[1] = "Get 1,200 Sapphire!!";
            GetSapphire[2] = "Get 2,500 Sapphire!!";
            GetSapphire[3] = "Get 14,000 Sapphire!!";
            GetSapphire[4] = "Get 30,000 Sapphire!!";

            GetScroll[0] = "Get 5 Scroll!!";
            GetScroll[1] = "Get 30 Scroll!!";
            GetScroll[2] = "Get 65 Scroll!!";
            GetScroll[3] = "Get 350 Scroll!!";

            GetPotion[0] = "Get 5 Powerless!!";
            GetPotion[1] = "Get 30 Powerless!!";
            GetPotion[2] = "Get 5 GodBless!!";
            GetPotion[3] = "Get 30 GodBless!!";

            GetPackage[0] = "Purchase DevilPackage1 Succeed!!";
            GetPackage[1] = "Purchase DevilPackage2 Succeed!!";
            GetPackage[2] = "Purchase DevilPackage2 Succeed!!";
            GetPackage[3] = "Purchase PotionPackage Succeed!!";
            GetPackage[4] = "You can change the skin from the top menu.";
            GetPackage[5] = "Purchase StartPackage Succeed!!";
            GetPackage[6] = "Purchase SkillPackage Succeed!!";
            
            LessScroll = "There are insufficient scroll";
            NoEnter = "You can not enter now.";
            AfterClear = "You can sweep after clearing.";
            ChallengeCount = "Challenges are insufficient.";
        }
    }
}
