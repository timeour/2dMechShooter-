using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	private static int scoore = 0;

	// Use this for initialization
	void Start () {
	
		scoore = Bullet.getScore();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (scoore != Bullet.getScore()) {
			Spawn();
			scoore = Bullet.getScore();
		}
		Debug.Log (scoore);
	}
	void Spawn () {
		int i, j, n;
		i = Random.Range (-2, 2);
		j = Random.Range (0, 4);
		n = Random.Range (1, 9);
		GameObject targetEnemy = GameObject.Find ("Enemy_" + n);
		Debug.Log("Enemy_" + n);
		Transform EnemyInstantiate = (Transform)Instantiate (targetEnemy, new Vector3(i*500f, j*500f, -50f), targetEnemy.rigidbody.rotation);
	}
}
