using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
	public ScoreKeeper scoreKeeper;

	void OnTriggerEnter(Collider col)
	{
		gameObject.GetComponent<AudioSource> ().Play ();
		print("Lose");
		Invoke ("NotifyScorekeeper", 1.0f);
	}

	void NotifyScorekeeper()
	{
		scoreKeeper.BallOut ();
	}
}
