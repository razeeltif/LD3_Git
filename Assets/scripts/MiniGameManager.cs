using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dans ce script, on va activer les GameObjects en fonction de l'ingrédient qu'on veut préparer
public class MiniGameManager : MonoBehaviour {

    //Ces variables servent à définir quels sont les inputs à presser pour lancer les minijeux
    public string inputLauncherMeat;
    public string inputLauncherVegetables;
    public string inputLauncherPiment;
    public string inputLauncherSauce;
    //On utilise ces variables pour définir les objets qui vont être concernées par les minijeux
    public GameObject objectActivateVegetable;
    public GameObject objectActivatePiment;
    public GameObject objectActivateMeat;
    public GameObject objectActivateSauce;

    // A l'initialisation, on désactive tous les GameObjects
    void Start () {
        objectActivateVegetable.SetActive(false);
        objectActivatePiment.SetActive(false);
        objectActivateMeat.SetActive(false);
        objectActivateSauce.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //Tant qu'un des GameObject est actif (tant que son minijeu est actif), on ne peux pas lancer un autre minijeu
        //A la fin du minijeu, le GameObject se désactive, permettant d'activer un autre GameObject (et donc un autre minijeu)
        if(objectActivateVegetable.activeSelf == false && objectActivatePiment.activeSelf == false && 
              objectActivateMeat.activeSelf == false && objectActivateSauce.activeSelf == false)
        {
            //Si on appuie sur "inputLauncherMeat", on active le GameObject "objectActivateMeat"
            //Et le GameObject activé permet de lancer son script de jeu
            if (Input.GetKeyDown(inputLauncherMeat))
            {
                objectActivateMeat.SetActive(true);
            }
            //Si on appuie sur "inputLauncherVegetables", on active le GameObject "objectActivateVegetable"
            //Et le GameObject activé permet de lancer son script de jeu
            if (Input.GetKeyDown(inputLauncherVegetables))
            {
                objectActivateVegetable.SetActive(true);
            }
            //Si on appuie sur "inputLauncherPiment", on active le GameObject "objectActivatePiment"
            //Et le GameObject activé permet de lancer son script de jeu
            if (Input.GetKeyDown(inputLauncherPiment))
            {
                objectActivatePiment.SetActive(true);
            }
            //Si on appuie sur "inputLauncherSauce", on active le GameObject "objectActivateSauce"
            //Et le GameObject activé permet de lancer son script de jeu
            if (Input.GetKeyDown(inputLauncherSauce))
            {
                objectActivateSauce.SetActive(true);
            }
        }
    }
}
