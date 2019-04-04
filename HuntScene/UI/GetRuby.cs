using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRuby : MonoBehaviour
{
    public Animator GoldAnimation;
    public Text RisingGoldText;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Gold"))
        {
            Destroy(other.gameObject);
            GoldAnimation.Play("GetGold", -1, 0);
            var getRuby = DataController.Instance.rubyQueue.Dequeue();
            DataController.Instance.ruby += getRuby;
            RisingGoldText.gameObject.SetActive(false);
            RisingGoldText.gameObject.SetActive(true);
            RisingGoldText.text = "+ " + GetThousandCommaText(getRuby);
        }
    }
    
    public string GetThousandCommaText(float data)
    {
        return string.Format("{0:#,###}", data);
    }
}
