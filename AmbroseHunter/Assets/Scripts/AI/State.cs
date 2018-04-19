using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject {

	public AIAction[] actions;
	public Transition[] transitions;
	public Color sceneGizmoColor = Color.grey;
	public void UpdateState(StateController controller)
	{
		DoActions (controller);
		CheckTransitions (controller);
	}

	public void DoActions(StateController controller)
	{
		for (int i = 0; i < actions.Length; i++) {
			actions [i].Act (controller);
		}
	}

	private void CheckTransitions(StateController controller)
	{
		for (int i = 0; i < transitions.Length; i++) {
			bool decisionSucceeded = transitions [i].decision.Decide (controller);
			if (decisionSucceeded)
			{
				if (controller.GetComponent<Animator> () && transitions [i].trueStateAnimationTrigger!="")
					controller.GetComponent<Animator> ().SetTrigger (transitions [i].trueStateAnimationTrigger);
				controller.TransitionToState (transitions [i].trueState);
			}else{
				if (controller.GetComponent<Animator> () && transitions [i].falseStateAnimationTrigger!="")
					controller.GetComponent<Animator> ().SetTrigger (transitions [i].falseStateAnimationTrigger);
				controller.TransitionToState (transitions [i].falseState);
			}

		}
	}

}
