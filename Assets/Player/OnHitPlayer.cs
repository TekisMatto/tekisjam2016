using UnityEngine;
using System.Collections;

public class OnHitPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// When hit by another player
	public void OnHit (GameObject hitter, int type) {
		int damage;
		if (type == 1) {
			damage = 8;
		} else {
			damage = 0;
		}

		int health = gameObject.GetComponent <Player> ().health -= damage;
		if (health <= 0) {
			Destroy (gameObject);
		}

		bool facingRight = hitter.GetComponent<Facing>().isFacingRight;
		Rigidbody2D rb = gameObject.GetComponent <Rigidbody2D>();
		rb.velocity = new Vector2 (
			8 * (facingRight ? 1 : -1) - (type == 1 ? 4 : 0),
			4 + (type == 1 ? 6 : 0));
	}
}
