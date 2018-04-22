using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTheMeat : MonoBehaviour {

    
    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //Nombre de fois qu'on doit presser la combinaison l'input
    public int nbInput;
    //Le nom du 1er input à presser
    public string inputToEnter1;
    //Le nom du 2e input à presser
    public string inputToEnter2;

    //Le nombre de combinaison d'input qu'on a rentré
    private int inputEnter;
    //Indique si on a pressé ou non "inputEnter1"
    private bool input1Entered;
    //Indique si on a pressé ou non "inputEnter2"
    private bool input2Entered;

    void OnEnable () {
        message.text = "";
        inputEnter = 0;
        input1Entered = false;
        input2Entered = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Si on presse "inputToEnter1" et que "inputToEnter2" n'est pas déjà pressé, on passe "input1Entered" à true
        if (Input.GetKeyDown(inputToEnter1) && !input2Entered)
        {
            input1Entered = true;
        }

        //Si on presse "inputToEnter2" et que "inputToEnter1" n'est pas déjà pressé, on passe "input1Entered" à true
        if (Input.GetKeyDown(inputToEnter2) && !input1Entered)
        {
            input2Entered = true;
        }

        //Si on presse "inputToEnter1" et que "inputToEnter2" à déjà été pressé, on incrémente "inputEnter" de 1
        //et on repasse "input1Entered" et "input2Entered" à false
        //si "inputEnter" est égal à "nbInput", le minijeu est gagné 
        if ((Input.GetKeyDown(inputToEnter1) && input2Entered) || (Input.GetKeyDown(inputToEnter2) && input1Entered))
        {
            inputEnter++;
            input1Entered = false;
            input2Entered = false;
            if (inputEnter == nbInput)
            {
                //il faudra surement changer cela
                message.text = "Félicitation";
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                gameObject.SetActive(false);
            }
        }
    }
}
