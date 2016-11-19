using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {
	public int type = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
//			collider.gameObject.GetComponent <OnHitRock> ().OnHit (gameObject.transform.parent, type);
		} else if (collider.gameObject.tag == "Rock") {
			collider.gameObject.GetComponent <OnHitRock> ().OnHit (gameObject.transform.parent.gameObject, type);
			Debug.Log("Rock hit");
		}
	}
}
