using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	[HideInInspector]
	public float damage;
	private static int score = 0;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag != "Bullet") {
			Destroy (gameObject);
		}
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyAI> ().Damage (damage);
		}
		if (other.tag == "Player") {
			other.GetComponent<Mov> ().Damage (damage);
		}
	}

	public static void ScorePlus ()
	{
		score += 10;
	}

	public static int getScore ()
	{
		return score;
	}

	public static void setScore ()
	{
		score = 0;
	}
}
