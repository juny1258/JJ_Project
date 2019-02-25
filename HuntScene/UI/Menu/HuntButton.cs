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

        if (DataController.Instance.finalHuntLevel > index)
        {
            rubyText.text = "x" + global::MonsterSpwan.ruby[DataController.Instance.finalHuntLevel-1];
            sapphireText.text = "x" + global::MonsterSpwan.sapphire[DataController.Instance.finalHuntLevel-1];
        }
    }

    public void StartGame()
    {
        if (!DataController.Instance.isFight)
        {
            if (PlayerPrefs.GetFloat("HuntCoolTime_" + index, 0) <= 0)
            {
                DataController.Instance.isFight = true;
                MoveSceneAnimator.Play("MoveScene", 0, 0);
                Invoke("StartHunt", 0.5f);
            }
            else
            {
                NotificationManager.Instance.SetNotification("지금은 입장할 수 없습니다.");
            }   
        }
    }

    public void StartHunt()
    {
        DataController.Instance.huntLevel = index;
        RockObject.SetActive(false);
        MonsterSpwan.SetActive(true);
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
                    
                    if (DataController.Instance.finalHuntLevel == DataController.Instance.huntLevel)
                    {
                        RewardManager.Instance.ShowRewardPanel((float) (global::MonsterSpwan.gold * Math.Pow(3f, index)),
                            global::MonsterSpwan.ruby[index], global::MonsterSpwan.sapphire[index]);
                    }
                    else
                    {
                        RewardManager.Instance.ShowRewardPanel((float) (global::MonsterSpwan.gold * Math.Pow(3f, index)),
                            global::MonsterSpwan.ruby[DataController.Instance.finalHuntLevel-1], global::MonsterSpwan.sapphire[DataController.Instance.finalHuntLevel-1]);
                    }
                    
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