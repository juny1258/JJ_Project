using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Slider HpSlider;
    private Text HpText;
    private Text MonsterNameText;

    private Vector3 TextPosition;

    public GameObject Skill_1_Effect;

    private void Start()
    {
        EventManager.MonsterAttackEvent += damage =>
        {
            CombatTextManager.Instance.CreateText(TextPosition, DataController.Instance.FormatGoldTwo(damage),
                false);
            
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);
        };
        
        EventManager.BossAttackEvent += damage =>
        {
            CombatTextManager.Instance.CreateText(TextPosition, DataController.Instance.FormatGoldTwo(damage),
                true);
            
            Instantiate(Skill_1_Effect, transform.position, Quaternion.identity);
        };
    }

    private void OnEnable()
    {
        // 체력 표시 설정
        HpSlider = GameObject.Find("PlayerHpSlider").GetComponent<Slider>();
        HpText = GameObject.Find("PlayerHpText").GetComponent<Text>();

        // 플레이어 체력 설정
        DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

        TextPosition = transform.position;
        TextPosition.y += 1.8f;
        // TODO 스킨 입혔을 때 스킨으로 표시해주는 것
        if (DataController.Instance.skinIndex == 0)
        {
            GetComponent<Animator>().Play("Attack" + DataController.Instance.costumeIndex, 0, 1);   
        }
        else
        {
            GetComponent<Animator>().Play("SkinAttack" + DataController.Instance.skinIndex, 0, 1);
        }
    }

    private void Update()
    {
        HpSlider.maxValue = DataController.Instance.GetPlayerHP();
        HpSlider.value = DataController.Instance.nowPlayerHP;
        HpText.text = DataController.Instance.FormatGoldTwo(DataController.Instance.GetPlayerHP()) + "/" +
                      DataController.Instance.FormatGoldTwo(DataController.Instance.nowPlayerHP);
    }
}