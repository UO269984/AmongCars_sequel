using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GazeInput : MonoBehaviour {
	
	public GameAction clicAction;
	
	//TIMER
	private bool isLooked = false;
	public float timerDuration = 3f;
	private float lookTimer = 0f;
	
	void Start() {}
	
	void Update() {
		if (this.isLooked) {
			this.lookTimer += Time.deltaTime;
			
			if (this.lookTimer > this.timerDuration) {
				this.lookTimer = 0f;
				Debug.Log("Object timer click");
				OnPointerClick();
			}
		}
		else
			this.lookTimer = 0f;
	}
	
	public void setIsLooked(bool looked) {
		this.isLooked = looked;
	}
	
	public void OnPointerClick() {
		this.clicAction.Run();
	}
}