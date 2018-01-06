using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DragCamera : NetworkBehaviour {
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = false;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;


	void LateUpdate () {
		if (!isLocalPlayer)
			return;
		
		GameObject camera = GameObject.Find ("Main Camera");

		Vector3 wantedPosition;
		if(followBehind)
			wantedPosition = transform.TransformPoint(0, height, -distance);
		else
			wantedPosition = transform.TransformPoint(0, height, distance);

		camera.transform.position = Vector3.Lerp (camera.transform.position, wantedPosition, Time.deltaTime * damping);

		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation(transform.position - camera.transform.position, transform.up);
			camera.transform.rotation = Quaternion.Slerp (camera.transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else camera.transform.LookAt (transform, transform.up);
	}
}