using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	public float damage;
	public Transform bullet;
	public int speed;
	public float shotOffset;
	public AudioClip fire;
	public float fireRate;
	private float lastShotTime;
	

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			if (lastShotTime + fireRate < Time.time) {
				Fire ();
				lastShotTime = Time.time;
			}
		}
	}
	
	public void Fire ()
	{
		audio.Play ();
		Transform bulletInstance = (Transform)Instantiate (bullet, transform.position + (transform.right * shotOffset), transform.rotation);
		bulletInstance.rigidbody.AddForce (transform.right * speed);
		bulletInstance.GetComponent<Bullet> ().damage = damage;
	}
}
