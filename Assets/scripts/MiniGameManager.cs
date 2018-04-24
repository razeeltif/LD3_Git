using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dans ce script, on va activer les GameObjects en fonction de l'ingrédient qu'on veut préparer
[RequireComponent(typeof(PreparePiment))]
[RequireComponent(typeof(PrepareVegetables))]
[RequireComponent(typeof(TurnTheMeat))]
[RequireComponent(typeof(TurnTheSauce))]
[RequireComponent(typeof(RecipeManager))]
[RequireComponent(typeof(Player))]
public class MiniGameManager : MonoBehaviour {

    Player player;


    //Ces variables servent à définir quels sont les inputs à presser pour lancer les minijeux
    /*public string inputLauncherMeat;
    public string inputLauncherVegetables;
    public string inputLauncherPiment;
    public string inputLauncherSauce;*/

    //On utilise ces variables pour définir les objets qui vont être concernées par les minijeux
    private PrepareVegetables vegetable;
    private PreparePiment piment;
    private TurnTheMeat viande;
    private TurnTheSauce sauce;
    private RecipeManager recipeManager;
    //public GameObject objectActivateVegetable;
    /*public GameObject objectActivatePiment;
    //public GameObject objectActivateMeat;
    //public GameObject objectActivateSauce;*/
    // A l'initialisation, on désactive tous les GameObjects

    void Start() {
        vegetable = GetComponent<PrepareVegetables>();
        piment = GetComponent<PreparePiment>();
        viande = GetComponent<TurnTheMeat>();
        sauce = GetComponent<TurnTheSauce>();
        
        recipeManager = GetComponent<RecipeManager>();

        player = GetComponent<Player>();

        disableAllMiniGame();


    }

    // Update is called once per frame
    void Update() {
        //Tant qu'un des GameObject est actif (tant que son minijeu est actif), on ne peux pas lancer un autre minijeu
        //A la fin du minijeu, le GameObject se désactive, permettant d'activer un autre GameObject (et donc un autre minijeu)
        /*if(objectActivateVegetable.activeSelf == false && objectActivatePiment.activeSelf == false && 
              objectActivateMeat.activeSelf == false && objectActivateSauce.activeSelf == false)*/
        if (player.state == LevelManager.STATE.isWaiting) {
            if (!recipeManager._isRecipeEnd) {
                //Si on appuie sur "inputLauncherMeat", on active le GameObject "objectActivateMeat"
                //Et le GameObject activé permet de lancer son script de jeu
                if (StartOptions.inMainMenuStatic == false && Pause.isPausedStatic == false && Input.GetButtonDown(recipeManager.inputLauncherMeat)) {
                    if (recipeManager.CheckIngredient(recipeManager.inputLauncherMeat)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        viande.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherVegetables", on active le GameObject "objectActivateVegetable"
                //Et le GameObject activé permet de lancer son script de jeu
                if (StartOptions.inMainMenuStatic == false && Pause.isPausedStatic == false && Input.GetButtonDown(recipeManager.inputLauncherVegetables)) {
                    if (recipeManager.CheckIngredient(recipeManager.inputLauncherVegetables)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        vegetable.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherPiment", on active le GameObject "objectActivatePiment"
                //Et le GameObject activé permet de lancer son script de jeu
                if (StartOptions.inMainMenuStatic == false && Pause.isPausedStatic == false &&Input.GetButtonDown(recipeManager.inputLauncherPiment)) {
                    if (recipeManager.CheckIngredient(recipeManager.inputLauncherPiment)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        piment.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherSauce", on active le GameObject "objectActivateSauce"
                //Et le GameObject activé permet de lancer son script de jeu
                if (StartOptions.inMainMenuStatic == false && Pause.isPausedStatic == false && Input.GetButtonDown(recipeManager.inputLauncherSauce)) {
                    if (recipeManager.CheckIngredient(recipeManager.inputLauncherSauce)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        sauce.enabled = true;
                    }
                }
            } else {
                CheckRecipe();
                player.setStateAttacking();
                recipeManager.resetRecipe();
            }
        }
    }

    //CODE A LA DURE \o/
    void CheckRecipe() {
        // grenade
        if (recipeManager._numFinishedRecipe == 0) {
            player.Attack(5);
        }
        // assiette
        if (recipeManager._numFinishedRecipe == 1) {
            player.Attack(15);
        }
        // soupe
        if (recipeManager._numFinishedRecipe == 2) {
            player.setDefense(true);
        }
    }

    // à appeler à chaque début de minijeu pour enlever l'aliment du précédent jeu
    private void disableAllMiniGame(){
        vegetable.enabled = false;
        piment.enabled = false;
        viande.enabled = false;
        sauce.enabled = false;
    }
}
