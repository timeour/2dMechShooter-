using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float speed;
	private OTAnimatingSprite _mySprite;
	bool isMoving;
	private int health;
	public int healthMax;

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
		health = healthMax;
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

		rigidbody.velocity = velocity;
		
	}
	
	void OnGUI ()
	{
		string str = null;
		if (health > 0) {
			str = health + " / " + healthMax;
		} else {
			/*str = "Dead";
			Destroy (gameObject);*/
			Application.LoadLevel (0);
		}
		GUI.Box (
				new Rect (Screen.width / 2 - 40, Screen.height - 40, 80, 30), 
				str);
		GUI.Box (
			new Rect (Screen.width - 100 , Screen.height/2, 100, 30),
			"Score: "+ Bullet.getScore());
		
	}
	
	public void Damage (int damage)
	{
		health -= damage;
	}
}
