using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathCreator : MonoBehaviour {

	private Vector3 curPathPos = Vector3.zero;

	const float BOARD_LENGTH = 13f;

	string[] pathNames = new string[] {"Straight", "Left", "Right"};

	private List<GameObject> instantiatedObjects = new List<GameObject>(); // keeps track of all our path obejcts

	void Start () {

		for (int i = 0; i < 50; i++) {

			float thisZ = 0f;

			float thisX = 0f;

			if ( i > 0 ) {
				GameObject prev = instantiatedObjects[i-1];

				const float LR_LEN = BOARD_LENGTH-3;

				if (prev.name == "Left(Clone)") {
					thisX = curPathPos.x - LR_LEN;
					curPathPos.x -= LR_LEN;
				} else if (prev.name == "Right(Clone)") {
					thisX = curPathPos.x + LR_LEN;
					curPathPos.x += LR_LEN;
				} else {
					thisX = curPathPos.x;
				}

				thisZ = prev.transform.position.z + BOARD_LENGTH;
			}


			GameObject obj = Instantiate(Resources.Load(pathNames[Random.Range(0, pathNames.Length)]), 
			                             new Vector3(thisX, 0.5f, thisZ), 
			                             Quaternion.identity) as GameObject;
			instantiatedObjects.Add(obj);

		}

	}

	void Update () {
	
	}
}
