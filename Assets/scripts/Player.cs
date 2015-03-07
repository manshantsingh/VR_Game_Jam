using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	const float MAX_SPEED_MULTIPLIER = 15f;

	Rigidbody rigidBody;

    public float speed, directionOffset, rotationSpeed;

    public GameObject head,text;

    TextMesh theText;
    float lastRotationState, currentRotationState;
    Quaternion goalDirection;
	
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
        theText = text.gameObject.GetComponent<TextMesh>();
        lastRotationState = head.transform.eulerAngles.y;
        goalDirection = transform.rotation;
	}

	void FixedUpdate () {

		// move the rigidbody forward
		rigidBody.MovePosition(transform.position + transform.forward * speed);

        currentRotationState = head.transform.eulerAngles.y;

        if (Mathf.Abs(currentRotationState - lastRotationState) > 180f)
        {
            if (currentRotationState > lastRotationState) lastRotationState += 360f;
            else lastRotationState -= 360f;
        }

        //print("current: " + currentRotationState + " vs last: " + lastRotationState);
        
        theText.fontSize--;

        transform.rotation = Quaternion.Slerp(transform.rotation, goalDirection, rotationSpeed);
        //transform.rotation = goalDirection;

        //at the end
        lastRotationState = head.transform.eulerAngles.y;
	}

    void OnTriggerStay(Collider other)
    {
        //print("The collider's tag is: " + other.tag+" AND the difference is: "+(currentRotationState-lastRotationState));
        if (other.tag == "Left" && currentRotationState - lastRotationState < -directionOffset)
        {
            goalDirection *= Quaternion.Euler(0, -90, 0);
            other.GetComponent<BoxCollider>().isTrigger = false;
            theText.fontSize = 200;
        }
        else if (other.tag == "Right" && currentRotationState - lastRotationState > directionOffset)
        {
            goalDirection *= Quaternion.Euler(0, 90, 0);
            other.GetComponent<BoxCollider>().isTrigger = false;
            theText.fontSize = 200;
        }
    }
    void OnTriggerExit(Collider other)
    {
        print("out of " + other.tag);
    }
}
