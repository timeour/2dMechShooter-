using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int damage;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag != "Bullet") {
			Destroy (gameObject);
		}
		if (other.tag == "Enemy")
		{
			other.GetComponent<EnemyAI> ().Damage (damage);
		}
		if (other.tag == "Player"){
			other.GetComponent<Mov> ().Damage(damage);
		}
	}
}
