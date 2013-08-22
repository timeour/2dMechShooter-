using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	void OnTriggerEnter (Collider other)
	{
		if (other.tag != "Bullet") {
			Debug.Log ("I am collided with a " + other.name);
			Destroy (gameObject);
		}
	}
}
