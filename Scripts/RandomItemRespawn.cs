using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject item;

    public bool isPink;

    private Rigidbody2D rb;

    //DeathEffects
    public GameObject pinkDeathEffect;
    public GameObject blackDeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            if (isPink)
            {
                Instantiate(pinkDeathEffect, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(blackDeathEffect, transform.position, Quaternion.identity);
            }

            Respawn();
        }
    }

    public void Respawn()
    {
        item.transform.position = respawnPoint.transform.position;
        rb.gravityScale = 1;
    }
}
