using UnityEngine;
using System.Collections;

public class RockDespawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Rock") {
			Destroy (collider.gameObject);
		} else if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent <OnHitPlayer>().Damage (999999999);
		}
	}
}
