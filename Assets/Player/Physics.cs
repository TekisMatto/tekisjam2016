using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {
	public float gravity;
	private Rigidbody2D rb;
	private Player player;

	public float hitStop;
	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<Player> ();
		hitStop = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (hitStop > 0) {
			hitStop -= Time.deltaTime;
			return;
		}
		
		if (!player.isGrounded) {

			Vector2 v = new Vector2 (0, gravity * Time.deltaTime);
			rb.velocity -= v;
		}

		rb.transform.position += (Vector3) (rb.velocity * Time.deltaTime);

	}


}
