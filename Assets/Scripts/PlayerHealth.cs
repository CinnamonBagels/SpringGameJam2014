using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100.0f;

	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
        cont = this.gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(currentHealth);
	}

	public void dealDamage(float damage) {
		currentHealth -= damage;

		if (currentHealth <= 0.0f) {
			die();
		}
	}

	private void die() {
		Destroy(this.gameObject);
	}
}
