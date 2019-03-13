using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCool : MonoBehaviour
{
    public int index;

    public GameObject Timer;
    public Text TimeText;

    private void OnEnable()
    {
        PlayerPrefs.SetFloat("BossCoolTime_" + index,
            PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) - DataController.Instance.bossCool);
        
        if (PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) > 0)
        {
            Timer.SetActive(true);
            var min = (int) PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) / 60;
            var sec = (int) PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) - 60 * min;
            TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            Timer.SetActive(false);
        }

        InvokeRepeating("CoolTime", 1, 1);
    }

    private void CoolTime()
    {
        if (PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) > 0)
        {
            PlayerPrefs.SetFloat("BossCoolTime_" + index,
                PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) - 1);

            Timer.SetActive(true);
            var min = (int) PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) / 60;
            var sec = (int) PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) - 60 * min;
            TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            Timer.SetActive(false);
        }
    }

    private void OnDisable()
    {
        DataController.Instance.bossCool = 0;
        CancelInvoke();
    }
}