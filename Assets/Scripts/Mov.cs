using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float speed;
	private OTAnimatingSprite _mySprite;
	bool isMoving;
	private float currentHealth;
	public float healthMax;

	public OTAnimatingSprite MySprite {
		get {
			if (_mySprite == null) {
				_mySprite = GetComponentInChildren<OTAnimatingSprite> ();
			}
			return _mySprite;
		}
	}

	// Use this for initialization
	void Start ()
	{
		currentHealth = healthMax;
	}
	
	void Update ()
	{
		Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));
		float angle = Vector3.Angle (new Vector3 (mousePositionInWorld.x, mousePositionInWorld.y, transform.position.z) - transform.position, Vector3.right);
		if (mousePositionInWorld.y < transform.position.y) {
			transform.rotation = Quaternion.Euler (0f, 0f, -angle);
		} else {
			transform.rotation = Quaternion.Euler (0f, 0f, angle);
		}		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		// Set animation
//		Debug.Log(rigidbody.velocity.sqrMagnitude + " " + isMoving);
		if (rigidbody.velocity.sqrMagnitude > 1000f) {
			if (!isMoving) {
				isMoving = true;
				MySprite.Play ();
			}
		} else {
			isMoving = false;
			MySprite.Stop ();
			MySprite.ShowFrame (0);
		}
		
		Vector3 velocity = new Vector3 (
			Input.GetAxis ("Horizontal"),
			Input.GetAxis ("Vertical"),
			0f
		).normalized * speed;
		Debug.Log (speed);
		rigidbody.velocity = velocity;
		
	}
	
	void OnGUI ()
	{
		string str = null;
		if (currentHealth > 0) {
			str = currentHealth + " / " + healthMax;
		} else {
			Application.LoadLevel (2);
		}
		GUI.Box (
				new Rect (Screen.width / 2 - 40, Screen.height - 40, 80, 30), 
				str);
		GUI.Box (
			new Rect (Screen.width - 100, Screen.height / 2, 100, 30),
			"Score: " + Bullet.getScore ());
		
	}
	
	public void Damage (float damage)
	{
		currentHealth -= damage;
	}

	public void Restore (float medkit)
	{
		currentHealth += medkit;
		if (currentHealth > healthMax) {
			currentHealth = healthMax;
		}
	}
}
