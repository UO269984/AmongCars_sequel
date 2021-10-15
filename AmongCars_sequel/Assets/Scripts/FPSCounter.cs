using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
	
	public int fpsListSize = 100;
	
	private LinkedList<int> fps = new LinkedList<int>();
	private int fpsSum = 0;
	
	void Update() {
		this.fps.AddLast((int) Math.Round(1 / Time.deltaTime));
		this.fpsSum += this.fps.Last.Value;
		
		if (this.fps.Count > fpsListSize) {
			this.fpsSum -= this.fps.First.Value;
			this.fps.RemoveFirst();
		}
		
		GetComponent<TextMesh>().text = "FPS: " + (fpsSum / fps.Count);
	}
}