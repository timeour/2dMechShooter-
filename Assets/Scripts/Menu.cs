using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

	public GUIStyle welcomeLabel;
	public GUISkin customSkin;
	public Rect playGameRect;
	public Rect quitRect;
	public Rect ReRect;
	private MenuMode menuMode;
	public Renderer comicPlane;
	public Material[] comics;
	private int comicIndex;
	
	void Awake ()
	{
	}
	
	void Update ()
	{
		if (menuMode == MenuMode.Comics) {
			if (Input.GetMouseButtonDown (0)) {
				if (comicIndex < comics.Length - 1) {
					comicIndex++;
					comicPlane.sharedMaterial = comics [comicIndex];
				} else { 
					Application.LoadLevel ("game3");
				}
			}
		}
	}
	
	public void OnGUI ()
	{
		switch (menuMode) {
		case MenuMode.MainMenu:
			GUI.Label (new Rect (Screen.width / 2, 0, 50, 20), "Welcome", welcomeLabel);   
			GUI.skin = customSkin;
			
			if (GUI.Button (playGameRect, "Play Game")) {
				StartGame ();
			}
			if (GUI.Button (quitRect, "Quit")) {
				Application.Quit ();
			}
			break;
		case MenuMode.Options:
			break;
		case MenuMode.Comics:
			break;
		}
	}

	void StartGame ()
	{
		menuMode = MenuMode.Comics;
		comicPlane.gameObject.SetActive (true);
		comicIndex = 0;
		comicPlane.sharedMaterial = comics [comicIndex];
	}
}

public enum MenuMode
{
	MainMenu,
	Options,
	Comics
}