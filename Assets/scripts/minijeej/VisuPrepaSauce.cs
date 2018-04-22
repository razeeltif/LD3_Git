using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuPrepaSauce : MonoBehaviour {

	// joueur qui va faire tourner la louche
	public Player player;

	// le transform de la louche
	public Transform louche;

	// permet de poser un coefficient sur la distance que va parcourir la louche
	// à modifier si la louche sort de la soupiere ou qu'elle ne bouge pas assez
	[SerializeField] private float puissance;



	void Start () {
		if(player == null)
			Debug.LogError("joueur non configuré");
		
	}
	
	void Update () {

		// récupération de la magnitude du joystick gauche
		Vector2 leftStick = player.manette.getLeftJoystickDirection();

		leftStick *= puissance;

		// on modifie la position de la louche en fonction de l'inclinaison du stick gauche
		louche.localPosition = new Vector3(leftStick.x, louche.localPosition.y, leftStick.y);

		
	}
}
