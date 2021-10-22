using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorRotate : MonoBehaviour {
	
	public AudioSource doorSound;
	
	public float openedAngle = 210;
	public float rotationSpeed = -1;
	
	private bool reversedRotation;
	private bool isRotating = false;
	
	void Start() {
		this.openedAngle = Math.Abs(this.openedAngle);
		this.reversedRotation = this.rotationSpeed < 0;
	}
	
	void Update() {
		if (this.isRotating) {
			transform.localEulerAngles += new Vector3(0, 0, 1) * this.rotationSpeed * Time.deltaTime;
			
			if (this.reversedRotation == (transform.localRotation.eulerAngles.z < this.openedAngle)) {
				this.isRotating = false;
				this.rotationSpeed = -this.rotationSpeed;
			}
		}
	}
	
	public void ToggleDoor() {
		this.isRotating = true;
		this.doorSound.Play();
	}
}