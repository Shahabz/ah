using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateController))]
public class EnemyBase : MonoBehaviour, IContextInteractable {

	[SerializeField]
	string interactionPrompt;
	[SerializeField]
	string animationName;

	float health;

	void Start()
	{

	}

	void Initialize ()
	{
		health = GetComponent<StateController> ().thisAIStats.maxHealth;
	}

	public virtual void Interact(GameObject thisController) {
		if (animationName != "")
            if (thisController.GetComponent<TestPlayerController>())
                thisController.GetComponent<TestPlayerController>().PlayAnimation (animationName, true);
	}

	public virtual bool CanInteract() {
		if (health <= 0)
			return false;
		else
			return true;
	}
	public virtual string GetPrompt() {
		return interactionPrompt;
	}
}
