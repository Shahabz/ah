using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/AIActions/Patrol")]
public class PatrolAction : AIAction {

	public override void Act(StateController controller)
	{
		Patrol (controller);
	}

	private void Patrol(StateController controller)
	{
		controller.thisNavMeshAgent.destination = controller.wayPointList [controller.nextWayPoint].position;
		controller.thisNavMeshAgent.Resume ();

		if (controller.thisNavMeshAgent.remainingDistance <= controller.thisNavMeshAgent.stoppingDistance && !controller.thisNavMeshAgent.pathPending) {
			controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
		}
	}
}
