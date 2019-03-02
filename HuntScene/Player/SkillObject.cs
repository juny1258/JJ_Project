using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public GameObject FireAnimation;
    public GameObject AngerObject;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Skill"), LayerMask.NameToLayer("Skill"));
    }

    private void Start()
    {
        if (!DataController.Instance.isAnger)
        {
            AngerObject.SetActive(false);
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