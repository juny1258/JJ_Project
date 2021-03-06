﻿using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PvpPlayer : MonoBehaviour
{
    public Text UserName;

    public Slider HpSlider;
    public Text HpText;

    public Text DamageText;

    public Text ScoreText;

    private Vector3 TextPosition;

    public GameObject Skill_1_Effect;

    private float NowHP;
    private float MaxHP;

    public AudioSource Audio;
    public Transform AttackPosition;
    public GameObject[] SkillObjects;
    public Animator AttackAnimation;

    private Vector3 SpawnPoint;

    public Transform Stones;

    private bool isGameEnd;

    private void Start()
    {
        TextPosition = transform.position;
        TextPosition.y += 1.8f;

        EventManager.StartPvpEvent += StartPVP;

        EventManager.EndPvpEvent += EndPVP;

        EventManager.UseSkillEvent += PlaySkill;
    }

    private void OnDestroy()
    {
        EventManager.UseSkillEvent -= PlaySkill;
        EventManager.StartPvpEvent -= StartPVP;

        EventManager.EndPvpEvent -= EndPVP;
    }

    private void StartPVP()
    {
        isGameEnd = false;
        SetCostume();
        SetPlayerAvility(DataController.Instance.PlayerData.Hp);
        InvokeRepeating("InitObject", 0f, 0.2f);
        StopAllCoroutines();
    }

    private void EndPVP(int i)
    {
        isGameEnd = true;
        CancelInvoke();
        foreach (Transform stone in Stones)
        {
            Destroy(stone.gameObject);
        }
    }

    public void PlaySkill(int index)
    {
        if (index == 1)
        {
            StartCoroutine("Skill_2");
        }
        else if (index == 2)
        {
            StartCoroutine("ExplosionSkill");
        }
        else if (index == 3)
        {
            StartCoroutine("HolyExpllosion");
        }
    }

    private void Update()
    {
        DamageText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.AIDamage);
    }

    public void SetPlayerAvility(float hp)
    {
        UserName.text = DataController.Instance.PlayerData.userName;
        MaxHP = hp;
        HpSlider.maxValue = MaxHP;
        HpSlider.value = HpSlider.maxValue;
        NowHP = HpSlider.maxValue;
        
        HpText.text = DataController.Instance.FormatGoldTwo(NowHP) + "/" +
                      DataController.Instance.FormatGoldTwo(MaxHP);

        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            if (DataController.Instance.PlayerData.score > 0 && DataController.Instance.PlayerData.score <= 1200)
            {
                ScoreText.text = "랭크 : 브론즈\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1200 && DataController.Instance.PlayerData.score <= 1400)
            {
                ScoreText.text = "랭크 : 실버\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1400 && DataController.Instance.PlayerData.score <= 1600)
            {
                ScoreText.text = "랭크 : 골드\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1600 && DataController.Instance.PlayerData.score <= 1800)
            {
                ScoreText.text = "랭크 : 플레티넘\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1800 && DataController.Instance.PlayerData.score <= 2100)
            {
                ScoreText.text = "랭크 : 다이아\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 2100 && DataController.Instance.PlayerData.score <= 2400)
            {
                ScoreText.text = "랭크 : 마스터\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 2400 && DataController.Instance.PlayerData.score <= 2700)
            {
                ScoreText.text = "랭크 : 그랜드마스터\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 2700 && DataController.Instance.PlayerData.score <= 3000)
            {
                ScoreText.text = "랭크 : 챌린저\n점수 : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 3000)
            {
                ScoreText.text = "랭크 : 위너\n점수 : " + DataController.Instance.PlayerData.score;
            }
        }
        else
        {
            if (DataController.Instance.PlayerData.score > 0 && DataController.Instance.PlayerData.score <= 1200)
            {
                ScoreText.text = "Rank : F\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1200 && DataController.Instance.PlayerData.score <= 1400)
            {
                ScoreText.text = "Rank : E\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1400 && DataController.Instance.PlayerData.score <= 1600)
            {
                ScoreText.text = "Rank : D\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1600 && DataController.Instance.PlayerData.score <= 1800)
            {
                ScoreText.text = "Rank : C\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 1800 && DataController.Instance.PlayerData.score <= 2100)
            {
                ScoreText.text = "Rank : B\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 2100 && DataController.Instance.PlayerData.score <= 2400)
            {
                ScoreText.text = "Rank : A\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 2400 && DataController.Instance.PlayerData.score <= 2700)
            {
                ScoreText.text = "Rank : S\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 2700 && DataController.Instance.PlayerData.score <= 3000)
            {
                ScoreText.text = "Rank : SS\nScore : " + DataController.Instance.PlayerData.score;
            }
            else if (DataController.Instance.PlayerData.score > 3000)
            {
                ScoreText.text = "Rank : SSS\nScore : " + DataController.Instance.PlayerData.score;
            }
        }
    }

    public void InitObject()
    {
        Audio.Play();
        SpawnPoint = AttackPosition.position;
        SpawnPoint.y += Random.Range(0, 0.2f);
        SpawnPoint.z = 0;
        var skill = Instantiate(SkillObjects[DataController.Instance.PlayerData.skillIndex], SpawnPoint,
            Quaternion.identity);
        skill.GetComponent<Rigidbody>().AddForce(Vector3.right * 500f);
        var randInt = Random.Range(-50, 50);
        skill.GetComponent<Rigidbody>().AddForce(new Vector3(0, randInt, 0));

        randInt = Random.Range(0, 1000);
        if (randInt < DataController.Instance.PlayerData.criticalPercent * 10)
        {
            skill.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, 1);
            skill.tag = "CriticalAttack";
        }

        skill.transform.SetParent(Stones);

        if (DataController.Instance.PlayerData.skinIndex == 0)
        {
            AttackAnimation.Play("Attack" + DataController.Instance.PlayerData.costumeIndex, 0, 0);
        }
        else
        {
            AttackAnimation.Play("SkinAttack" + DataController.Instance.PlayerData.skinIndex, 0, 0);
        }
    }

    private void SetCostume()
    {
        if (DataController.Instance.PlayerData.skinIndex == 0)
        {
            GetComponent<Animator>().Play("Attack" + DataController.Instance.PlayerData.costumeIndex, 0, 1);
        }
        else
        {
            GetComponent<Animator>().Play("SkinAttack" + DataController.Instance.PlayerData.skinIndex, 0, 1);
        }
    }

    private IEnumerator Skill_1()
    {
        var criticalDamage = DataController.Instance.AIData.damage
                             * DataController.Instance.AIData.skill_1_damage;
        var i = 0;
        while (i < 10)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.AIDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator Skill_2()
    {
        var criticalDamage = DataController.Instance.AIData.damage
                             * DataController.Instance.AIData.skill_2_damage;
        var i = 0;
        while (i < 10)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.AIDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator DustSkill()
    {
        var criticalDamage = DataController.Instance.AIData.damage
                             * DataController.Instance.AIData.skill_4_damage;
        var i = 0;
        while (i < 3)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.AIDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator ExplosionSkill()
    {
        var criticalDamage = DataController.Instance.AIData.damage
                             * DataController.Instance.AIData.skill_5_damage;
        var i = 0;
        while (i < 10)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.AIDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator HolyExpllosion()
    {
        var criticalDamage = DataController.Instance.AIData.damage
                             * DataController.Instance.AIData.skill_6_damage;
        var i = 0;
        while (i < 16)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.AIDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            DataController.Instance.AIDamage += DataController.Instance.AIData.damage;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.AIData.damage), false);
            
        }
        else if (other.gameObject.tag == "CriticalAttack")
        {
            DataController.Instance.AIDamage += DataController.Instance.AIData.criticalDamage;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.AIData.criticalDamage),
                true);
        }
        else if (other.gameObject.tag == "Bat")
        {
            StartCoroutine("Skill_1");
        }
        else if (other.gameObject.tag == "FxTemporaire")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("DustSkill");
        }
    }
}