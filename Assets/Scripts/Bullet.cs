﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	void OnTriggerEnter (Collider other)
	{
		if (other.tag != "Bullet") {
			Destroy (gameObject);
		}
	}
}