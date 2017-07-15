using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	// Use this for initialization

	void OnEnable(){
	//Tell our 'OnSceneLoaded' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
	//Tell our 'OnSceneLoaded' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		AudioClip thisLevelsMusic = levelMusicChangeArray[scene.buildIndex];
		if (thisLevelsMusic){
			audioSource.clip = thisLevelsMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
}
