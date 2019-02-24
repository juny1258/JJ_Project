using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackShop : MonoBehaviour
{
    public Text DamageText;
    public GameObject SelectPanel;

    public GameObject NotClearPanel;

    public int index;

    private int[] plusDamage = {0, 20, 40, 60, 80, 100, 150, 200, 250, 300, 350, 400, 500};

    private void Start()
    {
        EventManager.SelectAttackEvent += () =>
        {
            DamageText.text = "공격력 + " + plusDamage[index] + "%";

            SelectPanel.SetActive(DataController.Instance.skillIndex == index);

            NotClearPanel.SetActive(DataController.Instance.masterSkillIndex < index);
        };
    }

    private void OnEnable()
    {
        DamageText.text = "공격력 + " + plusDamage[index] + "%";

        SelectPanel.SetActive(DataController.Instance.skillIndex == index);

        NotClearPanel.SetActive(DataController.Instance.masterSkillIndex < index);
    }

    public void SelectItem()
    {
        DataController.Instance.skillIndex = index;

        EventManager.Instance.SelectAttack();
    }
}