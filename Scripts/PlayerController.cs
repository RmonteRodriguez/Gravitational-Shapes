using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Shake shake;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    public bool isPink;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    public Transform playerSpawner;
    public GameObject player;

    //DeathEffects
    public GameObject pinkDeathEffect;
    public GameObject blackDeathEffect;

    //SFX
    public AudioSource destroyedSFX;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
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
        destroyedSFX.Play();
        player.transform.position = playerSpawner.transform.position;
        rb.gravityScale = 1;
    }
}
