using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	//level_unlocked_1 etc

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f ){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master Volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if(level <= SceneManager.sceneCountInBuildSettings - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true
		} else {
			Debug.LogError ("Cannot unlock level " + level + ". It is not in the build order");
		}
	}

	public static bool IsLevelUnlocked (int level){
		if(level <= SceneManager.sceneCountInBuildSettings - 1){
			int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
			if(levelValue == 1){
				return true;
			} else {
				return false;
			}
		} else {
			Debug.LogError("Cannot query level " + level + ". It is not in the build order");
			return false;
		}
	}

	public static void SetDifficulty(float difficulty){
		if(difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFF_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty must be between 0 and 1");
		}
	}

	public static float GetDifficulty(){
		float difficulty = PlayerPrefs.GetFloat(DIFF_KEY);
		return difficulty;
	}
}
