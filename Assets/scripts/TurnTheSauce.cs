using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class TurnTheSauce : MonoBehaviour {

    Player player;    
    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //Nombre de fois qu'on doit réaliser la série d'input
    public int nbInput;
    //Le nom des inputs à presser pour ce minijeu
    public string AxisX;
    public string AxisY;
    //Ordre dans lequel il faut tourner la sauce
    public string order;

    // précision de la position du joystick (1 étant l'obligation au joystick de faire le plus grand tour possible)
    [SerializeField] 
    private float accuracy = 0.9f;


    //Les Objets qui apparaissent dans ce minijeu
    //A completer

	// le transform de la louche
	public GameObject louche;

	public GameObject soupiere;

	// permet de poser un coefficient sur la distance que va parcourir la louche
	// à modifier si la louche sort de la soupiere ou qu'elle ne bouge pas assez
	[SerializeField] private float puissance;




    //Le nombre de fois qu'on a rentré l'input
    private int inputEntered;
    //Les booléens indiquant si on a rentré l'input
    private bool input1Entered;
    private bool input2Entered;
    private bool input3Entered;
    private bool input4Entered;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnEnable () {
        //message.text = "";
        inputEntered = 0;
        input1Entered = false;
        input2Entered = false;
        input3Entered = false;
        input4Entered = false;

        louche.SetActive(true);
        soupiere.SetActive(true);

        player.anim.Play(player.namePlayer + "|Action_RemuerSauce");
    }

    void OnDisable()
    {
        louche.SetActive(false);
        soupiere.SetActive(false);

        player.anim.Stop(player.namePlayer + "|Action_RemuerSauce");
    }
	
	// Update is called once per frame
	void Update () {

        /*** PARTIE GRAPHISME ***/
        // récupération de la magnitude du joystick gauche
		Vector2 leftStick = player.manette.getLeftJoystickDirection();

		leftStick *= puissance;

		// on modifie la position de la louche en fonction de l'inclinaison du stick gauche
		louche.transform.localPosition = new Vector3(leftStick.x, louche.transform.localPosition.y, leftStick.y);
        /***                  ***/


        //Je suis parti du principe qu'on fait un tour de cercle en passant par 4 position (le haut, droite, bas, gauche, par exemple)
        //Donc tant qu'on a pas entré l'input précédent, on peut pas continuer (ça peut être amélioré)
        //Dans l'idée, une fois qu'on a fait un tour de joystick, on a notre compteur "inputEntered" qui augmente de 1
        //Quand "inputEntered" est égal à "nbInput", alors c'est gagné
	    if(Input.GetAxis(AxisX) >= accuracy && !input2Entered && !input3Entered && !input4Entered)
        {
            input1Entered = true;
        }
        if (Input.GetAxis(AxisY) >= accuracy && input1Entered && !input3Entered && !input4Entered)
        {
            input2Entered = true;
        }
        if (Input.GetAxis(AxisX) <= -accuracy && input1Entered && input2Entered && !input4Entered)
        {
            input3Entered = true;
        }
        if (Input.GetAxis(AxisY) <= -accuracy && input1Entered && input2Entered && input3Entered)
        {
            inputEntered++;
            input1Entered = false;
            input2Entered = false;
            input3Entered = false;
            input4Entered = false;
            if (inputEntered == nbInput)
            {
                //il faudra surement changer cela
                message.text = "LA SAUCE !";
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                enabled = false;
                player.setStateWaiting();
            }
        }
    }
}