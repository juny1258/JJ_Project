using System.Collections;
using System.Collections.Generic;
using GooglePlayGames.Native.Cwrapper;
using UnityEngine;
using UnityEngine.UI;

public class PvpAI : MonoBehaviour
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
        SetPlayerAvility(DataController.Instance.AIData.Hp);
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
        if (index == 4)
        {
            StartCoroutine("Skill_2");
        }
        else if (index == 5)
        {
            StartCoroutine("ExplosionSkill");
        }
        else if (index == 6)
        {
            StartCoroutine("HolyExpllosion");
        }
    }
    
    private void Update()
    {
        DamageText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.PlayerDamage);
    }
    
    public void SetPlayerAvility(float hp)
    {
        UserName.text = DataController.Instance.AIData.userName;
        MaxHP = hp;
        HpSlider.maxValue = MaxHP;
        HpSlider.value = HpSlider.maxValue;
        NowHP = HpSlider.maxValue;
        
        HpText.text = DataController.Instance.FormatGoldTwo(NowHP) + "/" +
                      DataController.Instance.FormatGoldTwo(MaxHP);

        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            if (DataController.Instance.AIData.score > 0 && DataController.Instance.AIData.score <= 1200)
            {
                ScoreText.text = "브론즈 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 1200 && DataController.Instance.AIData.score <= 1400)
            {
                ScoreText.text = "실버 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 1400 && DataController.Instance.AIData.score <= 1600)
            {
                ScoreText.text = "골드 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 1600 && DataController.Instance.AIData.score <= 1800)
            {
                ScoreText.text = "플레티넘 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 1800 && DataController.Instance.AIData.score <= 2100)
            {
                ScoreText.text = "다이아 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 2100 && DataController.Instance.AIData.score <= 2400)
            {
                ScoreText.text = "마스터 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 2400 && DataController.Instance.AIData.score <= 2700)
            {
                ScoreText.text = "그랜드마스터 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 2700 && DataController.Instance.AIData.score <= 3000)
            {
                ScoreText.text = "챌린저 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }
            else if (DataController.Instance.AIData.score > 3000)
            {
                ScoreText.text = "위너 : 랭크\n" + DataController.Instance.AIData.score + " : 점수";
            }   
        }
        else
        {
            if (DataController.Instance.AIData.score > 0 && DataController.Instance.AIData.score <= 1200)
            {
                ScoreText.text = "F : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 1200 && DataController.Instance.AIData.score <= 1400)
            {
                ScoreText.text = "E : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 1400 && DataController.Instance.AIData.score <= 1600)
            {
                ScoreText.text = "D : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 1600 && DataController.Instance.AIData.score <= 1800)
            {
                ScoreText.text = "C : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 1800 && DataController.Instance.AIData.score <= 2100)
            {
                ScoreText.text = "B : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 2100 && DataController.Instance.AIData.score <= 2400)
            {
                ScoreText.text = "A : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 2400 && DataController.Instance.AIData.score <= 2700)
            {
                ScoreText.text = "S : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 2700 && DataController.Instance.AIData.score <= 3000)
            {
                ScoreText.text = "SS : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
            else if (DataController.Instance.AIData.score > 3000)
            {
                ScoreText.text = "SSS : Rank\n" + DataController.Instance.AIData.score + " : Score";
            }
        }
    }

    public void InitObject()
    {
        Audio.Play();
        SpawnPoint = AttackPosition.position;
        SpawnPoint.y += Random.Range(0, 0.2f);
        SpawnPoint.z = 0;
        var skill = Instantiate(SkillObjects[DataController.Instance.AIData.skillIndex], SpawnPoint,
            new Quaternion(0, 180, 0, 0));
        skill.GetComponent<Rigidbody>().AddForce(Vector3.left * 500f);
        var randInt = Random.Range(-50, 50);
        skill.GetComponent<Rigidbody>().AddForce(new Vector3(0, randInt, 0));

        randInt = Random.Range(0, 1000);
        if (randInt < DataController.Instance.AIData.criticalPercent * 10)
        {
            skill.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, 1);
            skill.tag = "CriticalAttack";
        }

        skill.transform.SetParent(Stones);

        if (DataController.Instance.AIData.skinIndex == 0)
        {
            AttackAnimation.Play("Attack" + DataController.Instance.AIData.costumeIndex, 0, 0);
        }
        else
        {
            AttackAnimation.Play("SkinAttack" + DataController.Instance.AIData.skinIndex, 0, 0);
        }
    }

    private void SetCostume()
    {
        if (DataController.Instance.AIData.skinIndex == 0)
        {
            GetComponent<Animator>().Play("Attack" + DataController.Instance.AIData.costumeIndex, 0, 1);
        }
        else
        {
            GetComponent<Animator>().Play("SkinAttack" + DataController.Instance.AIData.skinIndex, 0, 1);
        }
    }

    private IEnumerator Skill_1()
    {
        var criticalDamage = DataController.Instance.PlayerData.damage
                             * DataController.Instance.PlayerData.skill_1_damage;
        var i = 0;
        while (i < 10)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.PlayerDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator Skill_2()
    {
        var criticalDamage = DataController.Instance.PlayerData.damage
                             * DataController.Instance.PlayerData.skill_2_damage;
        var i = 0;
        while (i < 10)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.PlayerDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator DustSkill()
    {
        var criticalDamage = DataController.Instance.PlayerData.damage
                             * DataController.Instance.PlayerData.skill_4_damage;
        var i = 0;
        while (i < 3)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.PlayerDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator ExplosionSkill()
    {
        var criticalDamage = DataController.Instance.PlayerData.damage
                             * DataController.Instance.PlayerData.skill_5_damage;
        var i = 0;
        while (i < 10)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.PlayerDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator HolyExpllosion()
    {
        var criticalDamage = DataController.Instance.PlayerData.damage
                             * DataController.Instance.PlayerData.skill_6_damage;
        var i = 0;
        while (i < 16)
        {
            if (!isGameEnd)
            {
                Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

                CombatTextManager.Instance.CreateText(TextPosition,
                    DataController.Instance.FormatGoldTwo(criticalDamage), true);
                
                DataController.Instance.PlayerDamage += criticalDamage;
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            DataController.Instance.PlayerDamage += DataController.Instance.PlayerData.damage;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.PlayerData.damage), false);
        }

        if (other.gameObject.tag == "CriticalAttack")
        {
            DataController.Instance.PlayerDamage +=  DataController.Instance.PlayerData.criticalDamage;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.PlayerData.criticalDamage),
                true);
        }

        if (other.gameObject.tag == "PlayerBat")
        {
            StartCoroutine("Skill_1");
        }

        if (other.gameObject.tag == "PlayerFxTemporaire")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("DustSkill");
        }
    }
}