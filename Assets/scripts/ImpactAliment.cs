using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ImpactAliment : MonoBehaviour {

	public int damage = 10;

	public float thrust;
	Rigidbody rb;
	public float timeThrust;

	private float actualTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
			if(actualTime < timeThrust){
				rb.AddForce(transform.forward * thrust);
				actualTime += Time.fixedDeltaTime;
			}
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
			Debug.Log("il a pris cher");
			//other.gameObject.GetComponent<Player>().TakeDamage(damage);
			Destroy(this.gameObject);
		}
	}
}
