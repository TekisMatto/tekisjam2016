using UnityEngine;
using System.Collections;

public class OnHitPlayer : MonoBehaviour {

	public GameObject victoryHandler;
    public float rockSpeedThreshold;
    public float minRockDamage;
    public float rockDamageScale;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool Damage (int damage)
    {
        int health = gameObject.GetComponent<Player>().health -= damage;
        if (health <= 0)
        {
            int id = gameObject.GetComponent<Player>().player_id;
            if (id == 1)
                id = 2;
            else
                id = 1;
            GameObject vh = Instantiate(victoryHandler);
            vh.GetComponent<VictoryHandlerScript>().text = "Player " + id + " wins!";
            Destroy(gameObject);
            return true;
        }
        return false;
    }

	// When hit by another player
	public void OnHit (GameObject hitter, int type) {
		int damage;
		if (type == 1) {
			damage = 8;
		} else {
			damage = 0;
		}

        if (Damage(damage))
            return;

		bool facingRight = hitter.GetComponent<Facing>().isFacingRight;
		Rigidbody2D rb = gameObject.GetComponent <Rigidbody2D>();
		rb.velocity = new Vector2 (
			( 5 + (type == 1 ? 15 : 0) )* (facingRight ? 1 : -1),
			5 + (type == 2 ? 4 : 0));
		rb.MovePosition (rb.position + new Vector2 (0, 0.2f));

		GetComponent<Player> ().stun = 0.1f;
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Rock")
        {
            Vector2 rockVelocity = collider.gameObject.GetComponent<Rigidbody2D>().velocity;
            if (rockVelocity.magnitude > rockSpeedThreshold)
            {
                int damage = (int)(minRockDamage + (rockVelocity.magnitude - rockSpeedThreshold) * rockDamageScale);
                if (Damage(damage))
                    return;
				Rigidbody2D rb = gameObject.GetComponent <Rigidbody2D>();
				rb.velocity = new Vector2 ( damage*5* (rockVelocity.x > 0 ? 1 : -1 ),
					damage * (rockVelocity.y < 0 ? 0 : 2f ) );
				rb.MovePosition (rb.position + new Vector2 (0, 0.2f));
                collider.gameObject.GetComponent<Rigidbody2D>().velocity /= 2;

				GetComponent<Player> ().stun = 0.05f;
            }

        }
    }
}
