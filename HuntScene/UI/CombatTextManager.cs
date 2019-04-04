using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour
{
    private static CombatTextManager instance;

    public GameObject BaseDamage;
    public GameObject CriticalDamage;
    public GameObject CombatImage;

    public Transform canvasTransform;

    private Color TextColor;

    public static CombatTextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CombatTextManager>();
            }

            return instance;
        }
    }

    public void CreateText(Vector3 position, string text, bool isCritical)
    {
        if (!isCritical)
        {
            var sct = Instantiate(BaseDamage, position, Quaternion.identity);

            sct.transform.SetParent(canvasTransform);

            sct.GetComponentInChildren<CombatText>().Initialize();
            sct.GetComponentInChildren<Text>().text = text;
        }
        else
        {
            var sct = Instantiate(CriticalDamage, position, Quaternion.identity);

            sct.transform.SetParent(canvasTransform);

            sct.GetComponentInChildren<CombatText>().Initialize();
            sct.GetComponentInChildren<Text>().text = text;
        }
    }

    public void CreateImage(Vector3 position, string name, int count)
    {
        var sct = Instantiate(CombatImage, position, Quaternion.identity);
        sct.GetComponentInChildren<Image>().sprite = Resources.Load(name, typeof(Sprite)) as Sprite;

        sct.transform.SetParent(canvasTransform);

        sct.GetComponentInChildren<CombatText>().Initialize();
        sct.GetComponentInChildren<Text>().text = "X " + count;
        if (name.Equals("Gold/sapphire"))
        {
            ColorUtility.TryParseHtmlString("#5BCA27", out TextColor);
            sct.GetComponentInChildren<Text>().color = TextColor;
        }
        else if (name.Equals("Gold/PetStone"))
        {
            ColorUtility.TryParseHtmlString("#93F84A", out TextColor);
            sct.GetComponentInChildren<Text>().color = TextColor;
        }
        else if (name.Equals("Gold/ruby"))
        {
            ColorUtility.TryParseHtmlString("#F3251F", out TextColor);
            sct.GetComponentInChildren<Text>().color = TextColor;
        }
    }
}