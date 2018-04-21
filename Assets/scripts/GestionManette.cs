using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script à accrocher au joueur.


public class GestionManette : MonoBehaviour {

	// le numero du joueur
	public int playerNumber;

	[SerializeField] private bool debug = false;

	void Awake(){
		if(debug){
			string[] names = Input.GetJoystickNames();
			Debug.Log ("Connected Joysticks ");
			for (int i = 0; i < names.Length; i++) {
				Debug.Log("Joystick" + (i+1) + " = " + names[i]);
			}
		}
	}

	void Update () {
		if(debug)
			DebugJoystickButtonPressed();
	}


	/// <summary>
	/// affiche les inputs
	/// </summary>
	void DebugJoystickButtonPressed(){

		if(Input.GetButtonDown("JoyA" + playerNumber))
			Debug.Log("JoyA" + playerNumber);

		if(Input.GetButtonDown("JoyB" + playerNumber))
			Debug.Log("JoyB" + playerNumber);

		if(Input.GetButtonDown("JoyX" + playerNumber))
			Debug.Log("JoyX" + playerNumber);

		if(Input.GetButtonDown("JoyY" + playerNumber))
			Debug.Log("JoyY" + playerNumber);

		if(Input.GetButtonDown("JoyLT" + playerNumber))
			Debug.Log("JoyLT" + playerNumber);

		if(Input.GetButtonDown("JoyRT" + playerNumber))
			Debug.Log("JoyRT" + playerNumber);
	
		if(Input.GetButtonDown("JoyLB" + playerNumber))
			Debug.Log("JoyLB" + playerNumber);

		if(Input.GetButtonDown("JoyRB" + playerNumber))
			Debug.Log("JoyRB" + playerNumber);

		if(Input.GetButtonDown("JoyBack" + playerNumber))
			Debug.Log("JoyBack" + playerNumber);

		if(Input.GetButtonDown("JoyStart" + playerNumber))
			Debug.Log("JoyStart" + playerNumber);

		if(Input.GetButtonDown("JoyRightStick" + playerNumber))
			Debug.Log("JoyRightStick" + playerNumber);

		if(Input.GetButtonDown("JoyLeftStick" + playerNumber))
			Debug.Log("JoyLeftStick" + playerNumber);


		Vector2 vec1 = getLeftJoystickDirection();
		if(vec1.x != 0 || vec1.y != 0)
			Debug.Log("joystick"  + playerNumber + " gauche : " + vec1.x + ", " + vec1.y);

		Vector2 vec2 = getRightJoystickDirection();
		if(vec2.x != 0 || vec2.y != 0)
			Debug.Log("joystick"  + playerNumber + " droit : " + vec2.x + ", " + vec2.y);

		if(getLeftTrigger() !=0)
			Debug.Log("JoyLT" + playerNumber + " : " + getLeftTrigger());

		if(getRightTrigger() !=0)
			Debug.Log("JoyRT" + playerNumber + " : " + getRightTrigger());
		


	}

	/// <summary>
	/// récupérer la direction du joystick gauche
	/// </summary>
	/// <returns></returns>
	Vector2 getLeftJoystickDirection(){
		return new Vector2 (Input.GetAxis ("JoyLeftJoyX" + playerNumber), Input.GetAxis ("JoyLeftJoyY" + playerNumber));
	}

	/// <summary>
	/// récupérer la direction du joystick droit
	/// </summary>
	/// <returns></returns>
	Vector2 getRightJoystickDirection(){
		return new Vector2 (Input.GetAxis ("JoyRightJoyX" + playerNumber), Input.GetAxis ("JoyRightJoyY" + playerNumber));
	}

	/// <summary>
	/// récupérer la puissance mise dans le trigger gauche
	/// </summary>
	/// <returns> float entre 0 (au repos) et 1 (enfoncé au max) </returns>
	float getLeftTrigger(){
		return Input.GetAxis ("JoyLT" + playerNumber);
	}

	/// <summary>
	/// récupérer la puissance mise dans le trigger droit 
	/// </summary>
	/// <returns> float entre 0 (au repos) et 1 (enfoncé au max) </returns>
	float getRightTrigger(){
		return Input.GetAxis ("JoyRT" + playerNumber);
	}
}
