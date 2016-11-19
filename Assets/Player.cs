using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    

    Rigidbody2D playerRigidbody;

	public int player_id;
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;

    bool isGrounded;
    

    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Move();
            //Jump();
            //Crouch();
    }

    void Move()
    {
        float movement;
        
		movement = speed * Input.GetAxis("Horizontal_id" + player_id);
        playerRigidbody.velocity += new Vector2(movement, 0);
		if (Mathf.Abs (playerRigidbody.velocity.x) > maxSpeed)
		{
			if (playerRigidbody.velocity.x > 0)
				playerRigidbody.velocity = new Vector2 (maxSpeed, playerRigidbody.velocity.y);
			else
				playerRigidbody.velocity = new Vector2 (-maxSpeed, playerRigidbody.velocity.y);
		}
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump_id" + player_id) && isGrounded)
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

    /*void Crouch()
    {
        float crouchHeight = 0.5f;
        if (Input.GetAxis("Vertical") < 0)
        {
            BoxCollider2D collider = GetComponentInChildren<BoxCollider2D>();
            collider.size = new Vector2(collider.size.x, collider.size.y - crouchHeight);
            collider.offset = new Vector2(collider.size.x, collider.size.y - crouchHeight);
        }
    }*/


}
