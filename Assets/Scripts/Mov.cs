using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour
{
	public float speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	void Update ()
	{
		Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));
		Debug.Log(mousePositionInWorld);
		transform.LookAt (new Vector3 (mousePositionInWorld.x, transform.position.y, mousePositionInWorld.z));
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
