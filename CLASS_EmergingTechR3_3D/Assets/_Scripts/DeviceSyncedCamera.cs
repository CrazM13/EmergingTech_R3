using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceSyncedCamera : MonoBehaviour {

	public AccelerometerInput accelerometer;
	public GyroscopeInput gyroscope;
	public CompassInput compass;

	public float compassDeadzone = 30f;
	public float accelerometerSensitivity = 1f;
	public Vector3 rotationOffset = Vector3.zero;

	public Text debug;

	void Start() {

	}

	void Update() {
		//transform.localPosition += GetMovement();
		transform.rotation = GetRotation();
	}

	private Vector3 GetMovement() {
		debug.text = $"{accelerometer.GetAcceleration()} ::: ";
		return accelerometer.GetAcceleration() * accelerometerSensitivity * Time.deltaTime;
	}

	private Quaternion GetRotation() {

		return GetDirection();
	}

	private Quaternion GetDirection() {

		Quaternion attitude = gyroscope.GetAttitude();
		Vector3 attitudeEulars = attitude.eulerAngles;
		//attitudeEulars = new Vector3(attitudeEulars.x - 180, (-attitudeEulars.y) + 180, attitudeEulars.z - 180);

		debug.text += $"{attitudeEulars}";

		//float angleToVerticle = Vector3.Angle(attitudeEulars, Vector3.up);

		//if (!(angleToVerticle < compassDeadzone || angleToVerticle > 180 - compassDeadzone)) {
		//	float heading = compass.GetHeading();
		//	attitudeEulars = new Vector3(attitudeEulars.x, heading, attitudeEulars.z);
			//attitude = Quaternion.Euler(attitudeEulars);
		//}

		return attitude;
	}

}
