using UnityEngine;
using System.Collections;

public class VictoryHandlerScript : MonoBehaviour {

	public string text;
	public string sceneName;
	private float timer = 4.0F;
	private static Rect textArea;

	// Use this for initialization
	void Start () {
		float width = 40;
		textArea = new Rect (
			Screen.width / 2 - 50,
			Screen.height / 2 - width / 2,
			100,
			width);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0.0F) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		}
	}

	void OnGUI () {
		GUI.Label(textArea, text);
	}
}
