using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;

public class RewardButton : MonoBehaviour
{
    public GameObject RewardPanel;
    
    public AudioSource BackgroundSound;
    public AudioClip BackgroundClip;
    
    public void OkButton()
    {
        DataController.Instance.gold += DataController.Instance.getGold;
        DataController.Instance.ruby += DataController.Instance.getRuby;
        DataController.Instance.sapphire += DataController.Instance.getSapphire;

        DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
        
        DataController.Instance.isFight = false;
        
        EventManager.Instance.RewardClick();
        
        RewardPanel.SetActive(false);
    }

    public void ShowRewardButton()
    {
        if (Random.Range(0, 100) <DataController.Instance.collectionRubyRising)
        {
            DataController.Instance.ruby += DataController.Instance.getRuby * 2 * 2;
        }
        else
        {
            DataController.Instance.ruby += DataController.Instance.getRuby * 2;
        }
        
        if (Random.Range(0, 100) <DataController.Instance.collectionSappaireRising)
        {
            DataController.Instance.sapphire += DataController.Instance.getSapphire * 2 * 2;
        }
        else
        {
            DataController.Instance.sapphire += DataController.Instance.getSapphire * 2;
        }
        
        DataController.Instance.gold += DataController.Instance.getGold * 2;
        
        DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
        
        DataController.Instance.isFight = false;
        
        EventManager.Instance.RewardClick();
        
        RewardPanel.SetActive(false);
    }

    public void BossOkButton()
    {
        DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
        
        EventManager.Instance.RewardClick();

        DataController.Instance.isFight = false;
        
        Invoke("SetMusic", 0.4f);
        
        RewardPanel.SetActive(false);
    }

    private void SetMusic()
    {
        BackgroundSound.clip = BackgroundClip;
        BackgroundSound.Play();
    }
}