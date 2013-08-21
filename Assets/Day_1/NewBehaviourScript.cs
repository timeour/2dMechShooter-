using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	public GUIStyle welcomeLabel;
	public GUISkin customSkin;
	public Rect playGameRect;
	public Rect optionsRect ;
	
	void OnGUI ()
	{
		GUI.Label (new Rect (Screen.width / 2, 0, 50, 20), "Welcome", welcomeLabel);

		GUI.skin = customSkin;
       
		if (GUI.Button (playGameRect, "Game_Tree"))
			Application.LoadLevel (1);
               
		if (GUI.Button (optionsRect, "Game_Cube"))
			Application.LoadLevel (2);                      
        
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
