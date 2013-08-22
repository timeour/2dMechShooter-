using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public const float cameraHeight = 1000f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (target.position.x, cameraHeight, target.position.z);
	
	}
}
