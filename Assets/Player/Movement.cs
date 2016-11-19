using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.position += (Vector3) (rb.velocity * Time.deltaTime);

	}
}
