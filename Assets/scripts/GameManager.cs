using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private Player player1;

	[SerializeField] private Player player2;

	// instance du gameManager
	private static GameManager instance;

	void Awake()
	{
		if(instance == null)
			instance = this;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static public GameManager getInstance(){
		return instance;
	}


	public void Death(Player player){
		Debug.Log("Player" + player.playerNumber + " is dead");
	}
}
