using UnityEngine;
using System.Collections;

public class HitPlatform : MonoBehaviour {
	private Transform tf;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		Transform otherPos = other.GetComponent<Transform> ();

		Debug.Log (other.tag);

		if (other.CompareTag("Platform") ) {
			Debug.Log (rb.velocity.y);
			float penX = rb.position.x - otherPos.position.x;
			float penY = rb.position.y - otherPos.position.y;
			if (Vector2.Dot (rb.velocity.normalized, new Vector2 (penX, penY).normalized) > 0) {
				if (Mathf.Abs (penY) < Mathf.Abs (penX)) {
					rb.MovePosition (rb.position - new Vector2 (0, rb.velocity.y * 1.5f * Time.deltaTime));
					rb.velocity -= new Vector2 (0, rb.velocity.y * 1.2f);
				} else {
					rb.MovePosition (rb.position - new Vector2 (rb.velocity.x * 1.5f * Time.deltaTime, 0));
					rb.velocity -= new Vector2 (rb.velocity.x * 1.2f, 0);
				}
			}
		}
	}
}
