using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPet : MonoBehaviour
{
    public GameObject SelectPanel;

    public GameObject[] PetObject;

    public int index;

    private void Start()
    {
        EventManager.SelectPetEvent += Select;
    }

    private void OnDestroy()
    {
        EventManager.SelectPetEvent -= Select;
    }

    private void Select()
    {
        SelectPanel.SetActive(DataController.Instance.petIndex == index);
    }

    private void OnEnable()
    {
        SelectPanel.SetActive(DataController.Instance.petIndex == index);
    }

    public void SelectItem()
    {
        if (PlayerPrefs.GetInt("petSkill_" + (index + 1), -1) > -1)
        {
            // TODO 펫 장착
            foreach (var pet in PetObject)
            {
                pet.SetActive(false);
            }

            PetObject[index].SetActive(true);
            DataController.Instance.petIndex = index;

            EventManager.Instance.SelectPet();
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                NotificationManager.Instance.SetNotification("펫 구매 후 장착할 수 있습니다.");
            }
            else
            {
                NotificationManager.Instance.SetNotification("You can equiping pet after buy it.");
            }
        }
    }
}