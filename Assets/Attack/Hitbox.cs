using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {
	public int type;
    public float startupTimer;

	// Use this for initialization
	void Start () {
        GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        startupTimer -= Time.deltaTime;
        if (startupTimer < 0)
           GetComponent<Collider2D>().enabled = true;
	}

	private void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent <OnHitPlayer> ().OnHit (gameObject.transform.parent.gameObject, type);
		} else if (collider.gameObject.tag == "Rock") {
			collider.gameObject.GetComponent <OnHitRock> ().OnHit (gameObject.transform.parent.gameObject, type);
		}
	}
}
