using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	//level_unlocked_1 etc

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f ){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ('Master Volume out of range');
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
}
