using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathCreator : MonoBehaviour {

	Vector3 curPathPos = Vector3.zero;

	const float BOARD_LENGTH = 13f;

	string[] pathNames = new string[] {"Straight", "Left", "Right"};

	List<GameObject> instantiatedObjects = new List<GameObject>(); // keeps track of all our path obejcts

	void Start () {

		//add the first one @index: 0
		instantiatedObjects.Add(Instantiate(Resources.Load("Straight"), Vector3.zero, Quaternion.identity) as GameObject);

		for (int i = 1; i < 10; i++) {

			string name = pathNames[Random.Range(0, pathNames.Length)];

			Transform prevObj = instantiatedObjects[i-1].transform.FindChild("_end").transform;

			GameObject obj = Instantiate(Resources.Load(name),
			                             prevObj.position,
			                             prevObj.rotation) as GameObject;
			instantiatedObjects.Add(obj);

		}

	}

	void Update () {
	}
}
