using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (GestionManette))]
public class Player : MonoBehaviour {

	// numéro du joueur (1 ou 2)
	public int playerNumber;

	public int pv;

	public GestionManette manette;

	void Awake()
	{
		manette = GetComponent<GestionManette>();
	}

	// Use this for initialization
	void Start () {
		manette.playerNumber = playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// fonction appelé à chaque fois que le joueur subit des dégats
	/// </summary>
	/// <param name="damage"></param>
	void takeDamage(int damage){
		pv -= damage;
		if(pv <= 0){
			GameManager.getInstance().Death(this);
		}
	}
}
