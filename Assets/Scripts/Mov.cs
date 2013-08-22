using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	void Update() {
		transform.LookAt(new Vector3(0f, transform.position.y, 0f
			));
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 velocity = new Vector3 (
			Input.GetAxis ("Horizontal"),
			0f,
			Input.GetAxis ("Vertical")
		) * speed * Time.fixedDeltaTime;

		rigidbody.velocity = velocity;
		
	}
}
