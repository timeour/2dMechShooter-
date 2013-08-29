using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	public GUIStyle welcomeLabel;
	public GUISkin customSkin;
	public Rect playGameRect;
	public Rect quitRect;
	private bool optionsMode = false;

	void OnGUI(){
			
	    if(!optionsMode){
	        GUI.Label(new Rect(Screen.width / 2, 0, 50, 20),"Welcome",welcomeLabel);
	
	        GUI.skin = customSkin;
	
	        if(GUI.Button(playGameRect,"Play Game")){
	            Application.LoadLevel("game3");  //1
	        }
	                   
	        if(GUI.Button(quitRect,"Quit")){
	            Application.Quit();                   //2
	        }
	                   
	    }else{
	                                           
	        GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Options",welcomeLabel);
	                   
	        GUI.skin = customSkin;
	                             
	        if(GUI.Button(new Rect(20, 190, 100, 30),"<< Back")){
	            optionsMode = false;
	        }
	           
	    }  
	                           
	}
}
