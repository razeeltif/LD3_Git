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
    int _step;
    bool _isRecipeEnd;


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

        _step = 0;
        _isRecipeEnd = false;

    }

    // Update is called once per frame
    void Update() {
        //Tant qu'un des GameObject est actif (tant que son minijeu est actif), on ne peux pas lancer un autre minijeu
        //A la fin du minijeu, le GameObject se désactive, permettant d'activer un autre GameObject (et donc un autre minijeu)
        /*if(objectActivateVegetable.activeSelf == false && objectActivatePiment.activeSelf == false && 
              objectActivateMeat.activeSelf == false && objectActivateSauce.activeSelf == false)*/
        if (player.state == LevelManager.STATE.isWaiting) {
            if (!_isRecipeEnd) {
                //Si on appuie sur "inputLauncherMeat", on active le GameObject "objectActivateMeat"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetButtonDown(recipeManager.inputLauncherMeat)) {
                    if (CheckIngredient(recipeManager.inputLauncherMeat)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        viande.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherVegetables", on active le GameObject "objectActivateVegetable"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetButtonDown(recipeManager.inputLauncherVegetables)) {
                    if (CheckIngredient(recipeManager.inputLauncherVegetables)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        vegetable.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherPiment", on active le GameObject "objectActivatePiment"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetButtonDown(recipeManager.inputLauncherPiment)) {
                    if (CheckIngredient(recipeManager.inputLauncherPiment)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        piment.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherSauce", on active le GameObject "objectActivateSauce"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetButtonDown(recipeManager.inputLauncherSauce)) {
                    if (CheckIngredient(recipeManager.inputLauncherSauce)) {
                        player.setStatePlaying();
                        disableAllMiniGame();
                        sauce.enabled = true;
                    }
                }
            }

            else {
                CheckRecipe();
                player.setStateAttacking();
                _step = 0;
                _isRecipeEnd = false;  
            }
        }
    }

    bool CheckIngredient(string pIngredient) {

        for (int i = 0; i < recipeManager.recipesList.Count; i++) {

            if (recipeManager.recipesList[i].Length > _step && recipeManager.recipesList[i][_step] == pIngredient) {
                
                if (_step == recipeManager.recipesList[i].Length) {
                    _isRecipeEnd = true;
                }
                _step++;
                return true;

            }
        }
        Debug.Log("mauvais choix d'aliments");
        //Lancer un waitForSeconds
        return false;
    }

    //CODE A LA DURE \o/
    void CheckRecipe() {
        // grenade
        if (_step == 2) {
            player.Attack(5);
        }
        // assiette
        if (_step == 4) {
            player.Attack(10);
        }
        // soupe
        if (_step == 3) {
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
