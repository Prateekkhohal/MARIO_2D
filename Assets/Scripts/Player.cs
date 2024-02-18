using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private AudioManager sound;
    public Text ScoreTxt;
    public float score = 0;

    private float moveSpeed = 5f;
    private float jumpForce = 10f;
    private float dirX = 0;

    public LayerMask jumpableGround;
    public GameObject FireBall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        sound = FindObjectOfType<AudioManager>();
        sound.GameSound();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            sound.JumpSound();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

        if (Input.GetKeyDown(KeyCode.B))
        {
            ThrowBall();    
        }
    }

    void UpdateAnimationState()
    {
        if (dirX > 0)
        {
            sprite.flipX = false;
            if (IsGrounded())
            {
                Debug.Log("Running");
                anim.Play("Run");
            }
        }
        else if(dirX < 0)
        {

            sprite.flipX = true;
            if (IsGrounded())
            {
                Debug.Log("Running");
                anim.Play("Run");
            }
        }
        else if(rb.velocity.y > .1f)
        {
            Debug.Log("JUMPING");
            anim.Play("Jump");
        }
        else
        {
            Debug.Log("IDLE");
            anim.Play("Idle");
        }

    }

    private bool IsGrounded()
    {
        // Calculate the center and size of the box for ground detection.
        Vector2 boxCenter = new Vector2(coll.bounds.center.x, coll.bounds.min.y);
        Vector2 boxSize = new Vector2(coll.bounds.size.x * 0.8f, 0.1f);

        // Create a box-shaped area beneath the player to check for overlaps with the jumpable ground layer.
        Collider2D overlap = Physics2D.OverlapBox(boxCenter, boxSize, 0f, jumpableGround);

        // Return true if the box overlaps with the jumpable ground layer, indicating the player is grounded.
        return overlap != null;
    }

    void ThrowBall()
    {
        var ball = Instantiate(FireBall, transform.position, transform.rotation);
        // Get the direction the player is facing
        float throwDirection = sprite.flipX ? -1f : 1f;

        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(throwDirection * 20f,2f); 
    }

    public void UpdateScore(float obj)
    {
        score += obj;
        ScoreTxt.text = "SCORE:" + score;
    }
}
