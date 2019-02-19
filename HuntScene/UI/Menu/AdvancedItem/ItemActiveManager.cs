using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActiveManager : MonoBehaviour
{
    public GameObject[] AdvancedItems;

    void Start()
    {
        EventManager.GetAdvancedItemEvent += ActivePanel;
    }

    private void OnEnable()
    {
        ActivePanel();
    }

    private void ActivePanel()
    {
        for (var i = 0; i < AdvancedItems.Length; i++)
        {
            AdvancedItems[i].SetActive(PlayerPrefs.GetInt("AdvancedCollectionItem_" + i, 0) > 0);
        }
    }
}