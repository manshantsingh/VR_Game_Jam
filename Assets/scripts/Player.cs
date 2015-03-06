using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	const float MAX_SPEED_MULTIPLIER = 15f;

	Rigidbody rigidBody;

    public float speed, directionOffset, rotationSpeed;

    public GameObject head,text;

    TextMesh theText;
    float lastRotationState;
    Quaternion goalDirection;
	
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
        theText = text.gameObject.GetComponent<TextMesh>();
        lastRotationState = head.transform.eulerAngles.y;
        goalDirection = transform.rotation;
	}

	void FixedUpdate () {

		//Vector3 headRotation = this.transform.FindChild ("Head").rotation.eulerAngles; // use rotation for speed

		// move the rigidbody in the direction of the camera
		rigidBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

        float currentRotationState = head.transform.eulerAngles.y;


        if (Mathf.Abs(currentRotationState - lastRotationState) > 180f)
        {
            if (currentRotationState > lastRotationState) lastRotationState += 360f;
            else lastRotationState -= 360f;
        }

        //if (Mathf.Abs(currentRotationState - lastRotationState) > directionOffset && enableChange)
        if (Mathf.Abs(currentRotationState - lastRotationState) > directionOffset)
        {
            goalDirection *= currentRotationState > lastRotationState ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, -90, 0);
            print(lastRotationState + " vs " + currentRotationState);
            theText.fontSize = 200;
            //enableChange = false;
        }
        else if (theText.fontSize > 1) theText.fontSize--;

        transform.rotation = Quaternion.Slerp(transform.rotation, goalDirection, rotationSpeed);
        //transform.rotation = goalDirection;

        //at the end
        lastRotationState = head.transform.eulerAngles.y;
	}

    //bool enableChange = true;
    //void Update()
    //{
    //    if (Cardboard.SDK.CardboardTriggered||Input.GetKeyDown(KeyCode.A)) enableChange = true;
    //}
}
