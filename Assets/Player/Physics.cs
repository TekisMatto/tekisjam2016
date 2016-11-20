using UnityEngine;
using System.Collections;

public class Physics : MonoBehaviour {
	public float gravity;
	private Rigidbody2D rb;
	private Player player;
	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!player.isGrounded) {

			Vector2 v = new Vector2 (0, gravity * Time.deltaTime);
			rb.velocity -= v;
		}

		rb.transform.position += (Vector3) (rb.velocity * Time.deltaTime);

	}


}
