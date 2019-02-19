﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MonsterSpwan : MonoBehaviour
{
    public GameObject[] Monsters;
    public GameObject[] BigMonsters;

    public GameObject RockObject;

    public Animator MoveScene;

    public Text StageText;

    public Transform MonsterBox;

    private int nowStage;

    private int initMonsters;

    private bool isBossSpwan;

    private float startHP = 10000;

    public static float gold = 300000;

    public static float[] ruby =
    {
        5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
    };

    public static float[] sapphire =
    {
        3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10
    };

    private bool isMonsterActive;

    private void OnEnable()
    {
        DataController.Instance.nowStage = 1;
        initMonsters = 0;
        isMonsterActive = false;
        StageText.gameObject.SetActive(false);
        StageText.gameObject.SetActive(true);
        StageText.text = "Stage " + DataController.Instance.nowStage;

        StartCoroutine(SpwanMonster());
        EventManager.StartHuntEvent += StartHunt;
        EventManager.EndGameEvnet += EndGame;
        EventManager.RewardClickEvent += RewardClick;
    }

    private void RewardClick()
    {
        MoveScene.Play("MoveScene", 0, 0);
        Invoke("SetMainScene", 0.5f);
    }

    private void SetMainScene()
    {
        RockObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        print(DataController.Instance.Monsters.childCount);
    }

    private void Update()
    {
        if (isMonsterActive && DataController.Instance.Monsters.childCount == 0 && initMonsters == 8)
        {
            if (DataController.Instance.nowStage < 5)
            {
                DataController.Instance.nowStage++;
                initMonsters = 0;
                EventManager.Instance.StartHunt();
                isMonsterActive = false;
            }
            else
            {
                if (isBossSpwan)
                {
                    DataController.Instance.nowStage++;
                    initMonsters = 0;
                    EventManager.Instance.StartHunt();
                    isMonsterActive = false;
                }
            }
        }
    }

    public GameObject GetBallPanel;
    public Image BallImage;
    public Text AvilityText;

    private void EndHunt(bool isClear)
    {
        if (isClear)
        {
            // 클리어 했을 때
            RewardManager.Instance.ShowRewardPanel((float) (gold * Math.Pow(6f, DataController.Instance.huntLevel)),
                ruby[DataController.Instance.huntLevel], sapphire[DataController.Instance.huntLevel]);

            if (DataController.Instance.finalHuntLevel == DataController.Instance.huntLevel)
            {
                // 마지막 사냥터 클리어 성공
                
                DataController.Instance.finalHuntLevel = DataController.Instance.huntLevel + 1;

                DataController.Instance.finalClearHunt = DataController.Instance.huntLevel + 1;
                
                print(DataController.Instance.huntLevel + ", " + DataController.Instance.masterSkillIndex);

                if (DataController.Instance.huntLevel == DataController.Instance.masterSkillIndex)
                {
                    if (DataController.Instance.huntLevel == 0)
                    {
                        Social.ReportProgress(GPGSIds.achievement_get_projectile, 100f, isSuccess =>
                        {
                            if (isSuccess)
                            {
                                DataController.Instance.ruby += 50;
                                NotificationManager.Instance.SetNotification2("[업적 달성] 루비 50개 획득!!");
                            }
                        });
                    }
                    
                    // 마지막 투사체 획득 시점에서 마지막 스테이지
                    print("엉");
                    BallImage.sprite =
                        Resources.Load("Ball/energyBall" + (DataController.Instance.huntLevel + 1),
                            typeof(Sprite)) as Sprite;
                    AvilityText.text = "공격력 + " + 20 * (DataController.Instance.huntLevel + 1) + "%";
                    GetBallPanel.SetActive(true);

                    DataController.Instance.masterSkillIndex = DataController.Instance.huntLevel + 1;
                    print(DataController.Instance.masterSkillIndex);
                    
                    DataController.Instance.UpdateDamage();
                }


                print("마지막 스테이지 클리어");
            }


            PlayerPrefs.SetFloat("HuntCoolTime_" + DataController.Instance.huntLevel, 300);
        }
        else
        {
            RewardManager.Instance.ShowRewardPanel(0, 0, 0);
        }
        
        DataController.Instance.MonsterKillSuccess();
    }

    private IEnumerator SpwanMonster()
    {
        var i = 0;
        var randPositionZ = 0;
        while (i < 8)
        {
            randPositionZ = Random.Range(0, 999);
            var monster = Instantiate(Monsters[DataController.Instance.huntLevel],
                new Vector3(transform.position.x, transform.position.y, randPositionZ * 0.00001f), Quaternion.identity);

            monster.GetComponent<MonsterManager>().SetMonsterAvility(
                (float) (startHP * Math.Pow(5, DataController.Instance.huntLevel)),
                (float) (startHP * Math.Pow(5, DataController.Instance.huntLevel) / 10));

            monster.transform.SetParent(DataController.Instance.Monsters);
            isMonsterActive = true;

            initMonsters++;
            i++;

            if (initMonsters == 8)
            {
                break;
            }

            yield return new WaitForSeconds(0.8f);
        }

        if (DataController.Instance.nowStage == 5)
        {
            var monster = Instantiate(BigMonsters[DataController.Instance.huntLevel],
                new Vector3(transform.position.x + 2.5f, transform.position.y, randPositionZ * 0.00001f),
                Quaternion.identity);

            monster.GetComponent<MonsterManager>().SetMonsterAvility(
                (float) (startHP * Math.Pow(5, DataController.Instance.huntLevel) * 4),
                (float) (startHP * Math.Pow(5, DataController.Instance.huntLevel)) / 2);

            monster.transform.SetParent(DataController.Instance.Monsters);
        }

        isBossSpwan = true;
    }

    public void EndGame()
    {
        EventManager.StartHuntEvent -= StartHunt;
        EventManager.EndGameEvnet -= EndGame;

        StopAllCoroutines();

        foreach (Transform monster in MonsterBox)
        {
            Destroy(monster.gameObject);
        }

        EndHunt(false);
    }

    public void StartHunt()
    {
        if (DataController.Instance.nowStage > 5)
        {
            EndHunt(true);
        }
        else
        {
            StageText.text = "Stage " + DataController.Instance.nowStage;
            StageText.gameObject.SetActive(false);
            StageText.gameObject.SetActive(true);
            Invoke("StartStage", 1f);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        EventManager.StartHuntEvent -= StartHunt;
        EventManager.EndGameEvnet -= EndGame;
        EventManager.RewardClickEvent -= RewardClick;
    }

    public void StartStage()
    {
        StartCoroutine(SpwanMonster());
    }
}