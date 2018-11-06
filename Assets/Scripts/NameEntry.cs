using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameEntry : MonoBehaviour {
	public LocalScoreboard localScoreboard;
	public InputField inputField;
	public Button saveButton;
	private LevelManager levelManager;

	void Start()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		saveButton.onClick.AddListener (OnSubmitName);
		//inputField.onEndEdit.AddListener(OnSubmitNameValue);
	}

	void OnSubmitName()
	{
		localScoreboard.ClaimCurrentScore (inputField.text);
		Invoke ("LoadScoreTable" ,1.0f);
	}

	void LoadScoreTable()
	{
		levelManager.LoadLevel ("ScoreTable");
	}
}
