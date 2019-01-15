using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public SpriteRenderer sprite;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool groundCollision;
    private bool doubleJumped;
    public CanvasGroup canvasYouWin;
    private int lives = 3;

    void Start()
    {

    }

    void FixedUpdate()
    {
        groundCollision = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        var transform = GetComponent<Transform>();
        if (Input.GetKey("right"))
        {
            sprite.flipX = false;
            if (Input.GetKey("left shift"))
            {
                rigidBody.velocity = new Vector2(10, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(5, rigidBody.velocity.y);
            }
        }
        if (Input.GetKey("left"))
        {
            sprite.flipX = true;
            if (Input.GetKey("left shift"))
            {
                rigidBody.velocity = new Vector2(-10, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(-5, rigidBody.velocity.y);
            }
        }
        if (groundCollision)
        {
            doubleJumped = false;
        }
        if (Input.GetKeyDown("space") && groundCollision)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 10);
        }
        if (Input.GetKeyDown("space") && !groundCollision && !doubleJumped)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 10);
            doubleJumped = true;
        }
        if (transform.position.y < -8)
        {
            lives -= 1;
            transform.position = new Vector2(transform.position.x - 5, 2);
        }
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "EnemyDamage")
        {
            lives -= 1;
            transform.position = new Vector2(transform.position.x - 5, -2);
        }
        else if (other.name == "Exit")
        {
            canvasYouWin.alpha = 1;
        }
    }
}
