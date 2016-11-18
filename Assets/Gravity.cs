using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public float gravity;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = new Vector2 (0, gravity * Time.deltaTime);
		rb.velocity -= v;

	}


}
