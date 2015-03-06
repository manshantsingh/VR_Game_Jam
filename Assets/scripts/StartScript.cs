using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
    
    void Update()
    {
        if (Cardboard.SDK.CardboardTriggered) Application.LoadLevel(1);
    }
}
