using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapScreen : MonoBehaviour
{
    public Transform AttackPosition;
    public Transform AttackPosition2;
    public GameObject[] SkillObjects;
    public Animator AttackAnimation;
    public Animator AttackAnimation2;

    public GameObject AuraObject;
    public GameObject AngerBackgrond;

    public AudioSource AngerAudio;

    public Slider AngerSlider;

    private AudioSource Audio;

    private Vector3 SpawnPoint;
    private Vector3 SpawnPoint2;

    public Transform Stones;

    private bool isAnger;

    private bool isReady;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        InvokeRepeating("AutoClick", 0.3f, 0.1f);
        InvokeRepeating("Ready", 0, 0.1f);
        StartCoroutine("AutoClick2");
    }

    private void AutoClick()
    {
        if (DataController.Instance.useAutoClick && !DataController.Instance.isMove)
        {
            InitObject();
        }
    }

    private IEnumerator AutoClick2()
    {
        while (true)
        {
            if (!DataController.Instance.isTutorial && !DataController.Instance.isMove)
            {
                InitObject();
            }

            yield return new WaitForSeconds(DataController.Instance.advancedAutoTap);
        }
    }

    public void InitObject()
    {
        if (isReady && !DataController.Instance.isMenuOpen && !DataController.Instance.isMove)
        {
            Audio.Play();
            isReady = false;
            SpawnPoint = AttackPosition.position;
            SpawnPoint.y += Random.Range(0, 0.2f);
            SpawnPoint.z = 0;
            var skill = Instantiate(SkillObjects[DataController.Instance.skillIndex], SpawnPoint, Quaternion.identity);
            
            skill.GetComponent<Rigidbody>().AddForce(Vector3.right * 500f);
            var randInt = Random.Range(-50, 50);
            skill.GetComponent<Rigidbody>().AddForce(new Vector3(0, randInt, 0));
            
            randInt = Random.Range(0, 1000);
            if (randInt < (DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                           DataController.Instance.devilCritical + DataController.Instance.collectionCriticalPer +
                           DataController.Instance.advancedCriticalPer + DataController.Instance.skinCriticalPer) * 10)
            {
                skill.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, 1);
                skill.tag = "CriticalAttack";
            }
            
            skill.transform.SetParent(Stones);
            if (DataController.Instance.isShadowSkill)
            {
                SpawnPoint2 = AttackPosition2.position;
                SpawnPoint.y += Random.Range(0, 0.2f);
                SpawnPoint.z = 0;
                var skill1 = Instantiate(SkillObjects[DataController.Instance.skillIndex], SpawnPoint2, Quaternion.identity);
                
                skill1.GetComponent<Rigidbody>().AddForce(Vector3.right * 500f);
                var randInt1 = Random.Range(-50, 50);
                skill1.GetComponent<Rigidbody>().AddForce(new Vector3(0, randInt1, 0));
            
                randInt1 = Random.Range(0, 1000);
                if (randInt1 < (DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                               DataController.Instance.devilCritical + DataController.Instance.collectionCriticalPer +
                               DataController.Instance.advancedCriticalPer + DataController.Instance.skinCriticalPer) * 10)
                {
                    skill1.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, 1);
                    skill1.tag = "CriticalAttack";
                }
                
                skill1.transform.SetParent(Stones);

                if (DataController.Instance.skinIndex == 0)
                {
                    AttackAnimation2.Play("Attack" + DataController.Instance.costumeIndex, 0, 0);   
                }
                else
                {
                    AttackAnimation2.Play("SkinAttack" + DataController.Instance.skinIndex, 0, 0);
                }
            }

            if (!DataController.Instance.isAnger)
            {
                DataController.Instance.angerGauge += 1;
            }

            if (DataController.Instance.angerGauge >= 200)
            {

                AngerSlider.maxValue = DataController.Instance.angerTime +
                                       DataController.Instance.angerTime *
                                       DataController.Instance.rubyAngerTime +
                                       DataController.Instance.angerTime *
                                       DataController.Instance.collectionAngerTime;

                DataController.Instance.angerGauge = DataController.Instance.angerTime +
                                                     DataController.Instance.angerTime *
                                                     DataController.Instance.rubyAngerTime +
                                                     DataController.Instance.angerTime *
                                                     DataController.Instance.collectionAngerTime;

                AngerAudio.Play();

                AngerBackgrond.SetActive(true);
                AuraObject.SetActive(true);
                EventManager.Instance.ShackScreen(0.15f, 0.5f);
                DataController.Instance.isAnger = true;
                
                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();
            }

            if (DataController.Instance.skinIndex == 0)
            {
                AttackAnimation.Play("Attack" + DataController.Instance.costumeIndex, 0, 0);   
            }
            else
            {
                AttackAnimation.Play("SkinAttack" + DataController.Instance.skinIndex, 0, 0);
            }
        }
    }

    private void Ready()
    {
        isReady = true;
    }

    private void Update()
    {
        if (DataController.Instance.isAnger)
        {
            // 분노 게이지 감소 시간 (초기 시간은 
            DataController.Instance.angerGauge -= Time.deltaTime;
            if (DataController.Instance.angerGauge <= 0)
            {
                AngerSlider.maxValue = 200;
                DataController.Instance.angerGauge = 0;

                AngerBackgrond.SetActive(false);
                AuraObject.SetActive(false);
                DataController.Instance.isAnger = false;
                DataController.Instance.UpdateDamage();
                DataController.Instance.UpdateCritical();
            }
        }
    }
}