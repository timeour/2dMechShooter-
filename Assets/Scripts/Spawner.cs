using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	private static int scoore = 0;
	public GameObject[] robotPrefab;

	// Use this for initialization
	void Start ()
	{
	
		scoore = Bullet.getScore ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (scoore != Bullet.getScore ()) {
			Spawn ();
			scoore = Bullet.getScore ();
		}
	}

	void Spawn ()
	{
		int i, j, n;
		i = Random.Range (-2, 2);
		j = Random.Range (0, 4);
		n = Random.Range (1, 9);
		Transform newEnemy = (Instantiate (robotPrefab [Random.Range (0, robotPrefab.Length)], new Vector3 (i * 500f, j * 500f, -50f), Quaternion.identity) as GameObject).transform;
	}
}
