using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	const float MAX_SPEED_MULTIPLIER = 15f;

	Rigidbody rigidBody;

    public float speed, directionOffset, rotationSpeed;

    public GameObject head;
    public PathCreator PathCreater_Script;
    public TextMesh text;

    float lastRotationState, currentRotationState;
    Quaternion goalDirection;
	
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
        lastRotationState = head.transform.eulerAngles.y;
        goalDirection = transform.rotation;
	}

	void FixedUpdate () {

		// move the rigidbody forward
		rigidBody.MovePosition(transform.position + transform.forward * speed);
        print(transform.forward * speed);

        currentRotationState = head.transform.eulerAngles.y;

        if (Mathf.Abs(currentRotationState - lastRotationState) > 180f)
        {
            if (currentRotationState > lastRotationState) lastRotationState += 360f;
            else lastRotationState -= 360f;
        }

        if (text.fontSize > 1) text.fontSize--;

        transform.rotation = Quaternion.Slerp(transform.rotation, goalDirection, rotationSpeed);

        //at the end
        lastRotationState = head.transform.eulerAngles.y;
	}

    void OnTriggerStay(Collider other)
    {
        print(other.tag);
        if (other.tag == "Left" && currentRotationState - lastRotationState < -directionOffset)
        {
            goalDirection *= Quaternion.Euler(0, -90, 0);
            other.GetComponent<BoxCollider>().isTrigger = false;
            text.fontSize = 200;
            PathCreater_Script.createNext();
            PathCreater_Script.destroyOld();
        }
        else if (other.tag == "Right" && currentRotationState - lastRotationState > directionOffset)
        {
            goalDirection *= Quaternion.Euler(0, 90, 0);
            other.GetComponent<BoxCollider>().isTrigger = false;
            text.fontSize = 200;
            PathCreater_Script.createNext();
            PathCreater_Script.destroyOld();
        }
    }
}
