using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntButton : MonoBehaviour
{
    public GameObject RockObject;
    public GameObject MonsterSpwan;

    public GameObject NotClearPanel;

    public Animator MoveSceneAnimator;

    public Text rubyText;
    public Text sapphireText;

    public int index;

    private void OnEnable()
    {
        NotClearPanel.SetActive(index > DataController.Instance.finalHuntLevel);

        rubyText.text = "x" + global::MonsterSpwan.ruby[index];
        sapphireText.text = "x" + global::MonsterSpwan.sapphire[index];
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetFloat("HuntCoolTime_" + index, 0) <= 0)
        {
            MoveSceneAnimator.Play("MoveScene", 0, 0);
            Invoke("StartHunt", 0.5f);
        }
        else
        {
            NotificationManager.Instance.SetNotification("지금은 입장할 수 없습니다.");
        }
    }

    public void StartHunt()
    {
        DataController.Instance.huntLevel = index;
        RockObject.SetActive(false);
        MonsterSpwan.SetActive(true);
        DataController.Instance.isFight = true;
        MenuManager.Instance.Close();
    }

    public void SkipHunt()
    {
        if (DataController.Instance.finalHuntLevel > index)
        {
            if (PlayerPrefs.GetFloat("HuntCoolTime_" + index, 0) <= 0)
            {
                if (DataController.Instance.skipCoupon >= 1)
                {
                    DataController.Instance.skipCoupon -= 1;
                    RewardManager.Instance.ShowRewardPanel(
                        (float) (global::MonsterSpwan.gold * Math.Pow(6f, DataController.Instance.huntLevel)),
                        global::MonsterSpwan.ruby[index],
                        global::MonsterSpwan.sapphire[index]);
                    PlayerPrefs.SetFloat("HuntCoolTime_" + DataController.Instance.huntLevel, 300);
                    NotClearPanel.SetActive(index > DataController.Instance.finalHuntLevel);
                }
                else
                {
                    NotificationManager.Instance.SetNotification("소탕권이 부족합니다.");
                }
            }
            else
            {
                NotificationManager.Instance.SetNotification("지금은 입장할 수 없습니다.");
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("클리어 후 소탕할 수 있습니다.");
        }
    }
}