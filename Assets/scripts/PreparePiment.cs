using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class PreparePiment : MonoBehaviour {

    Player player;
    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    //image de l'input à rentrer
    public Image image;
    //Nombre d'inputs qu'on doit presser pour valider le minijeu
    public int nbInput;
    //Liste des images à afficher pour indiquer au joueur sur quelle touche il faut appuyer
    public Sprite[] imagesButtonToEnter;
    //La liste des noms des inputs à presser pour ce minijeu (normalement, changera à chaque appui)
    // ATTENTION : il faut que la liste imageButtonToEnter et inputsToEnter soient synchronisées (que l'index 0 de l'image corresponde à l'index 0 de la touche)
    public string[] inputsToEnter;
    //L'index du la touche à appuyer / de l'image à afficher
    private int actualIndex;
    //Les Objets qui apparaitront lors du minijeu
    public GameObject ChilliPepperUncut;
    public GameObject ChilliPepperHalfCut;
    public GameObject ChilliPepperCut;

    //Le nombre d'input qu'on a rentré
    private int inputEntered;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnEnable () {

        image.enabled = true;

        // on check si la liste des images et celles des inputs font bien la meme taille ou ne sont pas vides,
        // sinon cela créera un NullPointerException durant le minijeu
        if(imagesButtonToEnter.Length != inputsToEnter.Length || imagesButtonToEnter.Length == 0 || inputsToEnter.Length == 0)
            Debug.LogError("la liste des images et des boutons ne font pas la même taille ou sont vides");

        ChilliPepperUncut.SetActive(true);
        ChilliPepperHalfCut.SetActive(false);
        ChilliPepperCut.SetActive(false);
        message.text = "";
        inputEntered = 0;

        changeIndex();

	}

    void OnDisable()
    {
        ChilliPepperUncut.SetActive(false);
        ChilliPepperHalfCut.SetActive(false);
        ChilliPepperCut.SetActive(false);
        image.enabled=false;   
    }
	
	// Update is called once per frame
	void Update () {
        //Quand on entre le bon input, le compteur "inputEnter" augmente de 1
        //Lorsqu'il atteint la valeur de "nbInput", le minijeu est gagné
        if (Input.GetButtonDown(inputsToEnter[actualIndex]))
        {
            changeIndex();
            inputEntered++;
            if(inputEntered == (nbInput / 2))
            {
                ChilliPepperUncut.SetActive(false);
                ChilliPepperHalfCut.SetActive(true);
            } 
            if(inputEntered == nbInput)
            {
                //Il faut surement changer cette partie de code
                message.text = "PIMENTS !";
                ChilliPepperHalfCut.SetActive(false);
                ChilliPepperCut.SetActive(true);
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                enabled = false;
                image.enabled=false;
                player.setStateWaiting();
                
            }
        }
	}

    private void changeIndex(){
        actualIndex = Random.Range(0, inputsToEnter.Length);
        image.sprite = imagesButtonToEnter[actualIndex];
    }


}
