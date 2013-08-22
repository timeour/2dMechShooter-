using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	
	public Transform bullet;
	public int speed;
	public float shotOffset;
	

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Transform BulletInstance = (Transform)Instantiate (bullet, transform.position + (transform.rotation * Vector3.forward * shotOffset), transform.rotation);
			BulletInstance.rigidbody.AddForce (transform.forward * speed);
		}
	}
}
