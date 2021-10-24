using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndAction : GameAction {
	
	public AudioSource playerAudio;
	public AudioClip respawnClip;
	
	public override void Run() {
		StartCoroutine(loadJailScene());
	}
	
	private IEnumerator loadJailScene() {
		this.playerAudio.clip = this.respawnClip;
		this.playerAudio.Play();
		
		yield return new WaitForSeconds(this.respawnClip.length);
		SceneManager.LoadScene("JailScene");
	}
}