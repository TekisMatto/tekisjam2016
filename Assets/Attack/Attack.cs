using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {


    public GameObject attack;
	private int player_id;

    public float attackTimer;
    float runningTimer;

    bool isAttacking;

    // Use this for initialization
    void Start () {
        isAttacking = false;
		player_id = gameObject.GetComponent <Player> ().player_id;
	}
	
	// Update is called once per frame
	void Update () {

        if (isAttacking)
            runningTimer -= Time.deltaTime;

        if (runningTimer < 0)
            isAttacking = false;

		if ((Input.GetButtonDown("Fire1_id" + player_id) || Input.GetButtonDown("Fire2_id" + player_id)) && !isAttacking) {
            //float inputDirection = Input.GetAxis("Horizontal");
            Vector2 playerMidPoint = (Vector2)GetComponent<Transform>().position;// + GetComponent<BoxCollider2D>().size / 2;
            GameObject newHitbox = Instantiate(attack);

            Vector2 offSet = new Vector2(0,0);

            if (Input.GetButtonDown("Fire1_id" + player_id)) { // Strike. Able to set custom timers this way
                Destroy(newHitbox, attackTimer);
                offSet = new Vector2(0.6f, 0);
                newHitbox.GetComponent<Hitbox>().type = 1;
            } else { // Bunt
                Destroy(newHitbox, attackTimer);
                newHitbox.transform.Rotate(0, 0, 90);
                offSet = new Vector2(0.5f, 0);
                newHitbox.GetComponent<Hitbox>().type = 2;
            }
            


            if (GetComponent<Facing>().isFacingRight) {
                newHitbox.transform.position = new Vector2(offSet.x + playerMidPoint.x, offSet.y + playerMidPoint.y);
            } else {
                newHitbox.transform.position = new Vector2(-offSet.x + playerMidPoint.x, offSet.y + playerMidPoint.y);
				/*if (Input.GetButtonDown("Fire1_id" + player_id)) // Cosmetic for current sprites
                {
                    newHitbox.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    newHitbox.GetComponent<SpriteRenderer>().flipY = true;
                }*/
            }

            newHitbox.transform.SetParent(GetComponent<Transform>());
            isAttacking = true;
            runningTimer = attackTimer;
        }
    }
}
