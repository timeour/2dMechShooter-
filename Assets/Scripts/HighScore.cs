using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour
{
	
	public static int oldScore;
	public string HScore;
	public Rect againRect;
	public Rect menuRect;

	// Use this for initialization
	void Start ()
	{
		Rating ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public static void Rating ()
	{
		for (int i=1; i<=5; i++) {
			if (PlayerPrefs.HasKey (i + "HScore")) {
				if (PlayerPrefs.GetInt (i + "HScore") < Bullet.getScore ()) { 
					oldScore = PlayerPrefs.GetInt (i + "HScore");
					PlayerPrefs.SetInt (i + "HScore", Bullet.getScore ());
					//PlayerPrefs.Save ();
					Debug.Log ("paffas");
					Bullet.setScore ();
				}
			} else {
				PlayerPrefs.SetInt (i + "HScore", Bullet.getScore ());
				//PlayerPrefs.Save ();
				Debug.Log ("fgyhjk");
				Bullet.setScore ();
			}
		}
	}

	void OnGUI ()
	{
		for (int i=1; i<=5; i++) {
			if (PlayerPrefs.HasKey (i + "HScore")) {
				GUI.Box (new Rect (100, 75 * i, 150, 50), "Pos " + i + ". " + PlayerPrefs.GetInt (i + "HScore"));
			}
		}
		if (GUI.Button (againRect, "Again")) {
			Application.LoadLevel (1);
		}
		if (GUI.Button (menuRect, "Menu")) {
			Application.LoadLevel (0);
		}
       
	}
	
}
