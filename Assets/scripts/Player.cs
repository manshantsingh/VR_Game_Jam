using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	const float MAX_SPEED_MULTIPLIER = 15f;

	Rigidbody rigidBody;

    public float speed;
	
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		//Vector3 headRotation = this.transform.FindChild ("Head").rotation.eulerAngles; // use rotation for speed

		

		// move the rigidbody in the direction of the camera
		rigidBody.MovePosition(transform.position + Camera.main.gameObject.transform.forward * speed * Time.deltaTime);
        transform.position= new Vector3(transform.position.x, 1f, transform.position.z);

	}
}
