using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy : MonoBehaviour
{
    private float startPoint;
    private float groundWidth;
    public float speed = 0.0001f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Collider2D enemyCollider;
    public LayerMask groundLayer;
    void Start()
    {
        startPoint = transform.position.x;
        enemyCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy to the left and flip it when it reaches the end of the ground
        groundWidth = GetComponent<BoxCollider2D>().size.x;
        float currentPoint = transform.position.x;
        transform.position = new Vector2(currentPoint - speed, transform.position.y);
        //Detect if the enemy is at the end of the ground
        if (MathF.Abs(currentPoint - startPoint) >= MathF.Abs(groundWidth/2 + 4f))
        {
            speed = -speed;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            startPoint = currentPoint;
        }
        // check if the enemy is on the ground and collide with another ground
        


        
        
    }
}
