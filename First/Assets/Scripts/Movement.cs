using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    public int jumpforce;
    public bool ground, doublejump;
    public StateManager statemanager;
    public MusicManager music;
    public Score sc;
    // Update is called once per frame
    void Update()
    {
        if (ground)
        {
            doublejump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                Jump();
            }
            else
            {
                if (doublejump)
                {
                    JumpDouble();
                    doublejump = false;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (statemanager.state == "Playing")
        {
            speed = 5 + (sc.score / 100);
            //Debug.Log("speed: " + speed);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void SetGravity(int x)
    {
        rb.gravityScale = x;
    }

    void Jump()
    {
        music.PlayJump();
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }

    void JumpDouble()
    {
        music.PlayJump();
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        gameObject.transform.Rotate(0, 0, 180);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
        }
    }
}
