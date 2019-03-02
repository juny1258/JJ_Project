using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    private static RewardManager _instance;

    public static RewardManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RewardManager>();
            }

            return _instance;
        }
    }

    public GameObject RewardPanel;
    public Transform ItemGridView;
    public GameObject Item;

    public GameObject BossRewardPanel;
    public Text TotalDamageText;
    public Text GetDevilStoneText;

    public void ShowRewardPanel(float ruby, float sapphire)
    {
        foreach (Transform item in ItemGridView)
        {
            Destroy(item.gameObject);
        }

        var gold = (DataController.Instance.damage
                    + DataController.Instance.damage * DataController.Instance.rubyRisingDamage
                    + DataController.Instance.damage * DataController.Instance.masterSkillIndex * 0.2f
                    + DataController.Instance.damage * DataController.Instance.collectionDamage
                    + DataController.Instance.damage * DataController.Instance.devilDamage
                    + DataController.Instance.damage * DataController.Instance.advancedDamage
                    + DataController.Instance.damage * DataController.Instance.legendDevilStone *
                    DataController.Instance.nowRebirthLevel * 3
                    + DataController.Instance.damage * DataController.Instance.skinDamage)
                   * 100 *
                   DataController.Instance.collectionGoldRising;

        var item1 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        item1.GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Gold/stone", typeof(Sprite)) as Sprite;
        item1.GetComponentInChildren<Text>().text = DataController.Instance.FormatGoldOne(gold);

        DataController.Instance.getGold = gold;

        var item2 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        item2.GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Gold/ruby", typeof(Sprite)) as Sprite;
        item2.GetComponentInChildren<Text>().text = ruby.ToString();

        DataController.Instance.getRuby = ruby;

        var item3 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        item3.GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
        item3.GetComponentInChildren<Text>().text = sapphire.ToString();

        DataController.Instance.getSapphire = sapphire;

        item1.transform.SetParent(ItemGridView, false);
        item2.transform.SetParent(ItemGridView, false);
        item3.transform.SetParent(ItemGridView, false);

        if (Random.Range(0, 200) == 0 && ruby != 0)
        {
            var randInt = Random.Range(0, 16);

            var item4 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);

            switch (randInt)
            {
                case 0:
                    DataController.Instance.collectionHp += 0.02f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 1:
                    DataController.Instance.collectionCriticalPer += 0.5f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 2:
                    DataController.Instance.collectionAngerTime += 0.01f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 3:
                    DataController.Instance.collectionGoldRising += 0.01f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 4:
                    DataController.Instance.collectionCoolTime += 1;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 5:
                    DataController.Instance.collectionAngerDamage += 0.02f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 6:
                    DataController.Instance.collectionRubyRising += 1;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 7:
                    DataController.Instance.collectionSappaireRising += 1;

                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 8:
                    DataController.Instance.collectionGoldRising += 0.01f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 9:
                    DataController.Instance.collectionDevilStoneRising += 1;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 10:
                    DataController.Instance.collectionRebirthRising += 0.02f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 11:
                    DataController.Instance.collectionCriticalDamage += 0.03f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 12:
                    DataController.Instance.collectionDamage += 0.03f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 13:
                    DataController.Instance.collectionFaustDamage += 0.02f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 14:
                    DataController.Instance.collectionFaustDamage += 0.02f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
                case 15:
                    DataController.Instance.collectionFaustDamage += 0.02f;
                    item4.GetComponentsInChildren<Image>()[1].sprite =
                        Resources.Load("UI/Item/relic" + randInt, typeof(Sprite)) as Sprite;
                    break;
            }

            item4.GetComponentInChildren<Text>().text = "1";

            DataController.Instance.collectionDamage += 0.03f;
            PlayerPrefs.SetInt("CollectionItem_" + randInt, PlayerPrefs.GetInt("CollectionItem_" + randInt) + 1);

            if (DataController.Instance.relicCount == 0)
            {
                Social.ReportProgress(GPGSIds.achievement_relic_acquisition, 100f, isSuccess => { });
            }

            DataController.Instance.relicCount++;

            if (Social.localUser.authenticated)
            {
                Social.ReportScore(DataController.Instance.relicCount, GPGSIds.leaderboard_5, success =>
                {
                    if (success)
                    {
                        print("Success");
                    }
                });
            }

            DataController.Instance.UpdateDamage();
            DataController.Instance.UpdateCritical();

            DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

            item4.transform.SetParent(ItemGridView, false);
        }

        RewardPanel.SetActive(true);
    }

    public void ShowRewardPanel1(float ruby, float sapphire)
    {
        foreach (Transform item in ItemGridView)
        {
            Destroy(item.gameObject);
        }

        var item1 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        item1.GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Gold/stone", typeof(Sprite)) as Sprite;
        item1.GetComponentInChildren<Text>().text = DataController.Instance.FormatGoldOne(0);

        DataController.Instance.getGold = 0;

        var item2 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        item2.GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Gold/ruby", typeof(Sprite)) as Sprite;
        item2.GetComponentInChildren<Text>().text = ruby.ToString();

        DataController.Instance.getRuby = ruby;

        var item3 = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        item3.GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Gold/sapphire", typeof(Sprite)) as Sprite;
        item3.GetComponentInChildren<Text>().text = sapphire.ToString();

        DataController.Instance.getSapphire = sapphire;

        item1.transform.SetParent(ItemGridView, false);
        item2.transform.SetParent(ItemGridView, false);
        item3.transform.SetParent(ItemGridView, false);

        RewardPanel.SetActive(true);
    }

    public void ShowBossRewardPanel(float damage, float devilStone)
    {
        TotalDamageText.text = GetThousandCommaText(damage);
        GetDevilStoneText.text = "X " + devilStone;
        var randInt = Random.Range(0, 100);

        if (randInt < DataController.Instance.collectionDevilStoneRising)
        {
            DataController.Instance.devilStone += devilStone * 2;
        }
        else
        {
            DataController.Instance.devilStone += devilStone;
        }

        BossRewardPanel.SetActive(true);
    }

    public string GetThousandCommaText(float data)
    {
        return string.Format("{0:#,###}", data);
    }
}