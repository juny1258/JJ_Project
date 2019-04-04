using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGold : MonoBehaviour
{
    private bool isGet;

    private void Update()
    {
        if (isGet)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.11f, 4.18f, 0), 7 * Time.deltaTime);
        }
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Gold"), LayerMask.NameToLayer("Gold"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Gold"), LayerMask.NameToLayer("Monster"));
        GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        Invoke("GetGold", 2f);
    }

    private void GetGold()
    {
        GetComponentInChildren<Rigidbody>().useGravity = false;
        isGet = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
        }
    }
}
