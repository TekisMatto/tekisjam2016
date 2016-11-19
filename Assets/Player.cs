﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody2D playerRigidbody;
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;
    bool isGrounded;
    float movement;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Jump();
	}

    void Move()
    {
        movement = speed * Input.GetAxis("Horizontal");
        playerRigidbody.velocity += new Vector2(movement, 0);
        if (Mathf.Abs(playerRigidbody.velocity.x) > maxSpeed)
            if (playerRigidbody.velocity.x > 0)
                playerRigidbody.velocity = new Vector2(maxSpeed, playerRigidbody.velocity.y);
            else
                playerRigidbody.velocity = new Vector2(-maxSpeed, playerRigidbody.velocity.y);

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.velocity += new Vector2(0, jumpSpeed);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Wall")
            isGrounded = true;
    }
}