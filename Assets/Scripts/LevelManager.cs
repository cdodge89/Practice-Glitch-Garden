using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start (){
		if (autoLoadNextLevelAfter > 0){
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		} else if (autoLoadNextLevelAfter < 0) {
			Debug.LogError("Cannot have negative seconds to auto load next level. Set to 0 to turn off autoload, or set to greater than 0");
		}
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
