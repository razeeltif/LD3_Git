using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject EndScreen;
    public Text textEnd;

	// instance du gameManager
	private static GameManager instance;

	void Awake()
	{
		if(instance == null)
			instance = this;
	}

    private void Update() {
        if (Input.GetKeyDown(KeyCode.H)) ReloadScene();
    }
    static public GameManager getInstance(){
		return instance;
	}


	public void Death(Player player){
        EndScreen.SetActive(true);
        textEnd.text = "Player" + player.playerNumber + " is defeated";

        Invoke("ReloadScene", 1f);
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
