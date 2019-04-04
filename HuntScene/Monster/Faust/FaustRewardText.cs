using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaustRewardText : MonoBehaviour
{
    public Transform ItemView;
    public GameObject Item;

    private Color color;
    // Use this for initialization
    void OnEnable()
    {
        for (int i = 0; i < 40; i++)
        {
            var item = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                item.GetComponent<Text>().text =
                    "파우스트에게 준 데미지 " + GetThousandCommaText((float) (1000000f * Math.Pow(2, i))) +
                    " - 데빌스톤 " + (i + 1) + "개";   
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                item.GetComponent<Text>().text =
                    "ファウストに与えたダメージ " + GetThousandCommaText((float) (1000000f * Math.Pow(2, i))) +
                    " - 悪魔の石 " + (i + 1) + "個";   
            }
            else
            {
                item.GetComponent<Text>().text =
                    "Faust Damage " + GetThousandCommaText((float) (1000000f * Math.Pow(2, i))) +
                    " - Get Devilstone " + (i + 1) + " EA";   
            }

            if (i % 2 == 1)
            {
                ColorUtility.TryParseHtmlString("#FFED00FF", out color);
                item.GetComponent<Text>().color = color;
            }

            item.transform.SetParent(ItemView, false);
        }
    }

    public string GetThousandCommaText(float data)
    {
        return string.Format("{0:#,###}", data);
    }
}