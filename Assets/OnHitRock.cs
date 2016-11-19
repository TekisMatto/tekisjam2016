using UnityEngine;
using System.Collections;

public class OnHitRock : MonoBehaviour {

	public int rockHealth;
	public float force;

	// Use this for initialization
	void Start () {
	
	}

	/**
	 *	type 0: normal
	 *	type 1: smoethingd 
	 */
	void OnHit(GameObject hitter, int type) {
		--rockHealth;
		if (rockHealth <= 0) {
			Destroy (gameObject);
		}

        bool facingRight = hitter.GetComponent<Facing>().isFacingRight;
		gameObject.GetComponent <Rigidbody2D>().AddForce (new Vector2(
			5 * force * (facingRight ? 1 : -1),
			2 * force), ForceMode2D.Impulse);
	}

}
