using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeInput : MonoBehaviour {

	#region Public Variables
	public float smoothing = 1f;
	public float deadzoneSensitivity = 1f;
	public float updateInterval = 1f;
	#endregion

	#region Private Variables
	private Gyroscope lastGyro = null;
	private Vector3 lastSmoothedAttitude = Vector3.zero;
	#endregion

	#region Unity Events
	void Start() {
		Input.gyro.updateInterval = updateInterval;
	}

	void Update() {

		if (Input.gyro.rotationRate.magnitude < deadzoneSensitivity) {
			lastGyro = Input.gyro;
		}

		lastSmoothedAttitude = Vector3.Lerp(lastSmoothedAttitude, lastGyro.rotationRate, Time.deltaTime * smoothing);
	}
	#endregion

	#region Interface
	public Vector3 GetAttitude() {
		return lastSmoothedAttitude;
	}

	public Vector3 GetRawAttitude() {
		return lastGyro.rotationRate;
	}
	#endregion

	#region Helper Methods

	#endregion

}
