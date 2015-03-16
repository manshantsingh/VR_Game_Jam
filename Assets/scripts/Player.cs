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

    void Update()
    {
        if (Cardboard.SDK.CardboardTriggered) Application.LoadLevel(0);
    }
	void FixedUpdate ()
    {
        currentRotationState = head.transform.eulerAngles.y;

        if (Mathf.Abs(currentRotationState - lastRotationState) > 180f)
        {
            if (currentRotationState > lastRotationState) lastRotationState += 360f;
            else lastRotationState -= 360f;
        }

        if (text.fontSize > 1) text.fontSize--;

        //transform.rotation = Quaternion.Slerp(transform.rotation, goalDirection, rotationSpeed);
        transform.rotation = goalDirection;

        //at the end
        lastRotationState = head.transform.eulerAngles.y;

        // move the rigidbody forward
        print("FixedUpdate Position: " + transform.position);
        rigidBody.MovePosition(transform.position + transform.forward * speed);
        print("FixedUpdate Forward: " + transform.forward * speed);
	}

    void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Left" && currentRotationState - lastRotationState < -directionOffset)
        {
            DirectionChangeCommon(other, -1);
        }
        else if (other.tag == "Right" && currentRotationState - lastRotationState > directionOffset)
        {
            DirectionChangeCommon(other, 1);
        }
    }
    void DirectionChangeCommon(Collider other, int i)
    {
        print(other.tag);
        goalDirection *= Quaternion.Euler(0, 90 * i, 0);
        other.GetComponent<BoxCollider>().isTrigger = false;
        text.fontSize = 200;
        PathCreater_Script.createNext();
        PathCreater_Script.destroyOld();
        int dirY = Mathf.RoundToInt(goalDirection.eulerAngles.y);
        Vector3 pos = transform.position;

        //i = 0;
        print("****************************************IT'S OVER HERE****************************************");
        print("Current Direction: " + dirY % 180);
        print("collider position:  x=" + other.transform.position.x + "  z=" + other.transform.position.z);

        if (dirY % 180 == 0)
        {
            pos.x = other.transform.position.x;
        }
        else if (dirY % 180 == 90)
        {
            pos.z = other.transform.position.z;
        }
        //else if (dirY % 360 == 180)
        //{
        //    pos.x = other.transform.position.x;
        //}
        //else
        //{
        //    pos.z = other.transform.position.z;
        //}
        transform.position = pos;
        print("position of player: " + transform.position);
    }
}

