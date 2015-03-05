using UnityEngine;
using System.Collections;

public class ApplicationConfig : MonoBehaviour {

	public int _FrameRate = 60;

	void Awake() {
		Application.targetFrameRate = _FrameRate;
		QualitySettings.vSyncCount = 0;
	}
}
