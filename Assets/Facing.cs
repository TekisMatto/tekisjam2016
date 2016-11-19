using UnityEngine;
using System.Collections;

public class Facing : MonoBehaviour {

    public bool isFacingRight;
	private int player_id;

    // Use this for initialization
    void Start () {
		player_id = gameObject.GetComponent <Player> ().player_id;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal_id" + player_id) > 0)
            isFacingRight = true;
		else if (Input.GetAxis("Horizontal_id" + player_id) < 0)
            isFacingRight = false;
        GetComponentInChildren<SpriteRenderer>().flipX = !isFacingRight;
    }
}
