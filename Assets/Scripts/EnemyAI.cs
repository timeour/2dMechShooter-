using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	public Transform bullet;
	public int bullspeed;
	public float shotOffset;
	public float fireRate;
	private float lastShotTime;
	public float attackDist;
	public float speed;

	public AIState State {
		get {
			return _state;
		}
		set {
			if (_state != value) {
				switch (value) {
				case AIState.Shoot:
					break;	
				case AIState.Follow:
					break;
				case AIState.Search:
					MoveToPoint (GetNewTarget ());
					break;
				}
				_state = value;
			}
		}
	}
	int i1 = 1, j1 = -1;
	private AIState _state;
	private GameObject _target;

	public GameObject Target {
		get {
			if (_target == null) {
				_target = GameObject.FindWithTag ("Player");
			}
			return _target;
		}
	}

	private void Start ()
	{
	}
	
	private void Update ()
	{
		if (CheckingPos ()) {
			State = AIState.Follow;
		} else
			State = AIState.Search;
		int i2, j2;
		
		Room.GetRoomIndexAtPosition (transform.position, out i2, out j2);
		if ((i1 != i2) || (j1 != j2)) {
			i1 = i2;
			j1 = j2;
			MoveToPoint (GetNewTarget ());
		}
		
	}
	
	void FixedUpdate ()
	{
		switch (_state) {
		case AIState.Follow:
			HandleFollow ();
			Shoot ();
			break;
		case AIState.Search:
			HandleSearch ();
			break;
		}
	}
	
	public void MoveToPoint (Vector3 point)
	{
		Vector3 direction = (point - transform.position).normalized;
		rigidbody.velocity = direction * speed;
	}

	void HandleFollow ()
	{
		MoveToPoint (Target.transform.position);
		Vector3 TargetPosition = _target.transform.position;
		float angle = Vector3.Angle (new Vector3 (TargetPosition.x, TargetPosition.y, transform.position.z) - transform.position, Vector3.right);
		if (TargetPosition.y < transform.position.y) {
			transform.rotation = Quaternion.Euler (0f, 0f, -angle);
		} else {
			transform.rotation = Quaternion.Euler (0f, 0f, angle);
		}
	}
	
	void HandleSearch ()
	{
		
	}
	
	void Shoot (){
		
			if (lastShotTime + fireRate < Time.time) {
				Transform BulletInstance = (Transform)Instantiate (bullet, transform.position + (transform.right * shotOffset), transform.rotation);
				BulletInstance.rigidbody.velocity = transform.right * bullspeed;
				lastShotTime = Time.time;
			}
		  
	}
		
	public Vector3 GetNewTarget ()
	{
		Vector3 ret = Vector3.zero;
		
		int i, j;
		
		Room.GetRoomIndexAtPosition (transform.position, out i, out j);
		
		GameObject targetRoom = GameObject.Find ("Room_" + i + "_" + j);
		
		if (targetRoom == null) {
			Debug.LogError ("There is no room at " + i + ":" + j + "!");
		} else {
			Room r = targetRoom.GetComponent<Room> ();
		
			Side s = r.entries [Random.Range (0, r.entries.Length)];
		
			ret = r.GetEntrancePosition (s);
		}
		return ret;
	}

	bool CheckingPos ()
	{
		bool ret = false;
		float distance = Vector3.Distance(transform.position, Target.transform.position);
		
		if (Mathf.RoundToInt (transform.position.x / 500) == Mathf.RoundToInt (Target.transform.position.x / 500)) {
			if (Mathf.RoundToInt (transform.position.y / 500) == Mathf.RoundToInt (Target.transform.position.y / 500)) {
				//if ((distance <= attackDist) ) {
					ret = true;
				//}
			}
		}	
		
		return ret;
	}
}

public enum AIState
{
	Shoot,
	Follow,
	Search
	
}

