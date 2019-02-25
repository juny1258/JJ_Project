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
        if (DataController.Instance.useAutoClick)
        {
            InitObject();
        }
    }

    private IEnumerator AutoClick2()
    {
        while (true)
        {
            if (!DataController.Instance.isTutorial)
            {
                InitObject();
            }

            yield return new WaitForSeconds(DataController.Instance.advancedAutoTap);
        }
    }

    public void InitObject()
    {
        if (isReady && !DataController.Instance.isMenuOpen)
        {
            Audio.Play();
            isReady = false;
            SpawnPoint = AttackPosition.position;
            SpawnPoint.y += Random.Range(0, 0.2f);
            SpawnPoint.z = 0;
            var skill = Instantiate(SkillObjects[DataController.Instance.skillIndex], SpawnPoint, Quaternion.identity);
            skill.transform.SetParent(Stones);
            if (DataController.Instance.isShadowSkill)
            {
                SpawnPoint2 = AttackPosition2.position;
                SpawnPoint.y += Random.Range(0, 0.2f);
                SpawnPoint.z = 0;
                Instantiate(SkillObjects[DataController.Instance.skillIndex], SpawnPoint2, Quaternion.identity);
                skill.transform.SetParent(Stones);

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
                DataController.Instance.masterDamage *= DataController.Instance.angerDamage +
                                                        DataController.Instance.rubyAngerDamage +
                                                        DataController.Instance.collectionAngerDamage +
                                                        DataController.Instance.advancedAngerDamage;

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

                DataController.Instance.UpdateCritical();

                AngerAudio.Play();

                AngerBackgrond.SetActive(true);
                AuraObject.SetActive(true);
                EventManager.Instance.ShackScreen(0.15f, 0.5f);
                DataController.Instance.isAnger = true;
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
                DataController.Instance.masterDamage /= DataController.Instance.angerDamage +
                                                        DataController.Instance.rubyAngerDamage +
                                                        DataController.Instance.collectionAngerDamage +
                                                        DataController.Instance.advancedAngerDamage;


                DataController.Instance.UpdateCritical();
                AngerBackgrond.SetActive(false);
                AuraObject.SetActive(false);
                DataController.Instance.isAnger = false;
            }
        }
    }
}