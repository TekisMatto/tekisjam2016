using UnityEngine;
using System.Collections;

public class OnHitRock : MonoBehaviour {

	public int rockHealth;
	public float force = 1;

	// Use this for initialization
	void Start () {
	
	}

	/**
	 *	type 0: normal
	 *	type 1: smoethingd 
	 */
	public void OnHit (GameObject hitter, int type) {
		--rockHealth;
		if (rockHealth <= 0) {
			Destroy (gameObject);
		}

        bool facingRight = hitter.GetComponent<Facing>().isFacingRight;
		Rigidbody2D rb = gameObject.GetComponent <Rigidbody2D>();
		rb.velocity = new Vector2 (0, 0);
		rb.AddForce (new Vector2(
			8 * force * (facingRight ? 1 : -1),
			4 * force), ForceMode2D.Impulse);
	}

}
