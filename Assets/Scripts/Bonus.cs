using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour
{
	public float attackRateBonus;
	public float damageBonus;
	public float medkit;
	public float movementSpeedBonus;
	private Mov _playerMove;
	private int lastBonusScore;
	private bool isToShowBonusDialog;

	public Mov PlayerMove {
		get {
			if (_playerMove == null) {
				_playerMove = GameObject.FindGameObjectWithTag ("Player").GetComponent<Mov> ();
			}
			return _playerMove;
		}
	}
	
	private Shooter _playerShooter;

	public Shooter PlayerShooter {
		get {
			if (_playerShooter == null) {
				_playerShooter = GameObject.FindGameObjectWithTag ("Player").GetComponent<Shooter> ();
			}
			return _playerShooter;
		}
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Bullet.getScore () % 50 == 0 && Bullet.getScore () > lastBonusScore) {
			Time.timeScale = 0f;
			isToShowBonusDialog = true;
			lastBonusScore = Bullet.getScore ();
		}
	}

	void OnGUI ()
	{
		if (isToShowBonusDialog) {
			Rect[] rects = new Rect[4];
			for (int i = 0; i < rects.Length; i++) {
				float buttonWidth = Screen.width / rects.Length;
				rects [i] = new Rect (buttonWidth * i + 20f, 200f, buttonWidth - 40f, 60f); 
			}
				
			if (GUI.Button (rects [0], "Increase damage")) {
				ApplyBonus (BonusType.IncreaseDamage);
			}
			if (GUI.Button (rects [1], "Medkit")) {
				ApplyBonus (BonusType.Medkit);
			}
			if (GUI.Button (rects [2], "Increase Movement Speed")) {
				ApplyBonus (BonusType.MovementSpeed);
			}
			if (GUI.Button (rects [3], "Increase Attack Rate")) {
				ApplyBonus (BonusType.AttackRate);
			}
		}
	}
	
	public void ApplyBonus (BonusType bonusType)
	{
		switch (bonusType) {
		case BonusType.AttackRate:
			PlayerShooter.fireRate *= (1 - attackRateBonus);
			break;
		case BonusType.IncreaseDamage:
			PlayerShooter.damage += damageBonus;
			break;
		case BonusType.Medkit:
			PlayerMove.Restore (medkit);
			break;
		case BonusType.MovementSpeed:
			PlayerMove.speed += movementSpeedBonus;
			break;
		}
		
		isToShowBonusDialog = false;
		Time.timeScale = 1f;
	}
}

public enum BonusType
{
	IncreaseDamage,
	Medkit,
	MovementSpeed,
	AttackRate
}