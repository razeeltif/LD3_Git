using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]


public class PrepareVegetables : MonoBehaviour {

    Player player;
    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //Nombre de fois qu'on doit presser l'input
    public int nbPressInput;
    //Le nom de l'input à presser pour ce minijeu (il est censé changer par je sais pas quelle magie)
    public string inputToEnter;
    //Les GameObjects a faire apparaitre et disparaitre
    public GameObject VegetableUnCut;
    public GameObject VegetableHalfCut;
    public GameObject VegetableCut;


    //Le nombre de fois qu'on a rentré l'input
    private int inputEntered;
    
    void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnEnable()
    {
        VegetableUnCut.SetActive(true);
        VegetableHalfCut.SetActive(false);
        VegetableCut.SetActive(false);
        inputEntered = 0;
        message.text = "";
    }
	
    void OnDisable(){
        VegetableUnCut.SetActive(false);
        VegetableHalfCut.SetActive(false);
        VegetableCut.SetActive(false);        
    }

	// Update is called once per frame
	void Update ()
    {
        //Si on a appuyé sur la touche demandée, on augmente notre compteur "inputEntered" de 1
        //Si on atteint le "nbPressInput" demandé, alors le mini-jeu est gagné
        if (Input.GetButtonDown(inputToEnter))
        {
            inputEntered ++;
            //A la moitié du jeu, on met le légume à moitié coupé
            if (inputEntered == (nbPressInput / 2))
            {
                VegetableUnCut.SetActive(false);
                VegetableHalfCut.SetActive(true);
            }
            if (inputEntered == nbPressInput)
            {
                //Faut faire autre chose que le message
                message.text = "VEGETABLES !";
                VegetableHalfCut.SetActive(false);
                VegetableCut.SetActive(true);
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                enabled = false;
                player.setStateWaiting();
            }
        }
	}
}
