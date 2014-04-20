using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private bool isInHazard;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 mouseDirection = Vector3.zero;

	private CharacterController controller;
	private PlayerHealth pHealth;
	private Lava lava;

	// Use this for initialization
	void Start () {

		isInHazard = false;

		controller = this.gameObject.GetComponent<CharacterController>();
		pHealth = this.gameObject.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(isInHazard);
		//pHealth.receiveDamage(5.0f);

		if (controller.isGrounded) {

			this.gameObject.SendMessage("receiveDamage", 5.0f);

			//Debug.Log("TRUE");
			
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		} else {
			//Debug.Log("FALSE");
		}



		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	public void receiveLavaObject(Lava lavaObject) {
		Debug.Log("HUE");
		lava = lavaObject;
	}
}
