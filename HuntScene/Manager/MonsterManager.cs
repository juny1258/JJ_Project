using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public GameObject Skill_1_Effect;
    public Slider HpSlider;

    public Vector3 MovePosition;

    public float speed;
    public float MaxHP;
    private float NowHP;
    public float damage;

    private Vector3 RestartGamePosition;

    private Vector3 TextPosition;
    private bool isAttack;

    public void SetMonsterAvility(float hp, float damage)
    {
        MaxHP = hp;
        HpSlider.maxValue = MaxHP;
        HpSlider.value = HpSlider.maxValue;
        NowHP = HpSlider.maxValue;
        this.damage = damage;
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Monster"), LayerMask.NameToLayer("Monster"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Monster"), LayerMask.NameToLayer("Gold"));
        GetComponent<Rigidbody>().AddForce(Vector3.left * speed);

        EventManager.UseSkillEvent += PlaySkill;

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

    public void OnDestroy()
    {
        StopAllCoroutines();
        EventManager.UseSkillEvent -= PlaySkill;

        DataController.Instance.monsterKillCount++;
//        EventManager.OpenMenuEvent -= OpenMenu;
    }

    private IEnumerator Skill_1()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.skill_1_damage;
        var i = 0;
        while (i < 10)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }

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
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }

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
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }

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
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }

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
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(criticalDamage), true);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }

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
            NowHP -= DataController.Instance.masterDamage;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage), false);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "CriticalAttack")
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= DataController.Instance.masterCriticalDamage;

            CombatTextManager.Instance.CreateText(TextPosition,
                DataController.Instance.FormatGoldTwo(DataController.Instance.masterCriticalDamage),
                true);

            if (NowHP > 0)
            {
                HpSlider.value = NowHP;
            }
            else
            {
                HpSlider.value = 0;

                Destroy(gameObject);
            }
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

        if (other.gameObject.tag == "Player" && !isAttack)
        {
            // 공격 애니메이션
            // 플레이어 공격
            isAttack = true;
            StartCoroutine(Attack());
            GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            DataController.Instance.nowPlayerHP -= damage;
            EventManager.Instance.MonsterAttack(damage);
            if (DataController.Instance.nowPlayerHP <= 0)
            {
                StopAllCoroutines();
                EventManager.Instance.EndGame();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}