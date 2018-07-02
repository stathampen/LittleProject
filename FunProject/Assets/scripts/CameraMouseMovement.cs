using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour {

    public GameObject mainCamera;
    public float cameraSpeed = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// moves the camera based on where the mouse is pointed
	void Update () {
        yaw += cameraSpeed * Input.GetAxis("Mouse X");
        pitch -= cameraSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	}
}
