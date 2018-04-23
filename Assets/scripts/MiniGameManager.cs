using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dans ce script, on va activer les GameObjects en fonction de l'ingrédient qu'on veut préparer
public class MiniGameManager : MonoBehaviour {

    public int playerNumber;
    LevelManager.STATE _playerState;
    int _step;
    bool _isRecipeEnd;
    int _chosenRecipe;

    int _damage;

    //Ces variables servent à définir quels sont les inputs à presser pour lancer les minijeux
    /*public string inputLauncherMeat;
    public string inputLauncherVegetables;
    public string inputLauncherPiment;
    public string inputLauncherSauce;*/

    //On utilise ces variables pour définir les objets qui vont être concernées par les minijeux
    public PrepareVegetables pv;
    public PreparePiment pm;
    public TurnTheMeat tm;
    public TurnTheSauce ts;
    //public GameObject objectActivateVegetable;
    //public GameObject objectActivatePiment;
    //public GameObject objectActivateMeat;
    //public GameObject objectActivateSauce;

    // A l'initialisation, on désactive tous les GameObjects
    void Start() {
        pv = GetComponent<PrepareVegetables>();
        pm = GetComponent<PreparePiment>();
        tm = GetComponent<TurnTheMeat>();
        ts = GetComponent<TurnTheSauce>();

        playerNumber = GetComponent<Player>().playerNumber;

        if (playerNumber == 1) _playerState = LevelManager.getInstance().statePlayer1;
        if (playerNumber == 2) _playerState = LevelManager.getInstance().statePlayer2;

        _step = 0;
        _isRecipeEnd = false;
        /*objectActivateVegetable.SetActive(false);
        objectActivatePiment.SetActive(false);
        objectActivateMeat.SetActive(false);
        objectActivateSauce.SetActive(false);*/
    }

    // Update is called once per frame
    void Update() {
        //Tant qu'un des GameObject est actif (tant que son minijeu est actif), on ne peux pas lancer un autre minijeu
        //A la fin du minijeu, le GameObject se désactive, permettant d'activer un autre GameObject (et donc un autre minijeu)
        /*if(objectActivateVegetable.activeSelf == false && objectActivatePiment.activeSelf == false && 
              objectActivateMeat.activeSelf == false && objectActivateSauce.activeSelf == false)*/
        if (_playerState == LevelManager.STATE.isWaiting) {
            if (!_isRecipeEnd) {
                //Si on appuie sur "inputLauncherMeat", on active le GameObject "objectActivateMeat"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetKeyDown(RecipeManager.inputLauncherMeat)) {
                    //objectActivateMeat.SetActive(true);
                    if (CheckIngredient(RecipeManager.inputLauncherMeat)) {
                        LevelManager.getInstance().SetStatePlay(playerNumber);
                        tm.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherVegetables", on active le GameObject "objectActivateVegetable"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetKeyDown(RecipeManager.inputLauncherVegetables)) {
                    //objectActivateVegetable.SetActive(true);
                    if (CheckIngredient(RecipeManager.inputLauncherVegetables)) {
                        LevelManager.getInstance().SetStatePlay(playerNumber);
                        pv.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherPiment", on active le GameObject "objectActivatePiment"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetKeyDown(RecipeManager.inputLauncherPiment)) {
                    //objectActivatePiment.SetActive(true);
                    if (CheckIngredient(RecipeManager.inputLauncherPiment)) {
                        LevelManager.getInstance().SetStatePlay(playerNumber);
                        pm.enabled = true;
                    }
                }
                //Si on appuie sur "inputLauncherSauce", on active le GameObject "objectActivateSauce"
                //Et le GameObject activé permet de lancer son script de jeu
                if (Input.GetKeyDown(RecipeManager.inputLauncherSauce)) {
                    //objectActivateSauce.SetActive(true);
                    if (CheckIngredient(RecipeManager.inputLauncherSauce)) {
                        LevelManager.getInstance().SetStatePlay(playerNumber);
                        ts.enabled = true;
                    }
                }
            }

            else {
                CheckRecipe();
                LevelManager.getInstance().SetStateAttack(playerNumber);
                LevelManager.getInstance().Attack(playerNumber, _damage);

                _step = 0;
                _isRecipeEnd = false;
                LevelManager.getInstance().SetDefense(playerNumber, false);
                _damage = 0;            
            }
        }
    }

    bool CheckIngredient(string pIngredient) {

        for (int i = 0; i < RecipeManager.getInstance().recipesList.Count; i++) {

            if (RecipeManager.getInstance().recipesList[i][_step] == pIngredient) {
                _isRecipeEnd = false;
                _step++;

                if (_step == RecipeManager.getInstance().recipesList[i].Length) {
                    _isRecipeEnd = true;
                }
                return true;
            }

        }
        //Lancer un waitForSeconds
        return false;
    }

    //CODE A LA DURE \o/
    void CheckRecipe() {
        if (_step == 2) {
            _chosenRecipe = 1;
            _damage = 5;
        }
        if (_step == 4) {
            _chosenRecipe = 2;
            _damage = 15;
        }
        if (_step == 3) {
            _chosenRecipe = 3;
            LevelManager.getInstance().SetDefense(playerNumber, true);
        }
    }
}
