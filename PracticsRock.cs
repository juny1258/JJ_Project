using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticsRock : MonoBehaviour
{
    public GameObject GoldObject;

    public GameObject Skill_1_Effect;

    private Vector3 TextPosition;

    private Vector3 GoldPosition;

    public Slider HpSlider;

    public Text LevelText;

    public GameObject Glow;

    public Transform Stones;
    private int level;

    private float rockHp = 100000;

    private float risingHp;

    private float upgradePower = 3f;

    private float getGoldPer = 3.8f;

    private void Start()
    {
        InvokeRepeating("FillHp", 0f, 3f);
    }

    private void OnEnable()
    {
        GoldPosition = new Vector3(4.8f, -1.45f, 0);
        TextPosition = new Vector3(5.7f, 1f, 0);

        level = DataController.Instance.nowRebirthLevel;
        HpSlider.maxValue = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
        HpSlider.value = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
        LevelText.text = (DataController.Instance.nowRebirthLevel+1).ToString();

        Glow.SetActive(DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel > 0);

        EventManager.UseSkillEvent += PlaySkill;
        EventManager.RebirthEvent += ResetData;
    }

    public void ResetData()
    {
        level = DataController.Instance.nowRebirthLevel;
        HpSlider.maxValue = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
        HpSlider.value = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
        LevelText.text = (DataController.Instance.nowRebirthLevel + 1).ToString();

        Glow.SetActive(DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel > 0);
    }

    public void FillHp()
    {
        HpSlider.value = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
    }

    public void PlaySkill(int index)
    {
        if (transform.position.x < 12)
        {
            if (index == 2)
            {
                StartCoroutine("Skill_2");
            }
            else if (index == 3)
            {
                StartCoroutine("ExplosionSkill");
            }
            else if (index == 4)
            {
                StartCoroutine("HolyExpllosion");
            }
        }
    }

    private void Update()
    {
        if (HpSlider.value == 0 &&
            DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel == 0)
        {
            DataController.Instance.rebirthLevel++;
            if (DataController.Instance.rebirthLevel > level)
            {
                level = DataController.Instance.nowRebirthLevel;
                HpSlider.maxValue = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
                HpSlider.value = rockHp * Mathf.Pow(upgradePower, DataController.Instance.nowRebirthLevel);
                LevelText.text = (DataController.Instance.nowRebirthLevel+1).ToString();
                Glow.SetActive(DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel > 0);
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        EventManager.UseSkillEvent -= PlaySkill;
        EventManager.RebirthEvent -= ResetData;
//        EventManager.OpenMenuEvent -= OpenMenu;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Attack":
            {
                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage), false);

                var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
                gold.transform.SetParent(Stones);
                var rand = Random.Range(-80f, 80f);
                gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
                DataController.Instance.goldQueue.Enqueue(DataController.Instance.masterDamage / getGoldPer *
                                                          DataController.Instance.collectionGoldRising *
                                                          DataController.Instance.useGoldBuff);

                HpSlider.value -= DataController.Instance.masterDamage;
                break;
            }
            case "CriticalAttack":
            {
                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage),
                    true);

                var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
                gold.transform.SetParent(Stones);
                var rand = Random.Range(-80f, 80f);
                gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
                DataController.Instance.goldQueue.Enqueue(DataController.Instance.masterCriticalDamage / getGoldPer *
                                                          DataController.Instance.collectionGoldRising *
                                                          DataController.Instance.useGoldBuff);

                HpSlider.value -= DataController.Instance.masterCriticalDamage;
                break;
            }
            case "Bat":
                StartCoroutine("Skill_1");
                break;
            case "FxTemporaire":
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine("DustSkill");
                break;
        }
    }

    private IEnumerator Skill_1()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_1_damage;
        var i = 0;
        while (i < 10)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer *
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);

            i++;


            HpSlider.value -= criticalDamage;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator Skill_2()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_2_damage;
        var i = 0;
        while (i < 10)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer *
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);

            HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator DustSkill()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_4_damage;
        var i = 0;
        while (i < 3)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer *
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);

            HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator ExplosionSkill()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_5_damage;
        var i = 0;
        while (i < 10)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer *
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);

            HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator HolyExpllosion()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_6_damage;
        var i = 0;
        while (i < 16)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer *
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);

            HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
}