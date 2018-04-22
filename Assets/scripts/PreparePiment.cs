using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparePiment : MonoBehaviour {

    
    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //Nombre d'inputs qu'on doit presser pour valider le minijeu
    public int nbInput;
    //Le nom de l'input à presser pour ce minijeu (normalement, changera à chaque appui)
    public string inputToEnter;
    //Les Objets qui apparaitront lors du minijeu
    public GameObject ChilliPepperUncut;
    public GameObject ChilliPepperHalfCut;
    public GameObject ChilliPepperCut;

    //Le nombre d'input qu'on a rentré
    private int inputEnter;

    void OnEnable () {
        ChilliPepperUncut.SetActive(true);
        ChilliPepperHalfCut.SetActive(false);
        ChilliPepperCut.SetActive(false);
        message.text = "";
        inputEnter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Quand on entre le bon input, le compteur "inputEnter" augmente de 1
        //Lorsqu'il atteint la valeur de "nbInput", le minijeu est gagné
        if (Input.GetKeyDown(inputToEnter))
        {
            inputEnter++;
            if(inputEnter == (nbInput / 2))
            {
                ChilliPepperUncut.SetActive(false);
                ChilliPepperHalfCut.SetActive(true);
            } 
            if(inputEnter == nbInput)
            {
                //Il faut surement changer cette partie de code
                message.text = "Bravo";
                ChilliPepperHalfCut.SetActive(false);
                ChilliPepperCut.SetActive(true);
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                enabled = false;
                
            }
        }
	}
}
