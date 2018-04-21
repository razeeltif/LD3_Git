using UnityEngine.Audio;
using UnityEngine;
using System;

//used for overhall sounds as musics or buttons sounds
//add to AudioManager object
public class StaticAudioManager : AudioManager {

	public static StaticAudioManager instance;

	// Use this for initialization
	void Awake () {

		if(instance == null)
			instance = this;
		else{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		fillSounds();

	}

}
