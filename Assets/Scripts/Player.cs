using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private bool isInHazard;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 mouseDirection = Vector3.zero;

	private CharacterController controller;
	private PlayerHealth pHealth;

	// Use this for initialization
	void Start () {

		if (rigidbody)
			rigidbody.freezeRotation = true;

		isInHazard = false;

		controller = this.gameObject.GetComponent<CharacterController>();
		pHealth = this.gameObject.GetComponent<PlayerHealth>();

		
	}
	
	// Update is called once per frame
	void Update () {

		if (axes == RotationAxes.MouseXAndY) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		} else if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		} else {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}

		if (controller.isGrounded) {

			if (isInHazard) {
				this.gameObject.SendMessage("receiveDamage", 5.0f);
			}

			
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

	void OnControllerColliderHit(ControllerColliderHit hit) {
		isInHazard = (hit.gameObject.tag == "Hazard") ? true : false;
	}
	
}
