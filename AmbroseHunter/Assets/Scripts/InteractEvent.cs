using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractEvent : MonoBehaviour, IContextInteractable {

	public UnityEvent OnInteractEvents;
	bool hasPlayed;
    public string prompt = "";
	public bool infinitelyTriggerable;
	public void Interact(TestPlayerController thisController) {
		if (!hasPlayed)
			OnInteractEvents.Invoke ();
		if (!infinitelyTriggerable)
			hasPlayed = true;
	}

	public bool CanInteract()
	{
		return true;
	}

	public string GetPrompt()
	{
        return prompt;
	}
}
