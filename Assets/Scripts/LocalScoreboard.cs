using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;

public class LocalScoreboard : MonoBehaviour {
	[System.Serializable]
	private class ScoreboardData{
		public int currentTopScore = 0;
		public SortedList<int,string> topScores = new SortedList<int,string>();
	}
	private string filepath;
	private ScoreboardData myData;

	void Awake()
	{
		filepath = Path.Combine(Application.persistentDataPath,"hyperpong-topscores.dat");
		ReadData ();
	}

	void ReadData()
	{
		IFormatter binFormatter = new BinaryFormatter ();
		try{
			Stream rFile = new FileStream(filepath,FileMode.Open,FileAccess.Read);
			myData = binFormatter.Deserialize(rFile) as ScoreboardData;
			Debug.Log("Reading from filepath '" + filepath + "'");
			rFile.Close();
		}
		catch(IOException exc){
			Debug.Log ("Error writing file");
			Debug.LogException (exc);
			myData = new ScoreboardData ();
		}
		catch(SerializationException exc){
			Debug.Log ("Error serializing data");
			Debug.LogException (exc);
			myData = new ScoreboardData ();
		}
	}

	void WriteData()
	{
		IFormatter binFormatter = new BinaryFormatter ();	
		try{
			Stream wFile = new FileStream(filepath,FileMode.OpenOrCreate,FileAccess.Write);
			binFormatter.Serialize(wFile,myData);
			Debug.Log ("Writing to filepath '" + filepath + "'");
			wFile.Close();
		}
		catch(IOException exc){
			Debug.Log ("Error writing file");
			Debug.LogException (exc);
		}
		catch(SerializationException exc){
			Debug.Log ("Error serializing data");
			Debug.LogException (exc);
			myData = new ScoreboardData ();
		}

	}

	void OnApplicationPause()
	{
		WriteData ();
	}

	void OnDestroy()
	{
		WriteData ();
	}

	public SortedList<int,string> GetScores()
	{
		return myData.topScores;
	}

	public void SetCurrentScore(int score)
	{
		myData.currentTopScore = score;
		Debug.Log ("current: " + score.ToString());
	}

	public bool IsHighScore(int score)
	{
		var topFive = myData.topScores.Reverse().Take(5);
		if (topFive.Any ()) {
			return (score > topFive.Last ().Key);
		} 
		else {
			return true;
		}

	}

	public void ClaimCurrentScore(string name)
	{
		Debug.Log ("Current top score of " + myData.currentTopScore.ToString() + " claimed by " + name);
		myData.topScores.Add (myData.currentTopScore,name);
	}

	public void ClearLocalScores()
	{
		myData.topScores = new SortedList<int, string> ();
		myData.currentTopScore = 0;
		WriteData ();
		Debug.Log ("Local scores cleared");
	}

}