using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public GameObject LevelPanel;
    
    public GameObject RockObject;
    public GameObject DungeonSpwan;

    public Animator MoveSceneAnimator;

    public AudioSource BackgroundSound;
    public AudioClip BackgroundClip;

    public GameObject BossBackground;
    public GameObject NomalBackground;
    
    public void OnEasy()
    {
        DataController.Instance.dungeonLevel = 1;
        StartGame();
    }
    
    public void OnNomal()
    {
        DataController.Instance.dungeonLevel = 2;
        StartGame();
    }
    
    public void OnHard()
    {
        DataController.Instance.dungeonLevel = 3;
        StartGame();
    }
    
    public void StartGame()
    {
        if (!DataController.Instance.isFight)
        {
            if (DataController.Instance.dungeonCount > 0)
            {
                DataController.Instance.dungeonCount--;
                DataController.Instance.isFight = true;
                MoveSceneAnimator.Play("MoveScene", 0, 0);
                Invoke("StartDungeon", 0.5f);
                LevelPanel.SetActive(false);
            }
            else
            {
                if (DataController.Instance.skipCoupon > 0)
                {
                    DataController.Instance.skipCoupon--;
                    DataController.Instance.isFight = true;
                    MoveSceneAnimator.Play("MoveScene", 0, 0);
                    Invoke("StartDungeon", 0.5f);
                    LevelPanel.SetActive(false);
                }
                else
                {
                    NotificationManager.Instance.SetNotification(LocalManager.Instance.LessScroll);
                }
            }	
        }
    }
	
    private void StartDungeon()
    {
        NomalBackground.SetActive(false);
        BossBackground.SetActive(true);
        BackgroundSound.clip = BackgroundClip;
        BackgroundSound.volume = 0.7f;
        BackgroundSound.Play();
        RockObject.SetActive(false);
        DungeonSpwan.SetActive(true);
        MenuManager.Instance.Close();
    }
}
