using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LancementBouffe : MonoBehaviour {

	public GameObject tomateFarciePrefab;

	public GameObject assiettePrefab;

	public float thrust;

	public Vector3 positionDeDepart2;

	public Vector3 rotationObjet2;

	public Vector3 positionDeDepart1;

	public Vector3 rotationObjet1;

	public static LancementBouffe instance;

	public /// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		if(instance == null)
		instance = this;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			GameObject obj = Instantiate(tomateFarciePrefab);
			obj.transform.position = positionDeDepart1;
			obj.transform.rotation = Quaternion.Euler(rotationObjet1);
		}

		if(Input.GetKeyDown(KeyCode.Z)){
			GameObject obj = Instantiate(tomateFarciePrefab);
			obj.transform.position = positionDeDepart2;
			obj.transform.rotation = Quaternion.Euler(rotationObjet2);
		}
	}

	public void  lancerAssiette(int playerNumber){
		if(playerNumber == 1){
			GameObject obj = Instantiate(assiettePrefab);
			obj.transform.position = positionDeDepart1;
			obj.transform.rotation = Quaternion.Euler(rotationObjet1);			
		}else if(playerNumber == 2){
			GameObject obj = Instantiate(assiettePrefab);
			obj.transform.position = positionDeDepart2;
			obj.transform.rotation = Quaternion.Euler(rotationObjet2);			
		}else{
			Debug.LogError("ERREUR : le numero du joueur n'est pas valide");
		}
	}

	public void  lancerGrenade(int playerNumber){
		if(playerNumber == 1){
			GameObject obj = Instantiate(tomateFarciePrefab);
			obj.transform.position = positionDeDepart1;
			obj.transform.rotation = Quaternion.Euler(rotationObjet1);			
		}else if(playerNumber == 2){
			GameObject obj = Instantiate(tomateFarciePrefab);
			obj.transform.position = positionDeDepart2;
			obj.transform.rotation = Quaternion.Euler(rotationObjet2);			
		}else{
			Debug.LogError("ERREUR : le numero du joueur n'est pas valide");
		}
	}

	public static LancementBouffe getInstance(){
		return instance;
	}

}
