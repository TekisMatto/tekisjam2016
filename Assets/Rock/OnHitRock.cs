using UnityEngine;
using System.Collections;

public class OnHitRock : MonoBehaviour {

	public int rockHealth;
	public float force = 1;
    private bool isHit;

    public float hitTimer;
    float runningTimer;

	// Use this for initialization
	void Start () {
	
	}

	/**
	 *	type 0: normal
	 *	type 1: smoethingd 
	 */

    void Update()
    {
        Debug.Log(runningTimer);
        if (runningTimer > 0)
            runningTimer -= Time.deltaTime;
        else
            isHit = false;
    }

	public void OnHit (GameObject hitter, int type) {
		--rockHealth;
		if (rockHealth <= 0) {
			Destroy (gameObject);
		}

        runningTimer = hitTimer;
        

        bool facingRight = hitter.GetComponent<Facing>().isFacingRight;
		Rigidbody2D rb = gameObject.GetComponent <Rigidbody2D>();
		rb.velocity = new Vector2 (0, 0);
        if (type == 1) {
            if (isHit) { // WIP
                Vector2 hitterOffset = (Vector2)hitter.transform.position - rb.position;
                Debug.Log(hitterOffset);
                rb.AddForce(new Vector2(
                    (8 * force + 10 * Mathf.Abs(hitterOffset.x)) * (facingRight ? 1 : -1),
                    4 * force + 20 * -hitterOffset.y), ForceMode2D.Impulse);
            } else {
                rb.AddForce(new Vector2(
                    9 * force * (facingRight ? 1 : -1),
                    4 * force), ForceMode2D.Impulse);
            }


        } else if (type == 2) {
            rb.AddForce(new Vector2(
                1 * force * (facingRight ? 1 : -1),
                8 * force), ForceMode2D.Impulse);
        }

        isHit = true;
    }

}
