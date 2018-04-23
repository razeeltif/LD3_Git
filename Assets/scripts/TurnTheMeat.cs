using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class TurnTheMeat : MonoBehaviour {

    
    Player player;

    //Message de victoire du minijeu (à retirer ?)
    public Text message;
    public Image image;
    //Nombre de fois qu'on doit presser la combinaison l'input
    public int nbInput;
    //Le nom du 1er input à presser
    public string inputToEnter1;
    //Le nom du 2e input à presser
    public string inputToEnter2;
    //Les Objets qui apparaitront dans le jeu
    public GameObject RawMeat;
    public GameObject CookedMeat;
    //Les sprites des boutons
    public Sprite ImageButtonToEnterRB;
    public Sprite ImageButtonToEnterLB;
    //image de l'input à rentrer
    public float minSize;
    public float maxSize;
    public float animationSpeed;


    //Le nombre de combinaison d'input qu'on a rentré
    private int inputEnter;
    //Indique si on a pressé ou non "inputEnter1"
    private bool input1Entered;
    //Indique si on a pressé ou non "inputEnter2"
    private bool input2Entered;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnEnable () {
        image.enabled = true;
        RawMeat.SetActive(true);
        CookedMeat.SetActive(false);
        message.text = "";
        inputEnter = 0;
        input1Entered = false;
        input2Entered = false;
        player.anim.wrapMode = WrapMode.Loop;
        player.anim.Play(player.namePlayer + "|Action_CuireViande");
    }

    void OnDisable()
    {
        image.enabled = false;
        RawMeat.SetActive(false);
        CookedMeat.SetActive(false);
        player.anim.wrapMode = WrapMode.Once;
        player.anim.Stop(player.namePlayer + "|Action_CuireViande");
    }
	
	// Update is called once per frame
	void Update () {
        //Si on presse "inputToEnter1" et que "inputToEnter2" n'est pas déjà pressé, on passe "input1Entered" à true
        if (image.rectTransform.sizeDelta.x < maxSize)
        {
            image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x + Time.deltaTime * animationSpeed, image.rectTransform.sizeDelta.y + Time.deltaTime * animationSpeed);
        }
        if (Input.GetButtonDown(inputToEnter1) && !input2Entered)
        {
            animationImage();
            image.sprite = ImageButtonToEnterRB;
            input1Entered = true;
            //Là, faut mettre le son de retournement de steak
        }

        //Si on presse "inputToEnter2" et que "inputToEnter1" n'est pas déjà pressé, on passe "input1Entered" à true
        if (Input.GetButtonDown(inputToEnter2) && !input1Entered)
        {
            animationImage();
            image.sprite = ImageButtonToEnterLB;
            input2Entered = true;
            //Là, faut mettre le son de retournement de steak
        }

        //Si on presse "inputToEnter1" et que "inputToEnter2" à déjà été pressé, on incrémente "inputEnter" de 1
        //et on repasse "input1Entered" et "input2Entered" à false
        //si "inputEnter" est égal à "nbInput", le minijeu est gagné 
        if ((Input.GetButtonDown(inputToEnter1) && input2Entered) || (Input.GetButtonDown(inputToEnter2) && input1Entered))
        {
            animationImage();
            image.sprite = ImageButtonToEnterLB;
            inputEnter++;
            input1Entered = false;
            input2Entered = false;
            if (inputEnter == nbInput)
            {
                //il faudra surement changer cela
                message.text = "LA VIANDE !";
                RawMeat.SetActive(false);
                CookedMeat.SetActive(true);
                //Pour fonctionner avec le script LaunchMiniGame, on désactive le gameObject une fois le minijeu terminé
                enabled = false;
                image.enabled = false;
                player.setStateWaiting();
            }
        }
    }
    private void animationImage()
    {
        image.rectTransform.sizeDelta = new Vector2(minSize, minSize);
    }
}
