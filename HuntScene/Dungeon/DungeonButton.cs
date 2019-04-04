using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonButton : MonoBehaviour
{
    public GameObject LevelPanel;

    private void OnEnable()
    {
        if (DataController.Instance.dungeonCount == 0)
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                GetComponentInChildren<Text>().text = "소탕권을 사용하여 도전";
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                GetComponentInChildren<Text>().text = "掃討権を使用しての挑戦";
            }
            else
            {	
                GetComponentInChildren<Text>().text = "Use Scroll to Challenge";
            }   
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                GetComponentInChildren<Text>().text = "도전하기(" + DataController.Instance.dungeonCount + "/10)";
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                GetComponentInChildren<Text>().text = "挑戦する(" + DataController.Instance.dungeonCount + "/10)";
            }
            else
            {	
                GetComponentInChildren<Text>().text = "Challenge(" + DataController.Instance.dungeonCount + "/10)";
            }   
        }
    }

    public void ShowLevelPanel()
    {
        LevelPanel.SetActive(true);
    }

}