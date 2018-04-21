using UnityEngine;


[System.Serializable]
public class Sound {

	public string name;

	public AudioClip clip;

	[Range(0.0f, 1.0f)]
	public float volume = 1;

	[Range(-3.0f, 3.0f)]
	public float pitch = 1;

	[Range(0.0f, 1.0f)]
	public float spatialBlend = 0.5f;
	public bool loop;

	[HideInInspector]
	public AudioSource audioSource;



}
