using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[Range(0.05f,0.5f)]
	public float factor;

	public void ShiftAroundPaddle (Vector3 paddlePos)
	{
		Vector3 newCameraPos;
		newCameraPos.x = Mathf.Clamp(paddlePos.x*factor,-10.0f,10.0f);
		newCameraPos.y =Mathf.Clamp(paddlePos.y*factor,-10.0f,10.0f);
		newCameraPos.z = this.transform.position.z;
		this.transform.position = newCameraPos;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			factor = Mathf.Clamp(factor+0.05f,0.05f,0.5f);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			factor = Mathf.Clamp(factor-0.05f,0.05f,0.5f);
		}

	}

}
