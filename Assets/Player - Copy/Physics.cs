using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {
	public float gravity;
	private Rigidbody2D rb;
	private Player player;

	private Vector2? oldSpeed = null;
	private Vector2? oldPos = null;


	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<Player> ();

	}

	void FixedUpdate () {

		if (Hitstop.isHitstop (gameObject)) {
			if (oldSpeed == null)
				oldSpeed = rb.velocity;
			rb.velocity = (Vector2)Vector2.zero;
			
			if (oldPos == null)
				oldPos = rb.position;
			rb.position = (Vector2)oldPos;

			return;
		} else {
			if (oldSpeed != null) {
				rb.velocity = (Vector2)oldSpeed;
				oldSpeed = null;
			}
			if (oldPos != null)
				oldPos = null;
		}
		
		if (player && !player.isGrounded) {

			Vector2 v = new Vector2 (0, gravity * Time.deltaTime);
			rb.velocity -= v;
		}


	}


}
