using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public int width;
	public int offset;

	private Rect remainingRect;
	private Rect takenRect;
	private int player_id;
	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;
	private static Color remainingColor = new Color(0.0F, 1.0F, 0.0F);
	private static Color takenColor = new Color(1.0F, 0.0F, 0.0F);

	// Use this for initialization
	void Start () {
		player_id = gameObject.GetComponent <Player> ().player_id;
		remainingRect.y = 0;
		takenRect.y = 0;
		remainingRect.height = width;
		takenRect.height = width;
	}

	void Update () {
		UpdateRects ();
	}

	void OnGUI () {
		GUIDrawRect (remainingRect, remainingColor);
		GUIDrawRect (takenRect, takenColor);
	}

	void UpdateRects () {
		float healthRatio =
			(float) gameObject.GetComponent <Player> ().health / gameObject.GetComponent <Player> ().maxHealth;
		Debug.Log (healthRatio);
		remainingRect.x = 0 + (player_id == 1 ? 0 : (Screen.width / 2));
		remainingRect.width = Screen.width / 2 * healthRatio;
		takenRect.x = Screen.width / 2 * healthRatio + (player_id == 1 ? 0 : (Screen.width / 2));
		takenRect.width = Screen.width / 2 * (1 - healthRatio);
	}

	// Note that this function is only meant to be called from OnGUI() functions.
	public static void GUIDrawRect( Rect position, Color color )
	{
		if( _staticRectTexture == null )
		{
			_staticRectTexture = new Texture2D( 1, 1 );
		}

		if( _staticRectStyle == null )
		{
			_staticRectStyle = new GUIStyle();
		}
		_staticRectTexture.SetPixel( 0, 0, color );
		_staticRectTexture.Apply();

		_staticRectStyle.normal.background = _staticRectTexture;

		GUI.Box( position, GUIContent.none, _staticRectStyle );
	}
}
