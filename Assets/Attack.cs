using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {


    public GameObject attack1;
    public GameObject attack2;

    public float attackTimer;
    float runningTimer;

    bool isAttacking;

    // Use this for initialization
    void Start () {
        isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isAttacking)
            runningTimer -= Time.deltaTime;
        if (runningTimer < 0)
            isAttacking = false;

        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && !isAttacking)
        {
            //float inputDirection = Input.GetAxis("Horizontal");
            Transform originalTransform = GetComponent<Transform>();
            float offSetX;
            float offSetY;
            GameObject newHitbox;

            if (Input.GetButtonDown("Fire1")) // Strike
            {
                newHitbox = Instantiate(attack1);
                Destroy(newHitbox, attackTimer);

            }
            else
            { // Bunt
                newHitbox = Instantiate(attack2);
                Destroy(newHitbox, attackTimer);
            }
            Vector2 offSet = newHitbox.transform.position;


            if (GetComponent<Facing>().isFacingRight)
            {
                newHitbox.transform.position = new Vector2(offSet.x + originalTransform.position.x, offSet.y + originalTransform.position.y);
            }
            else
            {
                newHitbox.transform.position = new Vector2(-offSet.x + originalTransform.position.x, offSet.y + originalTransform.position.y);
                if (Input.GetButtonDown("Fire1")) // Cosmetic for current sprites
                {
                    newHitbox.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    newHitbox.GetComponent<SpriteRenderer>().flipY = true;
                }
            }

            newHitbox.transform.SetParent(GetComponent<Transform>());
            isAttacking = true;
            runningTimer = attackTimer;
        }
    }
}
