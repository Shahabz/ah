using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDetector : MonoBehaviour {

    List<GameObject> interactables = new List<GameObject>();
    GameObject closestInteractableObject;

    float CheckForInteractablesTimer;
    public float interactionRange = .5f;

    void Update()
    {
        HandleInteraction();
        CheckForInteractables();
    }

    void HandleInteraction()
    {
        if (NPInputManager.input.Interact.WasPressed)
        {
            if (closestInteractableObject != null)
            {
                closestInteractableObject.GetComponent<IContextInteractable>().Interact(this.gameObject);
            }
        }
    }

    void CheckForInteractables()
    {
        //we want to allow people to interact with an object
        //when the object is in range and can be interactive, we want to display that hitting the action button
        //will perform this contextual action
        CheckForInteractablesTimer += Time.deltaTime;
        if (CheckForInteractablesTimer > .05f)
        {
            CheckForInteractablesTimer = 0;
            FindAllInteractionInInteractionZone();
            //TODO make this work for multiple interactables next to each other
            if (interactables.Count > 0)
            {
                //show prompt for this
                IContextInteractable temp = interactables[0].GetComponent<IContextInteractable>();
                TextManager.s_instance.SetPromptUntimed(temp.GetPrompt());
            }
            else
            {
                //hide prompt
                TextManager.s_instance.ClearPrompt();
            }
        }
    }

    void FindAllInteractionInInteractionZone()
    {
        //Handles whether items are still interactable or not by checking CanInteract
        Vector3 center = transform.position + transform.forward + transform.up;
        Collider[] cols = Physics.OverlapSphere(center, interactionRange, LayerMask.GetMask("Interactable"));
        if (cols.Length == 0)
        {
            interactables.Clear();
            return;
        }
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].GetComponent<IContextInteractable>() != null && cols[i].GetComponent<IContextInteractable>().CanInteract())
            {
                interactables.Add(cols[i].gameObject);
            }
        }
        if (interactables.Count > 0)
        {
            GameObject closest = interactables[0];
            for (int i = 1; i < interactables.Count; i++)
            {
                if (Vector3.Distance(center, interactables[i].transform.position) < Vector3.Distance(center, closest.transform.position))
                {
                    closest = interactables[i];
                }
                closestInteractableObject = closest;
                if (!closestInteractableObject.GetComponent<IContextInteractable>().CanInteract())
                {
                    interactables.Clear();
                }
            }
        }
    }
}
