using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRenderingPath : MonoBehaviour {
	
	private Camera cameraComponent;
	private bool isDefered;
	
	void Start() {
		this.cameraComponent = GetComponent<Camera>();
		this.isDefered = this.cameraComponent.renderingPath == RenderingPath.DeferredShading;
	}
	
	void Update() {
		if (Input.GetButtonDown("ToggleLighting")) {
			this.isDefered = ! this.isDefered;
			this.cameraComponent.renderingPath = this.isDefered ? RenderingPath.DeferredShading : RenderingPath.Forward;
		}
	}
}