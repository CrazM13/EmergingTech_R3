using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassInput : MonoBehaviour {

	#region Public Variables
	public float smoothing = 1f;
	#endregion

	#region Private Variables
	private float lastHeading;
	private float lastSmoothedHeading;
	#endregion

	#region Unity Events
	void Start() {

	}

	void Update() {
		lastHeading = Input.compass.trueHeading;

		lastSmoothedHeading = Mathf.Lerp(lastSmoothedHeading, lastHeading, Time.deltaTime * smoothing);

	}
	#endregion

	#region Interface
	public float GetRawHeading() {
		return lastHeading;
	}

	public float GetHeading() {
		return lastSmoothedHeading;
	}
	#endregion

	#region Helper Methods

	#endregion

}
