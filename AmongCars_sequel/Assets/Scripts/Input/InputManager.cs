using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType {
	Gamepad, Default
}

public class InputManager : MonoBehaviour {
	
	[System.Serializable]
	public struct InputAction {
		public String name;
		public GamepadBt gamepadBt;
		public float dead;
		public bool trigger;
	}
	
	public InputAction[] actions;
	
	public static IInput input;
	public static InputType inputType = InputType.Default;
	
	public void Start() {
		CreateInput();
		
		DeadRangeInput deadRangeInput = new DeadRangeInput(input);
		TriggerInput triggerInput = new TriggerInput(deadRangeInput);
		foreach (InputAction action in this.actions) {
			deadRangeInput.AddDeadAction(action.name, action.dead);
			
			if (action.trigger)
				triggerInput.AddTriggerAction(action.name);
		}
		input = triggerInput;
	}
	
	private void CreateInput() {
		if (GamepadInput.IsActive()) {
			GamepadInput gamepadInput = new GamepadInput();
			input = gamepadInput;
			inputType = InputType.Gamepad;
			
			foreach (InputAction action in this.actions)
				gamepadInput.AddAction(action.name, action.gamepadBt);
		}
		else
			input = new DefaultInput();
	}
}