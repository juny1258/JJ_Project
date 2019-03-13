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
        for (int i = 0; i < 20; i++)
        {
            var item = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
            item.GetComponent<Text>().text =
                "파우스트에게 준 데미지 " + GetThousandCommaText((float) (500000f * Math.Pow(2, i))) +
                " - 데빌스톤 " + (i + 1) + "개";

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