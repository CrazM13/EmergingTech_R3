using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceSyncedCamera : MonoBehaviour {

	public AccelerometerInput accelerometer;
	public GyroscopeInput gyroscope;
	public CompassInput compass;

	public float compassDeadzone = 30f;
	public float accelerometerSensitivity = 1f;
	public Vector3 rotationOffset = Vector3.zero;

	void Start() {

	}

	void Update() {
		transform.position += GetMovement();
		transform.localRotation = GetRotation();
	}

	private Vector3 GetMovement() {
		return Vector3.zero;
	}

	private Quaternion GetRotation() {
		return Quaternion.identity;
	}

	private Vector3 GetDirection() {
		return Vector3.zero;
	}

}
