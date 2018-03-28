using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour, IInteractable {

    bool isOpening, isOpened;
	bool isClosing;
    public float endRotation = 80f;
    public Transform rotatorRoot;
    public AudioSource doorOpenSound;
	public AudioSource doorCloseSound;

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
            rotatorRoot.localRotation = Quaternion.Euler(new Vector3(0f, Mathf.SmoothStep(0, endRotation, t), 0));
            if (t > 1)
            {
                isOpening = false;
            }
        }

		if (isClosing)
		{
			float t = (Time.time - startTime) / duration;
			rotatorRoot.localRotation = Quaternion.Euler(new Vector3(0f, Mathf.SmoothStep(endRotation, 0, t), 0));
			if (t > 1)
			{
				isOpening = false;
			}
		}
	}

	public void Interact()
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

    void OpenDoor()
    {
        isOpening = true;
        startTime = Time.time;
        doorOpenSound.Play();
        isOpened = true;
    }

	void CloseDoor()
	{
		isClosing = true;
		startTime = Time.time;
		doorCloseSound.Play();
		isOpened = false;
	}
}

