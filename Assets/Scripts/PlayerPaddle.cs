using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {
	public Camera myCamera;
	private CameraController camController;
	public ScoreKeeper scoreKeeper;
	private float cameraToPaddleDistance;
	// Use this for initialization
	void Start () {
		cameraToPaddleDistance = this.transform.position.z - myCamera.transform.position.z;
		camController = myCamera.GetComponent<CameraController> () as CameraController;
	}
	void OnMouseDrag()
	{
		print ("Mouse drag");
		Vector3 mousePos = GetMouseCoordAtDistance (cameraToPaddleDistance);
		MovePaddleTo (mousePos);
		camController.ShiftAroundPaddle (this.transform.position); 
	}

	void OnCollisionEnter(Collision col)
	{
		scoreKeeper.Add(1);
	}

	Vector3 GetMouseCoordAtDistance(float worldUnitsToCamera)
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector3 screenPos = new Vector3 (mouseX,mouseY,worldUnitsToCamera);
		Vector3 worldPos = myCamera.ScreenToWorldPoint(screenPos);
		return worldPos;
	}

	void MovePaddleTo(Vector3 worldPos)
	{
		Vector3 moveTo = new Vector3(
		Mathf.Clamp (worldPos.x,-7.5f,7.5f),
		Mathf.Clamp (worldPos.y,-7.5f, 7.5f),
		worldPos.z
		);
		this.transform.position = moveTo;
	}
}
