using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSkill : MonoBehaviour
{
    public GameObject[] DustObjects;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(PlaySkill());
    }

    private IEnumerator PlaySkill()
    {
        int i = 0;
        while (i < 7)
        {
            DustObjects[i].SetActive(true);
            i++;

            yield return new WaitForSeconds(0.2f);
        }

        Invoke("DeleteObject", 3f);
    }

    private void DeleteObject()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
    }
}