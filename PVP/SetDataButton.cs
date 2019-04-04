using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SetDataButton : MonoBehaviour
{
    public GameObject Loading;
    public Text InfoText;
    
    private DatabaseReference userReference;

    public Transform SkillPanel;
    public GameObject[] SkillButtons;

    public Text TimeText;

    private void Awake()
    {
        userReference = FirebaseManager.Instance.Reference.Child("PVP");
    }

    private string[] randName =
    {
        "준용", "현준", "현기", "동구", "벽진",
        "성국", "용훈", "정식", "지미", "주현",
        "소연", "석준", "진영", "민호", "정언",
        "예인", "연주", "정호", "민지", "마커"
    };

    private List<PvpData> pvpDatas = new List<PvpData>();

    private void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            var textComponents = FindObjectsOfTypeAll(typeof(Text)) as Text[];
            foreach (var textComponent in textComponents)
            {
                textComponent.font = Resources.Load<Font>("Font/Japan3");
            }
        }
        PlayerPrefs.SetFloat("StartGame", 1);
        
        InvokeRepeating("RecordTime", 5, 5);
        
        SyncButton();
        
        EventManager.StartPvpEvent += SetSkill;
        EventManager.EndPvpEvent += EndGame;
    }

    private void OnDestroy()
    {
        EventManager.StartPvpEvent -= SetSkill;
        EventManager.EndPvpEvent -= EndGame;
    }

    private float time;
    
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimeText.text = Math.Round(time).ToString();
        }
        else
        {
            TimeText.text = "0";
        }
    }

    public void DrewGame()
    {
        
        EventManager.Instance.EndPvp(2);
    }
    
    public void RecordTime()
    {
        DataController.Instance.lastPlayTime += 5;
        if (DataController.Instance.lastPlayTime > 86400)
        {
            DataController.Instance.lastPlayTime = 0;
        }
        
//        var user = new UserRankData
//        {
//            costumeIndex = DataController.Instance.costumeIndex,
//            skinIndex =  DataController.Instance.skinIndex
//        };
//        
//        var json = JsonUtility.ToJson(user);
//        if (PlayGamesPlatform.Instance.localUser.id != "")
//        {
//            userReference1.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(task =>
//            {
//                if (task.IsCompleted)
//                {
//                }
//            });
//        }
        
    }

    private void SetSkill()
    {
        DataController.Instance.PlayerDamage = 0;
        DataController.Instance.AIDamage = 0;
        
        
        Loading.SetActive(false);
        time = 10;
        Invoke("DrewGame", 10);
        
        InvokeRepeating("InitSkill", 1f, 2.5f);
    }

    private void InitSkill()
    {
        var skill = Instantiate(SkillButtons[Random.Range(0, SkillButtons.Length)],
            new Vector3(Random.Range(-700, 700), Random.Range(20, -350), 0), Quaternion.identity);
        
        skill.transform.SetParent(SkillPanel, false);
    }

    private void EndGame(int i)
    {
        DataController.Instance.isPvpReady = false;
        pvpDatas.Clear();
        
        CancelInvoke();

        time = 0;
        
        foreach (Transform stone in SkillPanel)
        {
            Destroy(stone.gameObject);
        }
        
        Loading.SetActive(true);
        // 스코어 갱신 및 스킬 누른 시간 갱신
        if (DataController.Instance.PlayerDamage - DataController.Instance.AIDamage > 0)
        {
            // 승리
            InfoText.text = LocalManager.Instance.Victory;
            if (DataController.Instance.PlayerData.score < 10000)
            {
                DataController.Instance.PlayerData.score += 5;
            }
            var json = JsonUtility.ToJson(DataController.Instance.PlayerData);

            var randInt = Random.Range(1, 3);
            DataController.Instance.ruby += randInt;
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                NotificationManager.Instance.SetNotification2("루비 " + randInt + "개 획득!!");   
            }
            else
            {
                NotificationManager.Instance.SetNotification2("Get " + randInt + " Ruby!!");   
            }

            userReference.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    SetAIData();
                }
            });
        }
        else if(DataController.Instance.PlayerDamage - DataController.Instance.AIDamage < 0)
        {
            // 패배
            InfoText.text = LocalManager.Instance.Lose;
            if (DataController.Instance.PlayerData.score > 5)
            {
                DataController.Instance.PlayerData.score -= 5;
            }

            var json = JsonUtility.ToJson(DataController.Instance.PlayerData);

            userReference.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    SetAIData();
                }
            });
        }
        else if (DataController.Instance.PlayerDamage - DataController.Instance.AIDamage == 0)
        {
            // 무승부
            InfoText.text = LocalManager.Instance.Draw;
            var json = JsonUtility.ToJson(DataController.Instance.PlayerData);
            userReference.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    SetAIData();
                }
            });
        }

        // 다음 상대 데이터 준비
    }

    public void SyncButton()
    {
        if (Social.localUser.authenticated)
        {
            if (PlayerPrefs.GetFloat("FirstPvp", 0) == 0)
            {
                // PVP 처음 입장

                PlayerPrefs.SetFloat("FirstPvp", 1);

                var criticalPer = DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                                  DataController.Instance.devilCritical +
                                  DataController.Instance.collectionCriticalPer +
                                  DataController.Instance.advancedCriticalPer + DataController.Instance.skinCriticalPer;

                var user = new PvpData
                {
                    userName = PlayGamesPlatform.Instance.localUser.userName,
                    score = 1000,

                    skillIndex = DataController.Instance.skillIndex,
                    costumeIndex = DataController.Instance.costumeIndex,
                    skinIndex = DataController.Instance.skinIndex,

                    damage = DataController.Instance.masterDamage,
                    criticalPercent = criticalPer,
                    criticalDamage = DataController.Instance.masterCriticalDamage,
                    Hp = DataController.Instance.GetPlayerHP(),

                    skillClickTime = Random.Range(0.5f, 1f),

                    skill_1_damage = DataController.Instance.skill_1_damage,
                    skill_2_damage = DataController.Instance.skill_2_damage,
                    skill_3_time = DataController.Instance.skill_3_time,
                    skill_4_damage = DataController.Instance.skill_4_damage,
                    skill_5_damage = DataController.Instance.skill_5_damage,
                    skill_6_damage = DataController.Instance.skill_6_damage
                };

                DataController.Instance.PlayerData = user;

                var json = JsonUtility.ToJson(user);

                userReference.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        SetAIData();
                    }
                });
            }
            else
            {
                userReference.Child(PlayGamesPlatform.Instance.localUser.id).GetValueAsync().ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        var userData = JsonUtility.FromJson<PvpData>(task.Result.GetRawJsonValue());

                        var criticalPer = DataController.Instance.criticalPercent +
                                          DataController.Instance.rubyCriticalPer +
                                          DataController.Instance.devilCritical +
                                          DataController.Instance.collectionCriticalPer +
                                          DataController.Instance.advancedCriticalPer +
                                          DataController.Instance.skinCriticalPer;


                        var damage = DataController.Instance.masterDamage >= userData.damage
                            ? DataController.Instance.masterDamage
                            : userData.damage;

                        var criticalPercent = criticalPer >= userData.criticalPercent
                            ? criticalPer
                            : userData.criticalPercent;


                        var criticalDamage = DataController.Instance.masterCriticalDamage >= userData.criticalDamage
                            ? DataController.Instance.masterCriticalDamage
                            : userData.criticalDamage;

                        var hp = DataController.Instance.GetPlayerHP() >= userData.Hp
                            ? DataController.Instance.GetPlayerHP()
                            : userData.Hp;

                        var user = new PvpData
                        {
                            userName = PlayGamesPlatform.Instance.localUser.userName,
                            score = userData.score,

                            skillIndex = DataController.Instance.skillIndex,
                            costumeIndex = DataController.Instance.costumeIndex,
                            skinIndex = DataController.Instance.skinIndex,

                            damage = damage,
                            criticalPercent = criticalPercent,
                            criticalDamage = criticalDamage,
                            Hp = hp,

                            skillClickTime = userData.skillClickTime,

                            skill_1_damage = DataController.Instance.skill_1_damage,
                            skill_2_damage = DataController.Instance.skill_2_damage,
                            skill_3_time = DataController.Instance.skill_3_time,
                            skill_4_damage = DataController.Instance.skill_4_damage,
                            skill_5_damage = DataController.Instance.skill_5_damage,
                            skill_6_damage = DataController.Instance.skill_6_damage
                        };

                        // 플레이어 데이터 셋팅
                        DataController.Instance.PlayerData = user;

                        var json = JsonUtility.ToJson(user);

                        userReference.Child(PlayGamesPlatform.Instance.localUser.id).SetRawJsonValueAsync(json).ContinueWith(
                            task1 =>
                            {
                                if (task1.IsCompleted)
                                {
                                    SetAIData();
                                }
                            });
                    }
                });
            }
        }
    }

    private void SetAIData()
    {
        if (DataController.Instance.PlayerData.score > 0 && DataController.Instance.PlayerData.score <= 1200)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 1200);
        }
        else if (DataController.Instance.PlayerData.score > 1200 && DataController.Instance.PlayerData.score <= 1400)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 1400);
        }
        else if (DataController.Instance.PlayerData.score > 1400 && DataController.Instance.PlayerData.score <= 1600)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 1600);
        }
        else if (DataController.Instance.PlayerData.score > 1600 && DataController.Instance.PlayerData.score <= 1800)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 1800);
        }
        else if (DataController.Instance.PlayerData.score > 1800 && DataController.Instance.PlayerData.score <= 2100)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 2100);
        }
        else if (DataController.Instance.PlayerData.score > 2100 && DataController.Instance.PlayerData.score <= 2400)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 2400);
        }
        else if (DataController.Instance.PlayerData.score > 2400 && DataController.Instance.PlayerData.score <= 2700)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 2700);
        }
        else if (DataController.Instance.PlayerData.score > 2700 && DataController.Instance.PlayerData.score <= 3000)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 3000);
        }
        else if (DataController.Instance.PlayerData.score > 3000)
        {
            UpdateAIData(DataController.Instance.PlayerData.score, 10000);
        }
    }

    private void UpdateAIData(int score, int end)
    {
        userReference.OrderByChild("score").StartAt(score + 1).EndAt(end).LimitToFirst(10).GetValueAsync()
            .ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    try
                    {
                        foreach (var data in task.Result.Children)
                        {
                            pvpDatas.Add(JsonUtility.FromJson<PvpData>(data.GetRawJsonValue()));
                        }

                        var userData = pvpDatas[(int) Random.Range(0, task.Result.ChildrenCount)];

                        DataController.Instance.AIData = userData;
                        
                        DataController.Instance.isPvpReady = true;
                    }
                    catch (Exception e)
                    {   
                        var user = new PvpData
                        {
                            score = DataController.Instance.PlayerData.score + 10,

                            skillIndex = DataController.Instance.skillIndex,
                            costumeIndex = DataController.Instance.PlayerData.costumeIndex,
                            skinIndex = DataController.Instance.PlayerData.skinIndex,

                            Hp = DataController.Instance.PlayerData.Hp,
                            damage = DataController.Instance.PlayerData.damage,
                            criticalDamage = DataController.Instance.PlayerData.criticalDamage,
                            criticalPercent = DataController.Instance.PlayerData.criticalPercent,

                            skillClickTime = Random.Range(0.6f, 1f),

                            skill_1_damage = DataController.Instance.PlayerData.skill_1_damage,
                            skill_2_damage = DataController.Instance.PlayerData.skill_2_damage,
                            skill_3_time = DataController.Instance.PlayerData.skill_3_time,
                            skill_4_damage = DataController.Instance.PlayerData.skill_4_damage,
                            skill_5_damage = DataController.Instance.PlayerData.skill_5_damage,
                            skill_6_damage = DataController.Instance.PlayerData.skill_6_damage,
                            userName = randName[Random.Range(0, randName.Length)]
                        };


                        // 이름 1에서 이름 2로 수정
                        user.Hp += user.Hp * Random.Range(-20, 20) / 100;
                        user.damage += user.damage * Random.Range(-20, 20) / 100;
                        user.criticalDamage += user.criticalDamage * Random.Range(-20, 20) / 100;

                        DataController.Instance.AIData = user;

                        DataController.Instance.isPvpReady = true;
//                        Loading.SetActive(false);
                        
                        throw;
                    }
                }


            });
    }
}