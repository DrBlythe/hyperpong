using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private int score = 0;
	public Text scoreText;
	public LevelManager levelManager;
	public LocalScoreboard localScoreboard;
	public bool rotationStart;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		scoreText.text = score.ToString ();
		rotationStart = false;
	}

	public void Add(int amount){
		score += amount;
		scoreText.text = score.ToString ();
		if (score >= 6) {
			rotationStart = true;
		}
	}
	public int GetScore(){return score;}

	public void BallOut()
	{
		
		if (localScoreboard.IsHighScore (score)) {
			localScoreboard.SetCurrentScore (score);
			levelManager.LoadLevel ("EnterName");
		} else {
			levelManager.LoadLevel ("Lose");
		}
	}

}
