using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float maxSpeed = 10f;
    
    public LayerMask groundLayer;
    public LayerMask deathGround;
    public LayerMask enemyLayer;
    public LayerMask lifeLayer;
    private Camera camera;
    
    public Collider2D playerCollider;
    private Animator animator;
    private HealthManager healthManager;
    
    //Sounds
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource attackSound;
    
    // Milestone 1
    public float mileStone = 100f;
    private float mileStoneCount = 100f;
    public float mileStoneSpeedMultiplier = 1.1f;
    
    public GameManager gameManager;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
        // rigidbody.velocity = new Vector2(0, 5);
        mileStoneCount = mileStone;
    }

    // Update is called once per frame
    void Update()
    {
        bool isDead = Physics2D.IsTouchingLayers(playerCollider, deathGround);
        LayerMask sceneSwitcherLayer = LayerMask.GetMask("SwitchScene");
        bool isSwitching = Physics2D.IsTouchingLayers(playerCollider, sceneSwitcherLayer);
        bool isEnemy = Physics2D.IsTouchingLayers(playerCollider, enemyLayer);
        bool isLifeCollected = Physics2D.IsTouchingLayers(playerCollider, lifeLayer);
        if (isSwitching)
        {
            // print("Switching");
            print("Switching");
            gameManager.SwitchScene();
        }
        if (isDead)
        {
            GameOver();
        }
        
        if (isLifeCollected)
        {
            healthManager.IncreaseHealth();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, lifeLayer);
            foreach (Collider2D collider in colliders)
            {
                collider.gameObject.SetActive(false);
            }
        }

        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            mileStone += mileStoneSpeedMultiplier;
            if (speed<maxSpeed)
            {
                speed *= mileStoneSpeedMultiplier;
            }
        }

        if (isEnemy)
        {
            attackSound.Play();
            healthManager.TakeDamage();
            if (healthManager.IsDead())
            {
                attackSound.Stop();
                GameOver();
            }
            // remove the collided enemy
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, enemyLayer);
            foreach (Collider2D collider in colliders)
            {
                collider.gameObject.SetActive(false);
            }
        }


        rb.velocity = new Vector2(speed, rb.velocity.y);
        bool isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSound.Play();
            }
        }
        
        animator.SetBool("Grounded", isGrounded);
    }
    
    void GameOver()
    {
        deathSound.Play();
        gameManager.GameOver();
    }
}
