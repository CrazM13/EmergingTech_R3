using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeInput : MonoBehaviour {

	#region Public Variables
	public float smoothing = 1f;
	public float updateInterval = 1f;
	#endregion

	#region Private Variables
	private Gyroscope lastGyro = null;
	private Quaternion lastSmoothedAttitude = Quaternion.identity;
	#endregion

	#region Unity Events
	void Start() {
		Input.gyro.updateInterval = updateInterval;
		Input.gyro.enabled = true;
	}

	void Update() {
		lastGyro = Input.gyro;

		lastSmoothedAttitude = Quaternion.Lerp(lastSmoothedAttitude, lastGyro.attitude, Mathf.Clamp01(Time.deltaTime * smoothing));
	}
	#endregion

	#region Interface
	public Quaternion GetAttitude() {
		return GyroToUnity(lastSmoothedAttitude);
	}

	public Quaternion GetRawAttitude() {
		return lastGyro != null ? GyroToUnity(lastGyro.attitude) : Quaternion.identity;
	}
	#endregion

	#region Helper Methods
	private Quaternion GyroToUnity(Quaternion q) {
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}
	#endregion

}
