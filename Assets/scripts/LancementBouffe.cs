using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LancementBouffe : MonoBehaviour {

	public GameObject tomateFarciePrefab;

	public GameObject assiettePrefab;

	public float thrust;

	public Vector3 positionDeDepart;

	public Vector3 rotationObjet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.B)){
			Debug.Log("yolo");
			GameObject obj = Instantiate(assiettePrefab);
			obj.transform.position = new Vector3(-4.5f, 1, -0.3f);
			obj.transform.rotation = Quaternion.Euler(-25, 90, 0);
		}
	}
}
