﻿using UnityEngine;
using System.Collections;



public class Hitstop : MonoBehaviour {

	public static bool isHitstop(GameObject go) {
		Hitstop hs = go.GetComponent<Hitstop> ();
		if (hs && hs.isHitstop ())
			return true;
		return false;
	}

	private float amount;

	public bool isHitstop() {
		return amount > 0;
	}

	public void addHitstop(float x) {
		amount += x;
	}

	// Use this for initialization
	void Start () {
		amount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if ( isHitstop() ) { // no simulation during hitsop
			amount -= Time.deltaTime;
			if (amount < 0)
				amount = 0;
			return;
		}
	}
}
