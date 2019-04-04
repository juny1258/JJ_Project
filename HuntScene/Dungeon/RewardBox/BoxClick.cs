using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    public GameObject SkillEffect;
    public GameObject Panel;

    public Vector3 position;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.left * 430);
        Invoke("OnMouseUp", 2);
        Invoke("Des", 5);
    }

    private void OnMouseUp()
    {
        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        var randInt1 = Random.Range(1, 101);
        if (randInt1 <= 30)
        {
            var randInt = Random.Range(1, 6) * DataController.Instance.dungeonLevel;
            CombatTextManager.Instance.CreateImage(position, "Gold/ruby", randInt);
            DataController.Instance.ruby += randInt;
            DataController.Instance.dungeonRuby += randInt;
        }
        else if (randInt1 > 30 && randInt1 <= 60)
        {
            var randInt = Random.Range(1, 6) * DataController.Instance.dungeonLevel;
            CombatTextManager.Instance.CreateImage(position, "Gold/sapphire", randInt);  
            DataController.Instance.sapphire += randInt;
            DataController.Instance.dungeonSapphire += randInt;
        }
        else
        {
            var randInt = Random.Range(1, 5) * DataController.Instance.dungeonLevel;
            CombatTextManager.Instance.CreateImage(position, "Gold/PetStone", randInt); 
            DataController.Instance.petStone += randInt;
            DataController.Instance.dungeonPetStone += randInt;
        }
        Destroy(Panel);
    }

    private void Des()
    {
        Destroy(gameObject);
    }
}