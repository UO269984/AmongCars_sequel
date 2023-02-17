using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
	public double updateTime = 0.1;
	
	private double accumTime = 0;
	private int framesCount = 0;
	
	private TextMesh textComponent;
	
	public void Start() {
		this.textComponent = GetComponent<TextMesh>();
	}
	
	public void Update() {
		this.accumTime += Time.unscaledDeltaTime;
		this.framesCount++;
		
		if (this.accumTime > this.updateTime) {
			this.textComponent.text = "FPS: " + (int) (this.framesCount / this.accumTime);
			this.accumTime = 0;
			this.framesCount = 0;
		}
	}
}