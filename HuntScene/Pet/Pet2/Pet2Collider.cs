using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet2Collider : MonoBehaviour
{
    public GameObject Collider2;

    private GameObject col2;
    private GameObject col3;
    
    public void SetCollider2()
    {
        col2 = Instantiate(Collider2, new Vector3(5.85f, -2.45f, 0), Quaternion.identity);
        Invoke("DeleteObject2", 0.5f);
    }

    private void DeleteObject2()
    {
        Destroy(col2);
    }

    public void WaterSlide()
    {
        col3 = Instantiate(Collider2, new Vector3(-11.99f, -2.62f, 0), Quaternion.identity);
        col3.GetComponent<Rigidbody>().AddForce(Vector3.right * 580);
    }

    public void Lightning()
    {
        col3 = Instantiate(Collider2, new Vector3(-6.3f, -2.62f, 0), Quaternion.identity);
        col3.GetComponent<Rigidbody>().AddForce(Vector3.right * 750);
    }
}
