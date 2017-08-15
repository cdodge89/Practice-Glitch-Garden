using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {
	private MusicManager musicManager;

	// Use this for initialization
	void OnEnable(){
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(!musicManager){
			Debug.LogWarning("No MusicManager found");
		}
		musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
