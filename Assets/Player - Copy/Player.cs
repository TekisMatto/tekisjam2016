using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    

    Rigidbody2D playerRigidbody;

    Bounds playerBox;

	public int player_id;
	public int maxHealth;
	public int health = 0;
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;

	public float maxJump;
	public float airControl;

    public bool isGrounded;

	public float stun;


	private float jumpTime;


    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
		playerBox = GetComponent<BoxCollider2D> ().bounds;
		health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
		if (Hitstop.isHitstop (gameObject))
			return;
		if (stun > 0) {
			stun -= Time.deltaTime;
			return;
		}
        Move();
        Jump();
        //Crouch();
    }


	void GodMove() {
		isGrounded = true;
		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"))*speed;
		playerRigidbody.velocity = movement;
	}

    void Move()
    {

		float movement = speed * Input.GetAxis("Horizontal_id"+ player_id);

		if (Mathf.Abs (movement) < 0.05f || GetComponent<Attack>().isAttacking)
			movement = -playerRigidbody.velocity.x/4;

		if (!isGrounded)
			movement *= airControl;

        playerRigidbody.velocity += new Vector2(movement, 0);

		if (stun<=0 && Mathf.Abs (playerRigidbody.velocity.x) > maxSpeed)
		{
			if (playerRigidbody.velocity.x > 0)
				playerRigidbody.velocity = new Vector2 (maxSpeed, playerRigidbody.velocity.y);
			else
				playerRigidbody.velocity = new Vector2 (-maxSpeed, playerRigidbody.velocity.y);
		}
    }

    void Jump()
    {
		if (isGrounded)
			jumpTime = maxJump;
		else if (!Input.GetButton ("Jump_id" + player_id))
			jumpTime = 0;
		
		if (Input.GetButton("Jump_id" + player_id) && jumpTime > 0)
		{
            playerRigidbody.velocity += new Vector2(0, jumpSpeed);
            isGrounded = false;
			jumpTime -= Time.deltaTime;
        }
    }


	private void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Platform")) {
			Bounds otherBox = other.bounds;
			Vector3 pos = transform.position;
			Vector3 otherPos = otherBox.center;//+ new Vector3(0, otherBox.extents.y/2);

			//Debug.DrawRay (otherPos, otherBox.extents,Color.blue);
			//Debug.DrawRay (pos, playerBox.extents, Color.blue);

			//Debug.DrawLine (pos, otherPos);
		
			Vector3 pen = new Vector3();

			float maxX = pos.x + playerBox.extents.x;
			float minX = pos.x - playerBox.extents.x;

			float maxY = pos.y + playerBox.extents.y;
			float minY = pos.y - playerBox.extents.y;

			float otherMaxX = otherPos.x + otherBox.extents.x;
			float otherMinX = otherPos.x - otherBox.extents.x;

			float otherMaxY = otherPos.y + otherBox.extents.y;
			float otherMinY = otherPos.y - otherBox.extents.y;

			if (pos.x > otherPos.x)
				pen.x = -Mathf.Abs (minX - otherMaxX);
			else
				pen.x = Mathf.Abs (maxX - otherMinX);

			if (pos.y > otherPos.y)
				pen.y = -Mathf.Abs (minY - otherMaxY);
			else
				pen.y = Mathf.Abs (maxY - otherMinY);


	
			//Debug.DrawRay (pos, pen, Color.red);
			//Debug.Log (pen);

			float dot = Vector2.Dot (pen, playerRigidbody.velocity);



				if (Mathf.Abs (pen.x) < Mathf.Abs (pen.y)) {

					playerRigidbody.transform.position -= new Vector3 (pen.x * 1.01f, 0);
					playerRigidbody.velocity = new Vector2 (-pen.x, playerRigidbody.velocity.y);

				} else {

					playerRigidbody.transform.position -= new Vector3 (0, pen.y);
					if (playerRigidbody.velocity.y < 0)
						isGrounded = true;
					playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, 0);

				}



	}

	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Platform")) {
			isGrounded = false;
		}

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
