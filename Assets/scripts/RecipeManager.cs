using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CODE A LA DURE MANAGER
public class RecipeManager : MonoBehaviour {

    //Ces variables servent à définir quels sont les inputs à presser pour lancer les minijeux
    //IL FAUT REMPLIR LES INPUTS ICI
    public static string inputLauncherMeat = "";
    public static string inputLauncherVegetables = "";
    public static string inputLauncherPiment = "";
    public static string inputLauncherSauce = "";

    string[] _recipe1;
    string[] _recipe2;
    string[] _recipe3;

    public List<string[]> recipesList;

    // instance du levelManager
    private static RecipeManager instance;

    // Use this for initialization
    void Start () {
        recipesList = new List<string[]>();
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
        _recipe1[0] = inputLauncherPiment;
        _recipe1[1] = inputLauncherPiment;
        _recipe1[2] = inputLauncherVegetables;
        _recipe1[3] = inputLauncherMeat;
    }

    void InitRecipe3() {
        _recipe1[0] = inputLauncherSauce;
        _recipe1[1] = inputLauncherMeat;
        _recipe1[2] = inputLauncherVegetables;
    }

    void InitList() {
        recipesList[0] = _recipe1;
        recipesList[1] = _recipe2;
        recipesList[2] = _recipe3;
    }

    static public RecipeManager getInstance() {
        return instance;
    }
}
