using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100.0f;
	public float damageCD = 1.0f;

	private float currentDamageCD;
	private float currentHealth;
	private bool canTakeDamage;

	// Use this for initialization
	void Start () {
		currentDamageCD = damageCD;
		canTakeDamage = true;
		currentHealth = maxHealth;
        cont = this.gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(currentHealth);
		currentDamageCD -= Time.deltaTime;

		if (currentDamageCD <= 0) {
			canTakeDamage = true;
			currentDamageCD = damageCD;
		}
	}

	public void receiveDamage(float damage) {
		if (canTakeDamage) {
			currentHealth -= damage;

			canTakeDamage = false;

			if (currentHealth <= 0.0f) {
				die();
			}
		}
	}

	public void heal(float healAmount) {
		currentHealth += healAmount;

		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
		}
	}

	private void die() {
		Destroy(this.gameObject);
	}
}
