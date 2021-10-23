using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class endSceneLightController : MonoBehaviour {
	
	public float maxDistanceOn = 1;
	public float lightIntensity = 1;
	
	private Light lightController;
	private Vector2 lampTransform_2d;
	private Transform playerTransform = null;
	
	void Start() {
		this.lightController = GetComponent<Light>();
		this.lightController.enabled = false;
		
		this.lampTransform_2d = new Vector2(transform.position.x, transform.position.z);
	}
	
	void Update() {
		if (this.playerTransform != null) {
			Vector3 playerPos = this.playerTransform.position;
			
			float dist = Math.Min(this.maxDistanceOn, Vector2.Distance(this.lampTransform_2d, new Vector2(playerPos.x, playerPos.z)));
			dist = 1 - (dist / this.maxDistanceOn);
			this.lightController.intensity = GetLightIntensity_dist(dist) * this.lightIntensity;
		}
	}
	
	private float GetLightIntensity_dist(float playerCloseness) {
		return (float) Math.Pow(playerCloseness, 0.3);
	}
	
	private void OnTriggerEnter(Collider colideObj) {
		if (colideObj.gameObject.CompareTag("Player")) {
			this.lightController.enabled = true;
			this.playerTransform = colideObj.gameObject.transform;
		}
	}
	
	private void OnTriggerExit(Collider colideObj) {
		if (colideObj.gameObject.CompareTag("Player")) {
			this.lightController.enabled = false;
			this.playerTransform = null;
		}
	}
}