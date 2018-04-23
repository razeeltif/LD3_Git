using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	// instance du gameManager
	private static GameManager instance;

	void Awake()
	{
		if(instance == null)
			instance = this;
	}


	static public GameManager getInstance(){
		return instance;
	}


	public void Death(Player player){
		Debug.Log("Player" + player.playerNumber + " is defeated");
	}
}
