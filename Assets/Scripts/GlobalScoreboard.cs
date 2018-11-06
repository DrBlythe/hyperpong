using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Parse;
using System.Linq;

public class GlobalScoreboard : MonoBehaviour {
	/*
	static int currentTopScore = 0; 
	private SortedList<int,string> topScores = new SortedList<int,string>();

	void Awake()
	{
		var query = ParseObject.GetQuery ("GameScore")
			.WhereExists ("playerName")
			.WhereExists("score")
			.OrderByDescending("score")
			.Limit(5);
		var task = query.FindAsync ();
		task.ContinueWith ( (t) => {
			foreach (ParseObject gameScore in t.Result)
			{
				Debug.Log(gameScore.Get<string>("playerName") + " - " + gameScore.Get<int>("score"));
			}
		});

		ParseQuery<ParseObject> query = ParseObject.GetQuery("GameScore")
			.WhereExists ("playerName")
			.WhereExists("score")
			.OrderByDescending("score")
			.Limit(5);
		query.GetAsync("hyperpongdiddlyong").ContinueWith(t =>
			{
				//ParseObject gameScore = t.Result;
				topScores.Clear(); 
				foreach(ParseObject gameScore in t.Result)
				{
					topScores.Add(gameScore.Get<int>("score"), gameScore.Get<string>("playerName"));
				}
			});
	}

	public void SetCurrentScore(int score)
	{
		currentTopScore = score;
	}

	public bool IsHighScore(int score)
	{
		var topFive = topScores.Reverse().Take(5);
		if (topFive.Any ()) {
			return (score > topFive.Last ().Key);
		} 
		else {
			return true;
		}

	}

	public void ClaimCurrentScore(string name)
	{
		ParseObject gameScore = new ParseObject ("GameScore");
		gameScore ["score"] = currentTopScore;
		gameScore ["playerName"] = name;
		Task saveTask = gameScore.SaveAsync ();
		Debug.Log ("Current top score of " + currentTopScore.ToString() + " claimed by " + name);

	}

	public SortedList<int,string> GetScores()
	{
		return topScores;
	}
*/
}
