using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CODE A LA DURE MANAGER
public class RecipeManager : MonoBehaviour {

    Player player;

    //Ces variables servent à définir quels sont les inputs à presser pour lancer les minijeux
    //IL FAUT REMPLIR LES INPUTS ICI
    public string inputLauncherMeat = "";
    public string inputLauncherVegetables = "";
    public string inputLauncherPiment = "";
    public string inputLauncherSauce = "";

    string[] _recipe0 = new string[2];
    string[] _recipe1 = new string[4];
    string[] _recipe2 = new string[3];

    public List<string[]> recipesList = new List<string[]>();

    // la liste des ingrédients utilisées
    public List<string> actualRecipe = new List<string>();

    [HideInInspector] public bool _isRecipeEnd = false;

    [HideInInspector] public int _numFinishedRecipe = -1;

    void Start () {
        InitRecipe0();
        InitRecipe1();
        InitRecipe2();
        InitList();
        player = GetComponent<Player>();
	}
	
    void InitRecipe0() {
        _recipe0[0] = inputLauncherPiment;
        _recipe0[1] = inputLauncherVegetables;
    }

    void InitRecipe1() {
        _recipe1[0] = inputLauncherPiment;
        _recipe1[1] = inputLauncherPiment;
        _recipe1[2] = inputLauncherVegetables;
        _recipe1[3] = inputLauncherMeat;
    }

    void InitRecipe2() {
        _recipe2[0] = inputLauncherSauce;
        _recipe2[1] = inputLauncherMeat;
        _recipe2[2] = inputLauncherVegetables;
    }

    void InitList() {
        recipesList.Add(_recipe0);
        recipesList.Add(_recipe1);
        recipesList.Add(_recipe2);
    }

    public bool CheckIngredient(string pIngredient) {

        // on analyse les possibles listes en fonction des ingredients déjà préparés
        List<int> _possibleList = new List<int>();

        // si il n'y pas pas d'ingrédients dèjà préparé,on ajoute toutes les listes
        if(actualRecipe.Count == 0){
            for(int i = 0; i < recipesList.Count; i++){
                _possibleList.Add(i);
            }
        // sinon, on compare les ingrédients déjà préparé avec ceux des listes de recettes
        }else{
            for(int i = 0; i < recipesList.Count; i++){
                if(checkNextIngredient(0, i)){
                    _possibleList.Add(i);
                }
            }
        }

        foreach(int i in _possibleList){
            Debug.Log("longueur : " + recipesList[i].Length + " : " + actualRecipe.Count);
            if (recipesList[i].Length > actualRecipe.Count && recipesList[i][actualRecipe.Count] == pIngredient) {
                
                if (actualRecipe.Count+1 == recipesList[i].Length) {
                   recipeFinished(i);
                   return true;
                }
                actualRecipe.Add(pIngredient);
                return true;
            }
        }

        Debug.Log("mauvais choix d'aliments");
        //Lancer un waitForSeconds
        player.anim.Play(player.namePlayer+ "|Action_Etourdi");
        return false;
    }

    void recipeFinished(int numRecette){
        _numFinishedRecipe = numRecette;
        _isRecipeEnd = true;
    }

    public void resetRecipe(){
        _numFinishedRecipe = -1;
        _isRecipeEnd = false;
        actualRecipe.Clear();
    }

    private bool checkNextIngredient(int index, int numList){
        if(index >= actualRecipe.Count){
            return true;
        }else{
            if(actualRecipe[index] == recipesList[numList][index]){
                return checkNextIngredient(++index, numList);
            } else {
                return false;
            }
        }
    }

}