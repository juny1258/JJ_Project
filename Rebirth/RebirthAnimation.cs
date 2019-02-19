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

    private float rewardRebirthStone = 100;

    private float delay = 0.5f;

    private void Start()
    {
        EventManager.RebirtButtonClickEvent += OnRebirthAnimation;
    }

    private void OnEnable()
    {
        originPos = SealStone.transform.position;
    }

    public void OnRebirthAnimation()
    {
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
        Invoke("RemoveObject", 0.5f);
    }

    private void RemoveObject()
    {
        // TODO 환생 시 데이터 초기화 및 UI 세팅

        DataController.Instance.rebirthStone +=
            (float) (rewardRebirthStone * Math.Pow(5, DataController.Instance.rebirthLevel - 1))
            * (DataController.Instance.collectionRebirthRising + DataController.Instance.advancedRebirthPer);
        
        DataController.Instance.rebirthLevel = 0;

        foreach (var light in Lights)
        {
            light.SetActive(false);
        }

        Background.color = new Color(0, 0, 0, 0);
        GetComponent<Animator>().enabled = true;
        
        DataController.Instance.RebirthAvilityReset();
        
        foreach (Transform stone in Stones)
        {
            Destroy(stone.gameObject);
        }
        
        DataController.Instance.goldQueue.Clear();

        if (DataController.Instance.firstRebirth == 0)
        {
            DataController.Instance.firstRebirth = 1;
            Social.ReportProgress(GPGSIds.achievement_rebirth_success, 100f, isSuccess =>
            {
                if (isSuccess)
                {
                    DataController.Instance.ruby += 50;
                    NotificationManager.Instance.SetNotification2("[업적 달성] 루비 50개 획득!!");
                }
            });
        }
        
        EventManager.Instance.Rebirth();
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