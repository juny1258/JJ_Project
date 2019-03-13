using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour
{
    public GameObject LoadDataPanel;

    public string xmlData = "";

    private static SaveDataManager instance;

    public static SaveDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveDataManager>();

                if (instance == null)
                {
                    instance = new GameObject("SaveDataManager").AddComponent<SaveDataManager>();
                }
            }

            return instance;
        }
    }

    private void OnEnable()
    {
    }

    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }


    public float GetFloat(string key, float first_value)
    {
        var result = PlayerPrefs.GetFloat(key, first_value);

        xmlData += key + ":f:" + result + ",";

        return result;
    }

    public string GetString(string key, string first_value)
    {
        var result = PlayerPrefs.GetString(key, first_value);

        xmlData += key + ":s:" + result + ",";

        return result;
    }

    public int GetInt(string key, int first_value)
    {
        var result = PlayerPrefs.GetInt(key, first_value);

        xmlData += key + ":i:" + result + ",";

        return result;
    }

    public void GetData(string data)
    {
        string[] array = data.Split(',');

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Contains(":f:"))
            {
                SetFloat(array[i].Replace(":f:", "|").Split('|')[0],
                    float.Parse(array[i].Replace(":f:", "|").Split('|')[1]));
            }
            else if (array[i].Contains(":s:"))
            {
                SetString(array[i].Replace(":s:", "|").Split('|')[0],
                    (array[i].Replace(":s:", "|").Split('|')[1]));
            }
            else if (array[i].Contains(":i:"))
            {
                SetInt(array[i].Replace(":i:", "|").Split('|')[0],
                    int.Parse(array[i].Replace(":i:", "|").Split('|')[1]));
            }
        }

        DataController.Instance.UpdateDamage();
        DataController.Instance.UpdateCritical();
        DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

        LoadDataPanel.SetActive(true);
        LoadDataPanel.GetComponentInChildren<Text>().text = "데이터를 불러왔습니다.\n어플을 재시작 해주세요!";
        LoadDataPanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
            LoadDataPanel.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        });
        Time.timeScale = 0;
    }
}