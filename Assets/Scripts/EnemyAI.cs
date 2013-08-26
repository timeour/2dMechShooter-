using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	public float speed;

	public AIState State {
		get {
			return _state;
		}
		set {
			if (_state != value) {
				switch (value) {
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
		int i, j;
		
		Room.GetRoomIndexAtPosition (transform.position, out i, out j);
	}
	
	void FixedUpdate ()
	{
		switch (_state) {
		case AIState.Follow:
			HandleFollow ();
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
	}
	
	void HandleSearch ()
	{
		
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
		
		if (Mathf.RoundToInt (transform.position.x / 500) == Mathf.RoundToInt (Target.transform.position.x / 500)) {
			if (Mathf.RoundToInt (transform.position.y / 500) == Mathf.RoundToInt (Target.transform.position.y / 500)) {
				ret = true;
			}
		}	
		
		return ret;
	}
}

public enum AIState
{
	
	Follow,
	Search
	
}

