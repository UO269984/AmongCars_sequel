using System;
using System.Collections.Generic;

public class DeadRangeInput : IInput {
	private IInput input;
	private IDictionary<String, float> deadsConfig = new Dictionary<String, float>();
	
	public DeadRangeInput(IInput input) {
		this.input = input;
	}
	
	public void AddDeadAction(String actionName, float dead) {
		this.deadsConfig[actionName] = dead;
	}
	
	public bool GetButtonAction(String actionName) {
		return this.input.GetButtonAction(actionName);
	}
	
	public float GetAxisAction(String actionName) {
		float val = this.input.GetAxisAction(actionName);
		return Math.Abs(val) > this.deadsConfig[actionName] ? val : 0;
	}
}