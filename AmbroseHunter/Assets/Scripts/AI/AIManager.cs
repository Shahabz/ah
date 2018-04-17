using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

	public List<Transform> waypoints;

	public StateController[] stateControllers;

	// Update is called once per frame
	void Start() {
		for (int i = 0; i < stateControllers.Length; i++) {
			stateControllers [i].SetupAI (true, waypoints);
		}
	}
}
