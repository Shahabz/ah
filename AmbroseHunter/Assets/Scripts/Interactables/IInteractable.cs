//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public interface IInteractable  {
    void Interact();
}

//interactable interface that can lose ability to be interacted with, and return a string for to tell player what the interaction will do
public interface IContextInteractable {
	void Interact(GameObject thisController);
	bool CanInteract();
	string GetPrompt();
}