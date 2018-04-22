using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTheSauce : MonoBehaviour {
    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //Nombre de fois qu'on doit réaliser la série d'input
    public int nbInput;
    //Le nom des inputs à presser pour ce minijeu
    public string inputToEnter1;
    public string inputToEnter2;
    public string inputToEnter3;
    public string inputToEnter4;
    //Ordre dans lequel il faut tourner la sauce
    public string order;

    //Le nombre de fois qu'on a rentré l'input
    private int inputEntered;
    //Les booléens indiquant si on a rentré l'input
    private bool input1Entered;
    private bool input2Entered;
    private bool input3Entered;
    private bool input4Entered;

    void OnEnable () {
        message.text = "";
        inputEntered = 0;
        input1Entered = false;
        input2Entered = false;
        input3Entered = false;
        input4Entered = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Je suis parti du principe qu'on fait un tour de cercle en passant par 4 position (le haut, droite, bas, gauche, par exemple)
        //Donc tant qu'on a pas entré l'input précédent, on peut pas continuer (ça peut être amélioré)
        //Dans l'idée, une fois qu'on a fait un tour de joystick, on a notre compteur "inputEntered" qui augmente de 1
        //Quand "inputEntered" est égal à "nbInput", alors c'est gagné
	    if(Input.GetKeyDown(inputToEnter1) && !input2Entered && !input3Entered && !input4Entered)
        {
            input1Entered = true;
        }
        if (Input.GetKeyDown(inputToEnter2) && input1Entered && !input3Entered && !input4Entered)
        {
            input2Entered = true;
        }
        if (Input.GetKeyDown(inputToEnter3) && input1Entered && input2Entered && !input4Entered)
        {
            input3Entered = true;
        }
        if (Input.GetKeyDown(inputToEnter4) && input1Entered && input2Entered && input3Entered)
        {
            inputEntered++;
            input1Entered = false;
            input2Entered = false;
            input3Entered = false;
            input4Entered = false;
            if (inputEntered == nbInput)
            {
                //il faudra surement changer cela
                message.text = "Yeah";
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                gameObject.SetActive(false);
            }
        }
    }
}
