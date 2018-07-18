using UnityEngine;
using System;

public enum PlayerState {Menu, Driving, Walking};
public enum AnxietyDescription {None, Mild, Moderate, Severe, Debilitating, Psychotic, _Size}
public enum DevLevel {None, Amateur=10, Inexperienced = 20, Beginner=30, Novice=50, Junior=70, Green = 90, Intermediate = 100, _Size}

public class PlayerController : MonoBehaviour {
	public static PlayerController s_instance;

	public GameObject[] WalkingStateGameObjects, DrivingStateGameObjects;
	public MonoBehaviour[] WalkingStateObjects, DrivingStateObjects;

    [SerializeField]
    bool bDebugStartInCar;

    private void Start()
    {
        if (bDebugStartInCar)
        {
            Vector3 startPos = GameObject.Find("DebugStartPositionCar").transform.position;
            SwitchToDrivingState();
            foreach (GameObject x in DrivingStateGameObjects)
            {
                x.transform.position = startPos;
            }
        }
    }

    void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Destroy (this);
		}
	}

	public void SwitchToWalkingState()
	{
		foreach (GameObject go in WalkingStateGameObjects) {
			go.SetActive (false);
		}
		foreach (GameObject go in DrivingStateGameObjects) {
			go.SetActive (true);
		}
		foreach (MonoBehaviour m in WalkingStateObjects) {
			m.enabled = false;
		}
		foreach (MonoBehaviour m in DrivingStateObjects) {
			m.enabled = true;
		}
	}

	public void SwitchToDrivingState()
	{
		foreach (GameObject go in WalkingStateGameObjects) {
			go.SetActive (true);
		}
		foreach (GameObject go in DrivingStateGameObjects) {
			go.SetActive (false);
		}
		foreach (MonoBehaviour m in WalkingStateObjects)
		{
			m.enabled = true;
		}
		foreach (MonoBehaviour m in DrivingStateObjects)
		{
			m.enabled = false;
		}
	}
}
