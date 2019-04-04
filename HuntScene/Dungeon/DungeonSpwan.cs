using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DungeonSpwan : MonoBehaviour
{
    public GameObject[] Monsters;

    public GameObject RockObject;

    public Animator MoveScene;

    public Text StageText;

    public Transform MonsterBox;

    public Slide back1;
    public Slide back2;
    public Slide back3;

    public Animator CharacterAnimation;

    public GameObject NomalBackground;
    public GameObject DungeonBackground;

    public Animator[] PetAnimator;

    public GameObject RewardBox;

    private int initMonsters;

    private float startHP;

    private bool isMonsterActive;
    
    private bool isGameDone;

    private int nowStage;

    private void OnEnable()
    {
        isGameDone = false;
        DataController.Instance.dungeonPetStone = 0;
        DataController.Instance.dungeonRuby = 0;
        DataController.Instance.dungeonSapphire = 0;

        startHP = 1000000000;

        switch (DataController.Instance.dungeonLevel)
        {
            case 1:
                startHP *= 1;
                break;
            case 2:
                startHP *= 30;
                break;
            case 3:
                startHP *= 200;
                break;
        }

        nowStage = 0;
        DataController.Instance.isMove = true;
        SetFlyCostume();
        initMonsters = 0;
        isMonsterActive = false;
        StageText.gameObject.SetActive(false);
        StageText.gameObject.SetActive(true);
        StageText.text = "Stage " + (nowStage + 1);
        EventManager.EndGameEvnet += EndGame;
        EventManager.RewardClickEvent += RewardClick;

        back1.scrollSpeed = 0.2f;
        back2.scrollSpeed = 0.3f;
        back3.scrollSpeed = 0.25f;


        Invoke("StartStage", 4);
    }

    private void RewardClick()
    {
        MoveScene.Play("MoveScene", 0, 0);
        Invoke("SetMainScene", 0.5f);
    }

    private void SetMainScene()
    {
        NomalBackground.SetActive(true);
        DungeonBackground.SetActive(false);
        RockObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        print(DataController.Instance.Monsters.childCount);
    }

    private void Update()
    {
        if (isMonsterActive && DataController.Instance.Monsters.childCount == 0 && initMonsters == 20
            && !isGameDone)
        {
            nowStage++;
            initMonsters = 0;
            StartHunt();
            isMonsterActive = false;
            if (Social.localUser.authenticated)
            {
                // login success
                float highScore = nowStage;
                string leaderBoardId = GPGSIds.leaderboard_best_dungeon;

                Social.ReportScore((long) highScore, leaderBoardId, success =>
                {
                    if (success)
                    {
                        print("Success");
                    }
                });
            }
        }
    }

    private void EndHunt()
    {
        // 클리어 했을 때
        // 보상 지급
        RewardManager.Instance.ShowDungeonRewardPanel(DataController.Instance.dungeonRuby,
            DataController.Instance.dungeonSapphire, DataController.Instance.dungeonPetStone);

        if (Social.localUser.authenticated)
        {
            DataController.Instance.MonsterKillSuccess();
        }
    }

    public void EndGame()
    {
        isGameDone = true;
        StopAllCoroutines();

        foreach (Transform monster in MonsterBox)
        {
            Destroy(monster.gameObject);
        }

        EndHunt();
    }

    public void StartHunt()
    {
        StageText.text = "Stage " + (nowStage + 1);
        StageText.gameObject.SetActive(false);
        StageText.gameObject.SetActive(true);
        back1.scrollSpeed = 0.2f;
        back2.scrollSpeed = 0.3f;
        back3.scrollSpeed = 0.25f;
        DataController.Instance.isMove = true;
        SetFlyCostume();
        Instantiate(RewardBox, new Vector3(13f, -2.5f, 0), Quaternion.identity);
        Invoke("StartStage", 4f);
    }

    private void OnDisable()
    {
        EventManager.EndGameEvnet -= EndGame;
        EventManager.RewardClickEvent -= RewardClick;
        StopAllCoroutines();
    }

    public void StartStage()
    {
        StartCoroutine(SpwanMonster());
    }

    private IEnumerator SpwanMonster()
    {
        back1.scrollSpeed = 0f;
        back2.scrollSpeed = 0f;
        back3.scrollSpeed = 0f;
        DataController.Instance.isMove = false;
        SetCostume();
        var i = 0;
        while (i < 20)
        {
            var randPositionZ = Random.Range(0, 999);
            var monster = Instantiate(Monsters[Random.Range(0, Monsters.Length)],
                new Vector3(transform.position.x, transform.position.y, randPositionZ * 0.00001f), Quaternion.identity);

            monster.GetComponent<MonsterManager>().SetMonsterAvility(
                (float) (startHP * Math.Pow(1.5f, nowStage)),
                (float) (startHP * Math.Pow(1.5f, nowStage) / 30));

            monster.GetComponent<MonsterManager>().speed = 150;

            monster.transform.SetParent(DataController.Instance.Monsters);
            isMonsterActive = true;

            initMonsters++;
            i++;

            if (initMonsters == 20)
            {
                break;
            }

            yield return new WaitForSeconds(0.8f);
        }
    }

    private void SetFlyCostume()
    {
        if (DataController.Instance.skinIndex == 0)
        {
            CharacterAnimation.Play("Fly" + DataController.Instance.costumeIndex, 0, 0);
        }
        else
        {
            CharacterAnimation.Play("SkinFly" + DataController.Instance.skinIndex, 0, 0);
        }

        if (DataController.Instance.petIndex > -1)
        {
            PetAnimator[DataController.Instance.petIndex].Play("idle", 0, 0);
        }
    }

    private void SetCostume()
    {
        if (DataController.Instance.skinIndex == 0)
        {
            CharacterAnimation.Play("Attack" + DataController.Instance.costumeIndex, 0, 1);
        }
        else
        {
            CharacterAnimation.Play("SkinAttack" + DataController.Instance.skinIndex, 0, 1);
        }

        if (DataController.Instance.petIndex > -1)
        {
            PetAnimator[DataController.Instance.petIndex].Play("attack", 0, 0);
        }
    }
}