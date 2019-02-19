using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip[] Hits;

    // Use this for initialization
    void Start()
    {
        var rand = Random.Range(0, 2);

        AudioSource.clip = Hits[rand];
        AudioSource.Play();
    }
}