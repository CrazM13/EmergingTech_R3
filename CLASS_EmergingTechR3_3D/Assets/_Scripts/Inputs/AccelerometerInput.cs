using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {

	#region Public Variables
	public float smoothing = 1f;
	public float deadzoneSensitivity = 1f;
	#endregion

	#region Private Variables
	private Vector3 lastRawAcceleration = Vector3.zero;
	private Vector3 lastSmoothedAcceleration = Vector3.zero;
	#endregion

	#region Unity Events
	void Update() {
		if (Input.acceleration.magnitude > deadzoneSensitivity) {
			lastRawAcceleration = Input.acceleration;
		}

		lastSmoothedAcceleration = Vector3.Lerp(lastSmoothedAcceleration, lastRawAcceleration, Time.deltaTime * smoothing);

	}
	#endregion

	#region Interface
	public Vector3 GetAcceleration() {
		return lastSmoothedAcceleration;
	}

	public Vector3 GetRawAcceleration() {
		return lastRawAcceleration;
	}
	#endregion

	#region Helper Methods

	#endregion

}
