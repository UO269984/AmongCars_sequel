using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {
	public AudioSource audioSource;
	
	private void OnTriggerEnter(Collider colideObj) {
		if (colideObj.gameObject.CompareTag("Player"))
			this.audioSource.Play();
	}
	
	private void OnTriggerExit(Collider colideObj) {
		if (colideObj.gameObject.CompareTag("Player"))
			this.audioSource.Stop();
	}
}