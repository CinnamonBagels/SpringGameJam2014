using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	private float damage = 5.0f;

<<<<<<< HEAD
	public float getDamage() {
		return damage;
=======
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(isColliding);
	}

	void OnCollisionEnter(Collision col) {
        Debug.Log("Collision entered");
		isColliding = true;
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.name == "Player") {
			var pHealth = col.gameObject.GetComponent<PlayerHealth>();
			pHealth.dealDamage(damage);
		}
	}

	void OnCollisionExit(Collision col) {
		isColliding = false;
>>>>>>> 5bf12e1f719b3e4cc599070a1d5d9702aa7e0907
	}
}
