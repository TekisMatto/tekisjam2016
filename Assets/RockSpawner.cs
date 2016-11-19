using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

	// Game updates before next spawn
	public float spawnRate = 5;
	// Chance of spawning more rocks
	public float spawnChance;
	public float spawnRadius;
	public int rockCap = 20;
	public GameObject rock;
	private float spawnTimer;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime * 5;
		Debug.Log ("timer: " + spawnTimer);
		if (spawnTimer > 0) {
			return;
		}
		spawnTimer += spawnRate;

		int rocks = GameObject.FindGameObjectsWithTag ("Rock").Length;
		if (rocks < rockCap) {
			if (Random.value < spawnChance * ((float) (rockCap - rocks) / rockCap)) {
				GameObject newRock = Instantiate (rock);
				Vector2 newPosition;
				newPosition.x = gameObject.transform.position.x - spawnRadius + (Random.value * spawnRadius * 2);
				newPosition.y = gameObject.transform.position.y;
				rock.transform.position = newPosition;
			}
		}
	}
}
