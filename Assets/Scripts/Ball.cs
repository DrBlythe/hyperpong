using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 Vo;
	[Range(1.0f,1.1f)]
	public float speedMultiplier = 1.05f;

	void Start () {
		gameObject.GetComponent<Rigidbody> ().velocity = Vo;
	}

	void OnCollisionEnter(Collision col)
	{
		gameObject.GetComponent<AudioSource> ().Play ();
		Vector3 funkyBounce = new Vector3 (
			Random.Range (-7f, 7f),
			Random.Range (-7f, 7f),	
			this.GetComponent<Rigidbody> ().velocity.z * speedMultiplier
		);
		this.GetComponent<Rigidbody> ().velocity = funkyBounce;
	}
		
}
