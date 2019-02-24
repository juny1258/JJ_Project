using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public GameObject FireAnimation;
    public GameObject AngerObject;

    private void Start()
    {
        if (!DataController.Instance.isAnger)
        {
            AngerObject.SetActive(false);
        }

        GetComponent<Rigidbody>().AddForce(Vector3.right * 500f);
        var randInt = Random.Range(-50, 50);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, randInt, 0));

        randInt = Random.Range(0, 1000);
        if (randInt < (DataController.Instance.criticalPercent + DataController.Instance.rubyCriticalPer +
                       DataController.Instance.devilCritical + DataController.Instance.collectionCriticalPer +
                       DataController.Instance.advancedCriticalPer) * 10)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, 1);
            tag = "CriticalAttack";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Instantiate(FireAnimation, new Vector3(transform.position.x + 0.5f, transform.position.y, 0),
                Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}