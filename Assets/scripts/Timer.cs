﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer {

	public float time;
	public bool finished = true;
	public bool hasBeenLaunched = false;
	private bool debug = false;
	private float cooldown = 0;
	private Coroutine instanceCoroutine;
	private MonoBehaviour mono;
	private float timerPrecision = 0.1f;

	private Timer(float time, MonoBehaviour obj, bool debug){
		this.time = time;
		this.debug = debug;
		this.mono = obj;
	}

	//timer : the time took by the timer to switch <finished> to true
	//obj : need a monobehaviour reference to lanch the StartCoroutine function, almost every time 'this' (i know, a little ugly)
	//debug : if you want to see the timer developpement
	public static Timer Initialize(float time, MonoBehaviour obj, bool debug = false){
		Timer returnVal = new Timer(time, obj, debug);
		return returnVal;
	}

	public void Stop (bool deb = false){
		this.debug = deb;
		mono.StopCoroutine(instanceCoroutine);
		finished = false;
		hasBeenLaunched = false;
		cooldown = 0;
		if(debug)
			Debug.Log("coroutine " + instanceCoroutine.ToString() + " stopped.");
	}

	public void start(bool deb = false){
		this.debug = deb;
		if(instanceCoroutine != null) mono.StopCoroutine(instanceCoroutine);
		cooldown = 0;
		finished = false;
		hasBeenLaunched = true;
		if(debug)
			Debug.Log("Restarting");
		instanceCoroutine = mono.StartCoroutine(LaunchCooldown());
	}

	public void start(float time, bool deb = false){
		this.debug = deb;
		if(instanceCoroutine != null) mono.StopCoroutine(instanceCoroutine);
		cooldown = 0;
		finished = false;
		this.time = time;
		if(debug)
			Debug.Log("Restarting");
		instanceCoroutine = mono.StartCoroutine(LaunchCooldown());
	}

	public void restart(){
		Stop();
		start();
	}

	public void restart(float time){
		Stop();
		start(time);
	}

	private IEnumerator LaunchCooldown(){
		while (cooldown < time){
			if(debug)
				Debug.Log("Countdown: " + cooldown);
			yield return new WaitForSecondsRealtime(timerPrecision);
			cooldown += timerPrecision;
		}
		finished = true;
	} 

}
