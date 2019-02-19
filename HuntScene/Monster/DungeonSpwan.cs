using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpwan : MonoBehaviour
{
    public GameObject[] Monsters;

    public GameObject RockObject;

    public Animator MoveScene;

    public Transform MonsterBox;

    private int index = 0;

    private float[] gold =
    {
        2000000, 10000000, 200000
    };

    private float[] ruby =
    {
        1, 2, 2, 3, 3, 3, 4, 4, 4, 4
    };

    private float[] sapphire =
    {
        1, 3, 5, 7, 9, 12, 15, 18
    };

    private void OnEnable()
    {
        StartCoroutine("SpwanMonster");

        EventManager.EndGameEvnet += EndGame;
        EventManager.RewardClickEvent += RewardClick;
    }

    private void Update()
    {
        if (index > 18)
        {
            if (MonsterBox.childCount == 0)
            {
                index = 0;
                EndHunt(true);
            }
        }
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

    private void EndHunt(bool isClear)
    {
        if (isClear)
        {
            RewardManager.Instance.ShowRewardPanel(gold[DataController.Instance.dungeonLevel],
                ruby[DataController.Instance.dungeonLevel], sapphire[DataController.Instance.dungeonLevel]);

            if (DataController.Instance.finalDungeonLevel == DataController.Instance.dungeonLevel)
            {
                DataController.Instance.finalDungeonLevel = DataController.Instance.dungeonLevel + 1;
            }
        }
        else
        {
            RewardManager.Instance.ShowRewardPanel(0, 0, 0);
        }
    }

    public void EndGame()
    {
        index = 0;
        EventManager.EndGameEvnet -= EndGame;

        StopAllCoroutines();

        foreach (Transform monster in MonsterBox)
        {
            Destroy(monster.gameObject);
        }

        EndHunt(false);
    }

    private IEnumerator SpwanMonster()
    {
        var i = 0;
        while (i < 30)
        {
            var randPositionZ = Random.Range(0, 999);
            var randMonster = Random.Range(0, 3);
            var monster = Instantiate(Monsters[DataController.Instance.dungeonLevel * 3 + randMonster],
                new Vector3(transform.position.x, transform.position.y, randPositionZ * 0.00001f), Quaternion.identity);

            monster.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            monster.GetComponent<MonsterManager>().SetMonsterAvility(500000, 500000/100);

            monster.transform.SetParent(DataController.Instance.Monsters);

            print(i);
            i++;

            index++;


            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        EventManager.EndGameEvnet -= EndGame;
        EventManager.RewardClickEvent -= RewardClick;
    }
}