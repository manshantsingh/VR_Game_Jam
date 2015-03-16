using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathCreator : MonoBehaviour {

	string[] pathNames = new string[] {"Straight", "Left", "Right"};

	List<GameObject> instantiatedObjects = new List<GameObject>(); // keeps track of all our path obejcts
    int destroyIndex = -2;

	void Start () {

		//add the first one @index: 0
		instantiatedObjects.Add(Instantiate(Resources.Load("Straight"), Vector3.zero, Quaternion.identity) as GameObject);

        //for (int i = 1; i < 5; i++) 
        createNext();

	}

	public void createNext()
    {
        int index = Random.Range(0, pathNames.Length);
        string name = pathNames[index];

        Transform prevObj = instantiatedObjects[instantiatedObjects.Count-1].transform.FindChild("_end").transform;

        GameObject obj = Instantiate(Resources.Load(name),
                                     prevObj.position,
                                     prevObj.rotation) as GameObject;
        instantiatedObjects.Add(obj);

        if (index == 0) 
        {
            createNext();
        }
    }
    public void destroyOld()
    {
        if (destroyIndex < 0) destroyIndex++;
        else if (instantiatedObjects[destroyIndex].tag == "Straight")
        {
            Destroy(instantiatedObjects[destroyIndex]);
            destroyIndex++;
            destroyOld();
        }
        else
        {
            Destroy(instantiatedObjects[destroyIndex]);
            destroyIndex++;
        }
    }
}
