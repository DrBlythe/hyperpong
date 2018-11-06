using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPaddle : MonoBehaviour {
	private Ball ball;

	void Start()
	{
		ball = FindObjectOfType<Ball> () as Ball;
	}

	void Update()
	{
		Vector3 paddlePos = new Vector3(
			Mathf.Clamp(ball.transform.position.x, -7.5f, 7.5f),
			Mathf.Clamp(ball.transform.position.y, -7.5f, 7.5f),
			this.transform.position.z
		);
		this.transform.position = paddlePos;
	}
}
