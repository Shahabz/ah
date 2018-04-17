using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {


	public State currentState;
	public State remainState;
	public AIStats thisAIStats;

	[HideInInspector] public NavMeshAgent thisNavMeshAgent;
	public Transform eyes;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;



	private bool aiActive;

	// Use this for initialization
	void Awake () {
		thisNavMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	public void SetupAI(bool aiActivationFromAgentManager, List<Transform> wayPointsFromAgentManager) {
		wayPointList = wayPointsFromAgentManager;
		aiActive = aiActivationFromAgentManager;
		if (aiActive) {
			thisNavMeshAgent.enabled = true;
		} else {
			thisNavMeshAgent.enabled = false;
		}
	}

	void Update()
	{
		if (!aiActive)
			return;
		currentState.UpdateState (this);
	}

	void OnDrawGizmos()
	{
		if (currentState != null && eyes != null) {
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere (eyes.position, 2f);
		}
	}

	public void TransitionToState(State nextState)
	{
		if (nextState != remainState) {
			currentState = nextState;
		}
	}

	public bool CheckIfCountdownElapsed(float duration) 
	{
		stateTimeElapsed += Time.deltaTime;
		return (stateTimeElapsed >= duration);
	}

	private void OnExitState()
	{
		stateTimeElapsed = 0;
	}
}
