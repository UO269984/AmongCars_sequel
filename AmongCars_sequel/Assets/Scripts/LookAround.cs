using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {
	
	public float lookSpeed = 1000f;
	
	public Transform playerBody;
	
	float xRotation = 0f;
	
	void Start() {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Cursor.lockState = CursorLockMode.Locked;
		
		switch (Application.platform) {
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.LinuxPlayer:
			case RuntimePlatform.WebGLPlayer:
				if (InputManager.inputType == InputType.Default)
					this.lookSpeed /= 5;
				
				break;
		}
	}
	
	void Update() {
		float mult = this.lookSpeed * Time.deltaTime;
		float rotationY = InputManager.input.GetAxisAction("CameraX") * mult;
		float rotationX = InputManager.input.GetAxisAction("CameraY") * mult;
		
		this.xRotation += rotationX;
		this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);
		
		transform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);
		this.playerBody.Rotate(Vector3.up * rotationY);
	}
}