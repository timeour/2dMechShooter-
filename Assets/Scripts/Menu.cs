﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	public GUIStyle welcomeLabel;
	public GUISkin customSkin;
	public Rect playGameRect;
	public Rect quitRect;
	public Rect ReRect;
	private bool optionsMode = false;
	private bool menuMode = true;   //1
	private bool gameMode = false;  //1
	
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}
	
	void Update ()
	{  
	    
	}
	
	public void OnGUI ()
	{
		if (Input.GetKey (KeyCode.Escape)) {  //2
			menuMode = true;                //1
			optionsMode = false;  
			Time.timeScale = 0;             //3
                
		}

		if (menuMode) {
			if (!optionsMode) {                       
                        
				GUI.Label (new Rect (Screen.width / 2, 0, 50, 20), "2D Mech Shooter", welcomeLabel);
                
				GUI.skin = customSkin;
                        
				if (!gameMode) {              //1
					if (GUI.Button (playGameRect, "Play Game")) {
						menuMode = false;   //1
						gameMode = true;    //1
						Time.timeScale = 1; //3
						Application.LoadLevel ("game3");
					}
				} else {
					if (GUI.Button (playGameRect, "Resume")) {

						Time.timeScale = 1; //3
						menuMode = false;   //1
					}
					if (GUI.Button (ReRect, "Restart")) {
						Application.LoadLevel ("game3");  
						menuMode = false;
						Time.timeScale = 1;
					}
				}
               
                        
				if (GUI.Button (quitRect, "Quit")) {
					Application.Quit ();
				}
                        
			}
		}

	}
}
