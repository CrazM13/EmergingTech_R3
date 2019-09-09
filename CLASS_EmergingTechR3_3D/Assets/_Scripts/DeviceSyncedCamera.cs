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
		//transform.position += GetMovement();
		transform.localRotation = GetRotation();
	}

	private Vector3 GetMovement() {
		return accelerometer.GetAcceleration() * Time.deltaTime;
	}

	private Quaternion GetRotation() {
		return Quaternion.Euler(GetDirection() + rotationOffset);
	}

	private Vector3 GetDirection() {

		Vector3 attitude = gyroscope.GetAttitude();
		Vector3 eulers = transform.rotation.eulerAngles;

		Vector3 newEulers = attitude + eulers;
		float angleToVerticle = Vector3.Angle(newEulers, Vector3.up);

		if (!(angleToVerticle < compassDeadzone || angleToVerticle > 180 - compassDeadzone)) {
			float heading = compass.GetHeading();
			newEulers = new Vector3(newEulers.x, heading, newEulers.z);
		}

		return newEulers;
	}

}
