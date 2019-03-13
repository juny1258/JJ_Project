using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpBigBang : MonoBehaviour
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
        Instantiate(PlayerSkill, new Vector3(0, 0, 0), Quaternion.identity);
        EventManager.Instance.UseSkill(6);
        EventManager.Instance.ShackScreen(0.1f, 1.5f);
        EventManager.Instance.PlaySkillSound2();

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void PlayAISkill()
    {
        Instantiate(PlayerSkill, new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
        EventManager.Instance.UseSkill(3);
        EventManager.Instance.ShackScreen(0.1f, 1.5f);
        EventManager.Instance.PlaySkillSound2();

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}