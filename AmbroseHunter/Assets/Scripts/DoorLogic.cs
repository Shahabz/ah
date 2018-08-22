using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour, IContextInteractable {

    bool isOpening, isOpened;
	bool isClosing;
	public float endRotation = 80f, startRotation = 0f;
    public Transform rotatorRoot;
    public AudioSource doorOpenSound;
	public AudioSource doorCloseSound;
	public Vector3 AxisOfRotation;

	// Use this for initialization

    private float startTime, duration = 2f;

	void Start () {
		if (gameObject.layer != LayerMask.NameToLayer("Interactable"))
		{
			Debug.LogError("Needs to be on interactable layer to interact with", this);
		}
		if (rotatorRoot == null)
        {
            rotatorRoot = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (isOpening)
        {
            float t = (Time.time - startTime) / duration;
			rotatorRoot.localRotation = Quaternion.Euler(Mathf.SmoothStep(startRotation, endRotation, t)*AxisOfRotation);
            if (t > 1)
            {
                isOpening = false;
            }
        }

		if (isClosing)
		{
			float t = (Time.time - startTime) / duration;
			rotatorRoot.localRotation = Quaternion.Euler(Mathf.SmoothStep(endRotation, startRotation, t)*AxisOfRotation);
			if (t > 1)
			{
				isOpening = false;
			}
		}
	}

	public void Interact(TestPlayerController thisPlayerController)
	{
		if (!isOpening && !isClosing) {
			if (!isOpened)
			{
				OpenDoor ();
			}
			else if (isOpened)
			{
				CloseDoor ();
			}
		}
    }

	public string GetPrompt()
	{
		return "Press Interact to Open Door";
	}

	public bool CanInteract()
	{
        if (isOpened || isOpening)
            return false;
        else
    		return true;
	}

    void OpenDoor()
    {
        isOpening = true;
        startTime = Time.time;
		if (doorOpenSound)
        	doorOpenSound.Play();
        isOpened = true;
    }

	void CloseDoor()
	{
		isClosing = true;
		startTime = Time.time;
		if (doorCloseSound)
			doorCloseSound.Play();
		isOpened = false;
	}
}

