using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementTankScript : MonoBehaviour {

	PhotonView view;
	Rigidbody rb;
	public float movementSpeed = 7;

	// Use this for initialization
	void Start () {

		view = GetComponent<PhotonView> ();
		rb = GetComponent<Rigidbody> ();

	}
	
	void Update()
	{
		if (view.isMine) 
		{

			// keyboard control
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);

			// mobile control

			float xValue = CrossPlatformInputManager.GetAxis ("Horizontal");
			float yValue = CrossPlatformInputManager.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (xValue, 0, yValue);
			rb.velocity = movement * movementSpeed;

			if (xValue != 0 && yValue != 0) 
			{
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Mathf.Atan2 (xValue, yValue) * Mathf.Rad2Deg, transform.eulerAngles.z);
			}


		}

	}
}
