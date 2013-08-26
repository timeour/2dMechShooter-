using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{
	public const float ROOM_SIZE = 500f;
	public Side[] entries;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
	}
	
	public Vector3 GetEntrancePosition (Side side)
	{
		Vector3 ret;
		
		Quaternion rot = Quaternion.Euler (0f, 0f, 90f * (int)side);
		
		ret = rot * new Vector3 (0f, ROOM_SIZE * 0.5f, 0f) + transform.position;
		
		return ret;
	}
	
	public static void GetRoomIndexAtPosition (Vector3 position, out int i, out int j)
	{
		i = Mathf.RoundToInt (position.x / 500f);
		j = Mathf.RoundToInt (position.y / 500f);
	}
}

public enum Side
{
	up = 0,
	right = 1,
	down = 2,
	left = 3
}                           