using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door;
    public GameObject explosionEffect;

    public int timesActive = 1;

    public Transform spawner;

    //SFX
    public AudioSource buttonSFX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.SetActive(false);
            
            if(timesActive == 1)
            {
                Instantiate(explosionEffect, spawner.position, spawner.rotation);
                timesActive--;
                buttonSFX.Play();
            }
        }
    }
}
