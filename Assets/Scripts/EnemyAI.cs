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
//					for example play sound "I'm following!"
					break;
				case AIState.Search:
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
		if(CheckingPos ()){
			State = AIState.Follow;
		}
		else
			State = AIState.Search;
	}
	
	void FixedUpdate ()
	{
		switch (_state) {
		case AIState.Follow:
			HandleFollow ();
			break;
		case AIState.Search:
			HandleSearch();
			break;
		}
	}

	void HandleFollow ()
	{
		speed = 100f;
		Vector3 direction = (Target.transform.position - transform.position).normalized;
		rigidbody.velocity = direction * speed;
	}
	
	void HandleSearch() {
		speed = 0f;
		Vector3 direction = (Target.transform.position - transform.position).normalized;
		rigidbody.velocity = direction * speed;
	}

	bool CheckingPos ()
	{
		bool ret = false;
		
		if(Mathf.RoundToInt(transform.position.x / 500) == Mathf.RoundToInt(Target.transform.position.x / 500)) {
			if(Mathf.RoundToInt(transform.position.y / 500) == Mathf.RoundToInt(Target.transform.position.y / 500)) {
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

