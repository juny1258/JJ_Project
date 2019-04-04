using System.Collections;
using System.Linq;
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

    public bool isBoss;

    private IEnumerator attackCoroutine;

    public void SetMonsterAvility(float hp, float damage) {
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


        attackCoroutine = Attack();
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
            Effect();

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
            Effect();

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
            Effect();

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
            Effect();

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
            Effect();

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

    private IEnumerator KnockBack()
    {
        if (isBoss) yield break;
        if (isAttack)
        {
            isAttack = false;
            var lastPosition = transform.position;
            var randFloat = Random.Range(0.03f, 0.05f);
            var targetPosition =
                new Vector3(transform.position.x + randFloat, transform.position.y + randFloat, transform.position.z);
            StopCoroutine(attackCoroutine);

            var progress = 0f;
            while (progress < 1)
            {
                transform.position = Vector3.Lerp(lastPosition, targetPosition, progress);

                progress += Time.deltaTime * 5;

                yield return null;
            }

            GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
        }
        else
        {
            var lastPosition = transform.position;
            var randFloat = Random.Range(0.08f, 0.1f);
            var targetPosition =
                new Vector3(transform.position.x + randFloat, transform.position.y + randFloat, transform.position.z);
            StopCoroutine(attackCoroutine);

            var progress = 0f;
            while (progress < 1)
            {
                transform.position = Vector3.Lerp(lastPosition, targetPosition, progress);

                progress += Time.deltaTime * 5;

                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Attack":
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
                

                break;
            case "CriticalAttack":

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
                

                break;
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

        if (other.gameObject.tag == "Player" && !isAttack)
        {
            // 공격 애니메이션
            // 플레이어 공격
            isAttack = true;
            StartCoroutine(attackCoroutine);
            GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
        }
    }

    private IEnumerator Pet1()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_1_damage;
        var i = 0;
        while (i < 3)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Effect();

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

    private IEnumerator Pet2()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_2_damage;
        var i = 0;
        while (i < 6)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Effect();

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

    private IEnumerator Pet3()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_3_damage;
        var i = 0;
        while (i < 5)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Effect();

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

    private IEnumerator Pet4()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_4_damage;
        var i = 0;
        while (i < 10)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Effect();

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

    private IEnumerator Pet5()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_5_damage;
        var i = 0;
        while (i < 5)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Effect();

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
    
    private IEnumerator Pet6()
    {
        var criticalDamage = DataController.Instance.masterDamage
                             * DataController.Instance.pet_skill_6_damage;
        var i = 0;
        while (i < 5)
        {
            TextPosition = transform.position;
            TextPosition.x += MovePosition.x;
            TextPosition.y += MovePosition.y;
            TextPosition.z += MovePosition.z;
            NowHP -= criticalDamage;
            Effect();

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

    private void Effect()
    {
        if (PlayerPrefs.GetInt("IsEffect", 0) == 0)
        {
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);
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
                EventManager.Instance.EndGame();
                StopAllCoroutines();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}