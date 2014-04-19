using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	private float damage = 5.0f;
	private bool isColliding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(isColliding);
	}

	void OnCollisionEnter(Collision col) {
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
	}
}
