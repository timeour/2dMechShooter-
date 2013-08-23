using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float speed;
	private OTAnimatingSprite _mySprite;
	bool ismov;

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
		Vector3 velocity = new Vector3 (
			Input.GetAxis ("Horizontal"),
			Input.GetAxis ("Vertical"),
			0f
		) * speed * Time.fixedDeltaTime;

		rigidbody.velocity = velocity;
		
	}
}
