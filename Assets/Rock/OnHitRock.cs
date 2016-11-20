using UnityEngine;
using System.Collections;

public class OnHitRock : MonoBehaviour {

	public int rockHealth;
	public float force = 1;
    private bool isHit;

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
        if (type == 1) {
            if (isHit) { // WIP
                rb.AddForce(new Vector2(
                    8 * force * (facingRight ? 1 : -1),
                    4 * force), ForceMode2D.Impulse);
            } else {
                Vector2 hitterOffset = hitter.transform.position;
                rb.AddForce(new Vector2(
                    8 * force * (facingRight ? 1 : -1),
                    4 * force), ForceMode2D.Impulse);
            }


        } else if (type == 2) {
            isHit = true;
            rb.AddForce(new Vector2(
                1 * force * (facingRight ? 1 : -1),
                8 * force), ForceMode2D.Impulse);
        }
	}

}
