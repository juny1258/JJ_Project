using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpTonado : MonoBehaviour
{
    public GameObject Panel;

    public GameObject PlayerSkill;

    public GameObject SkillEffect;

    private void Start()
    {
        Invoke("PlayAISkill", Random.Range(0.4f, 1));
    }

    public void PlaySkill()
    {
        Instantiate(PlayerSkill, new Vector3(0, -0.65f, 0), Quaternion.identity);
        EventManager.Instance.UseSkill(4);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void PlayAISkill()
    {
        Instantiate(PlayerSkill, new Vector3(-5, -0.65f, 0), Quaternion.identity);
        EventManager.Instance.UseSkill(1);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}