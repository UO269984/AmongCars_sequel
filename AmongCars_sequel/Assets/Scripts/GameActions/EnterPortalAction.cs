using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortalAction : GameAction {
	
	public override void Run() {
		SceneManager.LoadScene("EndScene");
	}
}