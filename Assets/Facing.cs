using UnityEngine;
using System.Collections;

public class Facing : MonoBehaviour {

    public bool isFacingRight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0)
            isFacingRight = true;
        else if (Input.GetAxis("Horizontal") < 0)
            isFacingRight = false;
        GetComponentInChildren<SpriteRenderer>().flipX = !isFacingRight;
    }
}
