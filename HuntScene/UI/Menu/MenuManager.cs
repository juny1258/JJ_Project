using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;

    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<MenuManager>();

            return _instance;
        }
    }
    
    private AudioSource UIAudio;
    public AudioClip TapMenu;

    public GameObject MenuBackground;
    public GameObject[] Menu;
    public GameObject[] Tab;
    public GameObject[] TabButton;

    private Color TabColor;

    private void Start()
    {
        UIAudio = GetComponent<AudioSource>();
    }

    public void Open(int i)
    {
        PlaySound();
        DataController.Instance.isMenuOpen = true;
        MenuBackground.SetActive(true);

        foreach (var tab in Tab)
        {
            tab.SetActive(false);
        }

        foreach (var menu in Menu)
        {
            menu.SetActive(false);
        }

        Menu[i].SetActive(true);

        if (i == 0)
        {
            Tab[1].SetActive(true);
            SelectTab(1);
        }
        else if (i == 1)
        {
            Tab[5].SetActive(true);
            SelectTab(5);
        }
        else if (i == 2)
        {
            Tab[8].SetActive(true);
            SelectTab(8);
        }
        else
        {
            Tab[10].SetActive(true);
            SelectTab(10);
        }
        
        AdMob.Instance.ShowMenuClickAd();
    }

    public void Close()
    {
        PlaySound();
        DataController.Instance.isMenuOpen = false;
        foreach (var tab in Tab)
        {
            tab.SetActive(false);
        }

        foreach (var menu in Menu)
        {
            menu.SetActive(false);
        }

        MenuBackground.SetActive(false);
        AdMob.Instance.ShowMenuClickAd();
    }

    public void MoveTab(int i)
    {
        PlaySound();
        foreach (var tab in Tab)
        {
            tab.SetActive(false);
        }

        Tab[i].SetActive(true);
        SelectTab(i);
        
        AdMob.Instance.ShowMenuClickAd();
    }

    private void PlaySound()
    {
        UIAudio.clip = TapMenu;
        UIAudio.Play();
    }

    private void SelectTab(int i)
    {
        foreach (var tab in TabButton)
        {
            ColorUtility.TryParseHtmlString("#802E2EFF", out TabColor);
            tab.GetComponent<Image>().color = TabColor;
        }
        
        ColorUtility.TryParseHtmlString("#AE3E41FF", out TabColor);
        TabButton[i].GetComponent<Image>().color = TabColor;
    }
}