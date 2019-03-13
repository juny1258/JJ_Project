using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    public GameObject TutorialPanel;

    public GameObject Info1;
    public GameObject Info2;
    public GameObject Info3;
    public GameObject Info4;

    private int index;

    private void Start()
    {
        Info1.SetActive(true);
    }

    public void NextInfo()
    {
        if (index == 0)
        {
            GetComponentInChildren<Text>().text = "Next >>";
            Info1.SetActive(false);
            Info2.SetActive(true);
            index++;
        }
        else if (index == 1)
        {
            GetComponentInChildren<Text>().text = "Next >>";
            Info2.SetActive(false);
            Info3.SetActive(true);
            index++;
        }
        else if (index == 2)
        {
            NotificationManager.Instance.SetNotification2("사파이어 20개 지급!!");
            DataController.Instance.sapphire += 20;
            GetComponentInChildren<Text>().text = "Start >>";
            Info3.SetActive(false);
            Info4.SetActive(true);
            index++;
        }
        else if (index == 3)
        {
            Info3.SetActive(false);
            DataController.Instance.isTutorial = false;
            
            TutorialPanel.SetActive(false);
            PlayerPrefs.SetInt("FirstOpenGame", 1);
        }
    }
}