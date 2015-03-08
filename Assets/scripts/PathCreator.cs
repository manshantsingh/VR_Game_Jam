using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathCreator : MonoBehaviour {

	string[] pathNames = new string[] {"Straight", "Left", "Right"};

	List<GameObject> instantiatedObjects = new List<GameObject>(); // keeps track of all our path obejcts

	void Start () {

		//add the first one @index: 0
		instantiatedObjects.Add(Instantiate(Resources.Load("Straight"), Vector3.zero, Quaternion.identity) as GameObject);

        for (int i = 1; i < 5; i++) createNext();

	}

	public void createNext()
    {
        string name = pathNames[Random.Range(0, pathNames.Length)];

        Transform prevObj = instantiatedObjects[instantiatedObjects.Count-1].transform.FindChild("_end").transform;

        GameObject obj = Instantiate(Resources.Load(name),
                                     prevObj.position,
                                     prevObj.rotation) as GameObject;
        instantiatedObjects.Add(obj);
    }
    public void destroyOld()
    {
        Destroy(instantiatedObjects[instantiatedObjects.Count - 6]);
    }
}
