using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaustObject : MonoBehaviour
{
    public GameObject SkillObject;

    public GameObject Meteor;

    public GameObject Skill_1_Effect;

    public Vector3 MovePosition;
    private float damage = 50000;
    private float damageReceived;

    public Animator GolwAnimator;
    public Animator MoveScene;

    public GameObject SealStone;

    public GameObject BossBackground;
    public GameObject NomalBackground;

    private Vector3 RestartGamePosition;

    private Vector3 TextPosition;
    private bool isAttack;

    private int rewardLevel;

    private int faustDamageLenel;

    private float nowDamage;

    private void OnEnable()
    {
        GetComponent<Animator>().Play("FaustMove", 0, 0);

        damageReceived = 0;
        rewardLevel = 0;
        faustDamageLenel = 0;

        InvokeRepeating("GolwAnimation", 5, 5);

        EventManager.UseSkillEvent += PlaySkill;
        EventManager.RewardClickEvent += RewardClick;
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Monster"), LayerMask.NameToLayer("Monster"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Monster"), LayerMask.NameToLayer("Gold"));

//        EventManager.OpenMenuEvent += OpenMenu;
    }

//    public void OpenMenu()
//    {
//        if (!DataController.Instance.isMenuOpen)
//        {
//            GetComponent<Rigidbody>().isKinematic = false;
//            GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
//        }
//        else
//        {
//            transform.Translate(0.5f, 0, 0);
//            isAttack = false;
//            GetComponent<Rigidbody>().isKinematic = true;
//        }
//    }

    public void GolwAnimation()
    {
        GolwAnimator.Play("GlowAnimation", 0, 0);
        Invoke("MeteorSkill", 0.3f);
    }

    public void MeteorSkill()
    {
        Instantiate(Meteor, new Vector3(15, 20, 0), Quaternion.Euler(0, 0, 135));
        Invoke("DelaySkill", 0.6f);
        GetComponent<AudioSource>().Play();
    }

    public void DelaySkill()
    {
        Instantiate(SkillObject, new Vector3(-2.9f, -3.3f, 0), Quaternion.Euler(75, 0, 0));
        StartCoroutine("MeteorDamage");
        EventManager.Instance.ShackScreen(0.15f, 1f);
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

    public void OnDisable()
    {
        StopAllCoroutines();
        EventManager.UseSkillEvent -= PlaySkill;
        EventManager.RewardClickEvent -= RewardClick;
//        EventManager.OpenMenuEvent -= OpenMenu;
    }

    private IEnumerator Skill_1()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_1_damage
                             * (DataController.Instance.collectionFaustDamage +
                                DataController.Instance.advancedFaustDamage);
        var i = 0;
        while (i < 10)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            damageReceived += criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator Skill_2()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_2_damage
                             * (DataController.Instance.collectionFaustDamage +
                                DataController.Instance.advancedFaustDamage);
        var i = 0;
        while (i < 10)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            damageReceived += criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator DustSkill()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_4_damage
                             * (DataController.Instance.collectionFaustDamage +
                                DataController.Instance.advancedFaustDamage);
        var i = 0;
        while (i < 3)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            damageReceived += criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator ExplosionSkill()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_5_damage
                             * (DataController.Instance.collectionFaustDamage +
                                DataController.Instance.advancedFaustDamage);
        var i = 0;
        while (i < 10)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            damageReceived += criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator HolyExpllosion()
    {
        var criticalDamage = DataController.Instance.masterCriticalDamage
                             * DataController.Instance.skill_6_damage
                             * (DataController.Instance.collectionFaustDamage +
                                DataController.Instance.advancedFaustDamage);
        var i = 0;
        while (i < 16)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            damageReceived += criticalDamage;

            i++;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage
                                                      * (DataController.Instance.collectionFaustDamage +
                                                         DataController.Instance.advancedFaustDamage)), false);

            damageReceived += DataController.Instance.masterDamage
                              * (DataController.Instance.collectionFaustDamage +
                                 DataController.Instance.advancedFaustDamage);
        }

        if (other.gameObject.tag == "CriticalAttack")
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage
                                                      * (DataController.Instance.collectionFaustDamage +
                                                         DataController.Instance.advancedFaustDamage)),
                true);

            damageReceived += DataController.Instance.masterCriticalDamage
                              * (DataController.Instance.collectionFaustDamage +
                                 DataController.Instance.advancedFaustDamage);
        }

        if (other.gameObject.tag == "Bat")
        {
            StartCoroutine("Skill_1");
        }

        if (other.gameObject.tag == "FxTemporaire")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("DustSkill");
        }
    }

    private IEnumerator MeteorDamage()
    {
        nowDamage = (float) (damage * Math.Pow(2f, faustDamageLenel));
        var i = 0;
        while (i < 10)
        {
            DataController.Instance.nowPlayerHP -= nowDamage;
            EventManager.Instance.BossAttack(nowDamage);
            if (DataController.Instance.nowPlayerHP <= 0)
            {
                CancelInvoke();
                EndGame();
                StopAllCoroutines();
            }

            i++;

            yield return new WaitForSeconds(0.08f);
        }

        faustDamageLenel++;
    }

    private void EndGame()
    {
        for (int i = 0; i < 20; i++)
        {
            if (damageReceived < 1000000)
            {
                rewardLevel = 0;
                break;
            }

            if (damageReceived > 1000000 * Math.Pow(3, i))
            {
                rewardLevel++;
            }
        }

        DataController.Instance.highFaustDamage = damageReceived;
        
        DataController.Instance.FaustAchievement();
        
        if (Social.localUser.authenticated)
        {
            // login success
            float highScore = damageReceived;
            string leaderBoardId = GPGSIds.leaderboard;

            Social.ReportScore((long) highScore, leaderBoardId, success =>
            {
                if (success)
                {
                    print("Success");
                }
            });
        }

        RewardManager.Instance.ShowBossRewardPanel(damageReceived, rewardLevel);
    }

    private void RewardClick()
    {
        MoveScene.Play("MoveScene", 0, 0);
        Invoke("SetMainScene", 0.5f);
    }

    private void SetMainScene()
    {
        NomalBackground.SetActive(true);
        BossBackground.SetActive(false);
        SealStone.SetActive(true);
        gameObject.SetActive(false);
    }
}