using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardView : MonoBehaviour {
	public LocalScoreboard localScoreboard;
	public Text scoresText;
	// Use this for initialization
	void Start () {
		SortedList<int,string> scores= localScoreboard.GetScores ();
		string scoreString = "";
		foreach (KeyValuePair<int,string> kvp in scores.Reverse().Take(5)) 
		{
			scoreString += kvp.Value.ToString()+" <"+kvp.Key.ToString()+">\n";
		}
		scoresText.text = scoreString;
	}
}
