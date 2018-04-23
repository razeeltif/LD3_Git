using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CODE A LA DURE MANAGER
public class RecipeManager : MonoBehaviour {

    //Ces variables servent à définir quels sont les inputs à presser pour lancer les minijeux
    //IL FAUT REMPLIR LES INPUTS ICI
    public string inputLauncherMeat = "";
    public string inputLauncherVegetables = "";
    public string inputLauncherPiment = "";
    public string inputLauncherSauce = "";

    string[] _recipe1 = new string[2];
    string[] _recipe2 = new string[4];
    string[] _recipe3 = new string[3];

    public List<string[]> recipesList = new List<string[]>();

    void Start () {
        InitRecipe1();
        InitRecipe2();
        InitRecipe3();
        InitList();
	}
	
    void InitRecipe1() {
        _recipe1[0] = inputLauncherPiment;
        _recipe1[1] = inputLauncherVegetables;
    }

    void InitRecipe2() {
        _recipe2[0] = inputLauncherPiment;
        _recipe2[1] = inputLauncherPiment;
        _recipe2[2] = inputLauncherVegetables;
        _recipe2[3] = inputLauncherMeat;
    }

    void InitRecipe3() {
        _recipe3[0] = inputLauncherSauce;
        _recipe3[1] = inputLauncherMeat;
        _recipe3[2] = inputLauncherVegetables;
    }

    void InitList() {
        recipesList.Add(_recipe1);
        recipesList.Add(_recipe2);
        recipesList.Add(_recipe3);
    }

}
