using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	
	public Transform bullet;
	public int speed;
	public float shotOffset;
	public AudioClip fon;
	public AudioClip fire;
	

	// Use this for initialization
	void Start ()
	{
		audio.PlayOneShot(fon);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonDown (0)) {
			audio.PlayOneShot(fire);
			Transform BulletInstance = (Transform)Instantiate (bullet, transform.position + (transform.right * shotOffset), transform.rotation);
			BulletInstance.rigidbody.AddForce (transform.right * speed);
		}
	}
}
