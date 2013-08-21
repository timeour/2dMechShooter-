using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 velocity = new Vector3 (
			Input.GetAxis ("Horizontal"),
			0f,
			Input.GetAxis ("Vertical")
		) * speed * Time.fixedDeltaTime;
		Debug.Log(velocity);
		rigidbody.velocity = velocity;
		
	}
}
