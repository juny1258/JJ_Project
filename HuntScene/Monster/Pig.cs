using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pig : MonoBehaviour {

//	public GameObject Gold;
//    private Slider HpSlider;
//    private Text HpText;
//    private Text MonsterNameText;
//
//    private float speed = 200;
//
//    public string monsterName;
//    
//    private float MaxHP = 150;
//    private float NowHP;
//    private float damage = 20;
//
//    private float dropGold = 30;
//
//    private Vector3 TextPosition;
//    private bool isAttack;
//
//    // Use this for initialization
//    void Start()
//    {
//        MaxHP = MaxHP * Mathf.Pow(DataController.RisingMonsterAbility, DataController.Instance.nowStage-1);
//        damage = damage * Mathf.Pow(DataController.RisingMonsterAbility, DataController.Instance.nowStage-1);
//        NowHP = MaxHP;
//        HpSlider = GameObject.Find("MonsterHpSlider").GetComponent<Slider>();
//        HpText = GameObject.Find("MonsterHpText").GetComponent<Text>();
//        MonsterNameText = GameObject.Find("MonsterName").GetComponent<Text>();
//        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Monster"), LayerMask.NameToLayer("Monster"));
//        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Monster"), LayerMask.NameToLayer("Gold"));
//        GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//    }
//
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Attack")
//        {
//            MonsterNameText.text = monsterName;
//            HpSlider.maxValue = MaxHP;
//            TextPosition = transform.position;
//            TextPosition.y += 1;
//            NowHP -= DataController.Instance.masterDamage;
//            
//            CombatTextManager.Instance.CreateText(TextPosition, DataController.Instance.FormatGoldTwo(DataController.Instance.masterDamage), false);
//            
//            if (NowHP > 0)
//            {
//                HpSlider.value = NowHP;
//                HpText.text = DataController.Instance.FormatGoldOne(MaxHP) + "/" + DataController.Instance.FormatGoldOne(NowHP);
//            }
//            else
//            {
//                HpSlider.value = 0;
//                HpText.text = DataController.Instance.FormatGoldOne(MaxHP) + "/" + 0;
//                Instantiate(Gold, transform.position, Quaternion.identity);
//                DataController.Instance.goldQueue.Enqueue(dropGold *= Mathf.Pow(DataController.RisingDropGold,
//                    DataController.Instance.nowStage));
//                if (DataController.Instance.Monsters.childCount == 0)
//                {
//                    DataController.Instance.nowStage++;
//                    if (DataController.Instance.nowStage > DataController.Instance.huntStage)
//                    {
//                        DataController.Instance.huntStage = DataController.Instance.nowStage;
//                    }
//                    EventManager.Instance.StartHunt();
//                }
//                Destroy(gameObject);
//            }
//        }else if (other.gameObject.tag == "CriticalAttack")
//        {
//            var criticalDamage = DataController.Instance.masterDamage * DataController.Instance.criticalRising;
//            MonsterNameText.text = monsterName;
//            HpSlider.maxValue = MaxHP;
//            TextPosition = transform.position;
//            TextPosition.y += 1;
//            NowHP -= criticalDamage;
//
//            CombatTextManager.Instance.CreateText(TextPosition, DataController.Instance.FormatGoldTwo(criticalDamage),
//                true);
//
//            if (NowHP > 0)
//            {
//                HpSlider.value = NowHP;
//                HpText.text = DataController.Instance.FormatGoldOne(MaxHP) + "/" +
//                              DataController.Instance.FormatGoldOne(NowHP);
//            }
//            else
//            {
//                HpSlider.value = 0;
//                HpText.text = DataController.Instance.FormatGoldOne(MaxHP) + "/" + 0;
//                Instantiate(Gold, transform.position, Quaternion.identity);
//                DataController.Instance.goldQueue.Enqueue(dropGold *= Mathf.Pow(DataController.RisingDropGold,
//                    DataController.Instance.nowStage));
//                if (DataController.Instance.Monsters.childCount == 0)
//                {
//                    DataController.Instance.nowStage++;
//                    if (DataController.Instance.nowStage > DataController.Instance.huntStage)
//                    {
//                        DataController.Instance.huntStage = DataController.Instance.nowStage;
//                    }
//                    EventManager.Instance.StartHunt();
//                }
//                Destroy(gameObject);
//            }
//        }
//        else if (other.gameObject.tag == "Player" && !isAttack)
//        {
//            // 공격 애니메이션
//            // 플레이어 공격
//            isAttack = true;
//            StartCoroutine(Attack());
//            GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
//            print(DataController.Instance.playerHP);
//        }
//    }
//
//    private IEnumerator Attack()
//    {
//        while (true)
//        {
//            EventManager.Instance.MonsterAttack(damage);
//            
//            yield return new WaitForSeconds(1f);
//        }
//    }
}
