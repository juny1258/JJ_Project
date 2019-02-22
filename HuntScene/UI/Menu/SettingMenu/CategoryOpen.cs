using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class CategoryOpen : MonoBehaviour
{
    public GameObject CategoryPanel;

    private bool isOpen;

    public void OnClick()
    {
        if (isOpen)
        {
            CategoryPanel.SetActive(false);
            isOpen = false;
        }
        else
        {
            CategoryPanel.SetActive(true);
            isOpen = true;
        }


    }
}