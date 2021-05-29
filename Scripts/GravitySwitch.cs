using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    private Rigidbody2D rb;

    public int speed = 10;

    public float gravity;
    public float timer = 1;

    private bool top;
    public bool isPink;

    //SFX
    public AudioSource shiftSFX;
    public AudioSource jumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && timer <= 0 && isPink)
        {
            rb.gravityScale *= -gravity;
            Rotation();
            timer = 1;
            shiftSFX.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shifter")
        {
            rb.gravityScale *= -gravity;
            shiftSFX.Play();
        }

        if (collision.gameObject.tag == "JumpPad")
        {
            rb.velocity = Vector2.up * speed;
            jumpSFX.Play();
        }

        if (collision.gameObject.tag == "CeilingJumpPad")
        {
            rb.velocity = Vector2.down * speed;
            jumpSFX.Play();
        }
    }

    void Rotation()
    {
        if(top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }
}
