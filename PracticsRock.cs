using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticsRock : MonoBehaviour
{
    public GameObject GoldObject;
    public GameObject RubyObject;

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
        LevelText.text = (DataController.Instance.nowRebirthLevel + 1).ToString();

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

    public GameObject TutorialPanel;

    public GameObject ClickText;

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
                LevelText.text = (DataController.Instance.nowRebirthLevel + 1).ToString();
                Glow.SetActive(DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel > 0);
            }

            if (PlayerPrefs.GetFloat("FirstBreakStone", 0) == 0)
            {
                PlayerPrefs.SetFloat("FirstBreakStone", 1);
                Time.timeScale = 0;
                TutorialPanel.SetActive(true);
                ClickText.SetActive(true);
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
                DataController.Instance.goldQueue.Enqueue(DataController.Instance.enqueueGold *
                                                          DataController.Instance.useGoldBuff);
                if (DataController.Instance.rebirthLevel < 25)
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
                rand = Random.Range(0, 100);
                if (rand == 1)
                {
                    var ruby = Instantiate(RubyObject, GoldPosition, Quaternion.identity);
                    ruby.transform.SetParent(Stones);
                    rand = Random.Range(-80f, 80f);
                    ruby.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
                    DataController.Instance.rubyQueue.Enqueue(1);
                }
                
                if (DataController.Instance.rebirthLevel < 25)
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
            case "PetSkill1":
                Destroy(other.gameObject);
                StartCoroutine("Pet1");
                break;
            case "PetSkill2":
                Destroy(other.gameObject);
                StartCoroutine("Pet2");
                break;
            case "PetSkill3":
                Destroy(other.gameObject);
                StartCoroutine("Pet3");
                break;
            case "PetSkill4":
                StartCoroutine("Pet4");
                break;
            case "PetSkill5":
                StartCoroutine("Pet5");
                break;
            case "PetSkill6":
                StartCoroutine("Pet6");
                break;
        }
    }

    private IEnumerator Skill_1()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.skill_1_damage;
        var i = 0;
        while (i < 10)
        {
            Effect();

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

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator Skill_2()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.skill_2_damage;
        var i = 0;
        while (i < 10)
        {
            Effect();

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

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator DustSkill()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.skill_4_damage;
        var i = 0;
        while (i < 3)
        {
            Effect();

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

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator ExplosionSkill()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.skill_5_damage;
        var i = 0;
        while (i < 10)
        {
            Effect();

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

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator HolyExpllosion()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.skill_6_damage;
        var i = 0;
        while (i < 16)
        {
            Effect();

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

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private IEnumerator Pet1()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_1_damage;
        var i = 0;
        while (i < 3)
        {
            Effect();

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer * 
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);
            
            if (DataController.Instance.rebirthLevel < 25)
                HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private IEnumerator Pet2()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_2_damage;
        var i = 0;
        while (i < 6)
        {
            Effect();

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer * 
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);
            
            if (DataController.Instance.rebirthLevel < 25)
                HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private IEnumerator Pet3()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_3_damage;
        var i = 0;
        while (i < 5)
        {
            Effect();

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer * 
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);
            
            if (DataController.Instance.rebirthLevel < 25)
                HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private IEnumerator Pet4()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_4_damage;
        var i = 0;
        while (i < 10)
        {
            Effect();

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer * 
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);
            
            if (DataController.Instance.rebirthLevel < 25)
                HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private IEnumerator Pet5()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_5_damage;
        var i = 0;
        while (i < 5)
        {
            Effect();

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer * 
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);
            
            if (DataController.Instance.rebirthLevel < 25)
                HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private IEnumerator Pet6()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_6_damage;
        var i = 0;
        while (i < 5)
        {
            Effect();

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            var gold = Instantiate(GoldObject, GoldPosition, Quaternion.identity);
            gold.transform.SetParent(Stones);
            var rand = Random.Range(-80f, 80f);
            gold.GetComponent<Rigidbody>().AddForce(Vector3.right * rand);
            DataController.Instance.goldQueue.Enqueue(criticalDamage / getGoldPer * 
                                                      DataController.Instance.collectionGoldRising *
                                                      DataController.Instance.useGoldBuff);
            
            if (DataController.Instance.rebirthLevel < 25)
                HpSlider.value -= criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private void Effect()
    {
        if (PlayerPrefs.GetInt("IsEffect", 0) == 0)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);
        }
    }
}