using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : AIAction {
	
	public override void Act (StateController controller)
	{
		Attack (controller);
	}

	private void Attack(StateController controller)
	{
		RaycastHit hit;

		Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.thisAIStats.attackRange, Color.red);

		if (Physics.SphereCast (controller.eyes.position, controller.thisAIStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.thisAIStats.attackRange)
		    && hit.collider.CompareTag ("Player")) {
			if (controller.CheckIfCountdownElapsed (controller.thisAIStats.attackRate)) {
				//controller.attack
			}
		}
	}

}
