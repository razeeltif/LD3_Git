using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrepareVegetables : MonoBehaviour {

    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //Nombre de fois qu'on doit presser l'input
    public int nbPressInput;
    //Le nom de l'input à presser pour ce minijeu (il est censé changer par je sais pas quelle magie)
    public string inputToEnter;

    //Le nombre de fois qu'on a rentré l'input
    private int inputEntered;

    void Start () {
        inputEntered = 0;
        message.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Si on a appuyé sur la touche demandée, on augmente notre compteur "inputEntered" de 1
        //Si on atteint le "nbPressInput" demandé, alors le mini-jeu est gagné
        if (Input.GetKeyDown(inputToEnter))
        {
            inputEntered ++;
            if (inputEntered == nbPressInput)
            {
                //Faut faire autre chose que le message
                message.text = "Yeah";
            }
        }
	}
}
