using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RebirthAnimation : MonoBehaviour
{
    public GameObject[] Lights;

    public GameObject SealStone;

    public SpriteRenderer Background;

    private Vector3 originPos;

    public Animator RebirthAnimator;

    public Transform Stones;

    private int[] rewardRebirthStone =
    {
        450, 700, 1000, 2000, 2500, 3000, 3500, 4000, 4500, 5000,
        5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 10000, 10000,
        10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000
    };

    private float delay = 0.5f;

    private void Start()
    {
        EventManager.RebirtButtonClickEvent += OnRebirthAnimation;
    }

    private void OnDestroy()
    {
        EventManager.RebirtButtonClickEvent -= OnRebirthAnimation;
    }

    private void OnEnable()
    {
        originPos = SealStone.transform.position;
    }

    public void OnRebirthAnimation()
    {
        DataController.Instance.isRebirth = true;
        DataController.Instance.rebirthStone +=
            rewardRebirthStone[DataController.Instance.rebirthLevel - 1] * 
            (DataController.Instance.collectionRebirthRising + 
             DataController.Instance.advancedRebirthPer);

        DataController.Instance.nowRebirthLevel++;
        
        if (DataController.Instance.isAdvancedRebirth)
        {
            DataController.Instance.isAdvancedRebirth = false;
        }
        else
        {
            DataController.Instance.RebirthAvilityReset();
        }
        
        DataController.Instance.UpdateDamage();
        DataController.Instance.UpdateCritical();
        
        foreach (Transform stone in Stones)
        {
            Destroy(stone.gameObject);
        }
        
        DataController.Instance.goldQueue.Clear();

        if (DataController.Instance.firstRebirth == 0)
        {
            if (Social.localUser.authenticated)
            {
                DataController.Instance.firstRebirth = 1;
                Social.ReportProgress(GPGSIds.achievement_rebirth_success, 100f, isSuccess =>
                {
                });
            }
        }
        
        EventManager.Instance.Rebirth();
        
        for (var i = 0; i < 20; i++)
        {
            PlayerPrefs.SetFloat("HuntCoolTime_" + i, 0);
        }

        for (var i = 0; i < 20; i++)
        {
            PlayerPrefs.SetFloat("BossCoolTime_" + i, 0);
        }
        
        StartCoroutine("ShowLight");
        StartCoroutine(FadeOut());
    }

    private IEnumerator ShowLight()
    {
        GetComponent<Animator>().enabled = false;
        var i = 0;
        delay = 0.5f;
        while (true)
        {
            if (i < 6)
            {
                Lights[i].SetActive(true);
            }

            StartCoroutine(Shake(0.1f, 0.15f));

            i++;
            
            print(delay);

            yield return new WaitForSeconds(delay);
            delay -= 0.04f;
            if (i == 6)
            {
                RebirthAnimator.Play("RebirthAnimation", 0, 0);
                delay = 0.13f;
            }
            if (delay <= 0)
            {
                Stop();
            }
        }
    }

    private void Stop()
    {
        StopAllCoroutines();
        DataController.Instance.isRebirth = false;
        Invoke("RemoveObject", 0.5f);
    }

    private void RemoveObject()
    {
        // TODO 환생 시 데이터 초기화 및 UI 세팅

        foreach (var light in Lights)
        {
            light.SetActive(false);
        }

        Background.color = new Color(0, 0, 0, 0);
        GetComponent<Animator>().enabled = true;
    }

    private IEnumerator FadeOut()
    {
        var rate = 1.0f;
        var progress = 0.0f;

        while (progress <= 0.8f)
        {
            Background.color = new Color(0, 0, 0, progress);
            progress += rate * Time.deltaTime * 0.5f;

            yield return null;
        }
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            SealStone.transform.localPosition =
                (Vector3) Random.insideUnitCircle * _amount + SealStone.transform.position;

            timer += Time.deltaTime;
            yield return null;
        }

        SealStone.transform.localPosition = originPos;
    }
}