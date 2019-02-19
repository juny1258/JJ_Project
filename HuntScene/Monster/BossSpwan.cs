using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossSpwan : MonoBehaviour
{
    public GameObject[] BossMonsters;

    public GameObject RockObject;

    public Animator MoveScene;

    public Transform MonsterBox;

    private int index;

    private float startHP = 500000;

    public static float gold = 1500000;

    public static float[] ruby =
    {
        8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30
    };

    public static float[] sapphire =
    {
        4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15
    };

    private void OnEnable()
    {
        var randPositionZ = Random.Range(0, 999);

        var monster = Instantiate(BossMonsters[DataController.Instance.bossLevel],
            new Vector3(transform.position.x, transform.position.y, randPositionZ * 0.00001f), Quaternion.identity);

        monster.GetComponent<MonsterManager>().SetMonsterAvility(
            (float) (startHP * Math.Pow(5, DataController.Instance.bossLevel)),
            (float) (startHP * Math.Pow(5, DataController.Instance.bossLevel) / 10));

        monster.transform.SetParent(DataController.Instance.Monsters);

        index = 1;

        EventManager.EndGameEvnet += EndGame;
        EventManager.RewardClickEvent += RewardClick;
    }

    private void Update()
    {
        if (index > 0)
        {
            if (MonsterBox.childCount == 0)
            {
                index = 0;
                EndHunt(true);
            }
        }
    }

    public void EndGame()
    {
        index = 0;
        EventManager.EndGameEvnet -= EndGame;

        foreach (Transform monster in MonsterBox)
        {
            Destroy(monster.gameObject);
        }

        EndHunt(false);
    }

    public GameObject GetCostumePanel;
    public Image CostumeImage;
    public Text AvilityText;

    private void EndHunt(bool isClear)
    {
        if (isClear)
        {
            RewardManager.Instance.ShowRewardPanel((float) (gold * Math.Pow(6, DataController.Instance.bossLevel)),
                ruby[DataController.Instance.bossLevel], sapphire[DataController.Instance.bossLevel]);

            if (DataController.Instance.finalBossLevel == DataController.Instance.bossLevel)
            {
                DataController.Instance.finalBossLevel = DataController.Instance.bossLevel + 1;

                DataController.Instance.finalClearBoss = DataController.Instance.bossLevel + 1;

                if (DataController.Instance.bossLevel == DataController.Instance.masterCostumeIndex)
                {
                    if (DataController.Instance.bossLevel == 0)
                    {
                        Social.ReportProgress(GPGSIds.achievement_get_costume, 100f, isSuccess =>
                        {
                            if (isSuccess)
                            {
                                DataController.Instance.ruby += 50;
                                NotificationManager.Instance.SetNotification2("[업적 달성] 루비 50개 획득!!");
                            }
                        });
                    }
                    
                    CostumeImage.sprite = Resources.Load(
                        "Player/Costume" + (DataController.Instance.bossLevel + 1) + "/Costume",
                        typeof(Sprite)) as Sprite;
                    AvilityText.text = "체력 + " + 20 * (DataController.Instance.bossLevel + 1) + "%";
                    GetCostumePanel.SetActive(true);
                    
                    DataController.Instance.masterCostumeIndex = DataController.Instance.bossLevel + 1;

                    DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
                }
                

                print("마지막 스테이지 클리어");
            }

            PlayerPrefs.SetFloat("BossCoolTime_" + DataController.Instance.bossLevel, 300);
        }
        else
        {
            RewardManager.Instance.ShowRewardPanel(0, 0, 0);
        }
    }

    private void OnDisable()
    {
        EventManager.RewardClickEvent -= EndGame;
        EventManager.RewardClickEvent -= RewardClick;
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
}