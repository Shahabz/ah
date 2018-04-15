using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public enum BaseAIStates {Idle, Talking, Following, Waypoints, Runaway, AttackPlayer};

public class BaseAI : MonoBehaviour {

	public Animator thisAnimator;
	protected NavMeshAgent thisNavMeshAgent;
	protected BaseAIStates thisAIState;
	float runSpeed = .02f;
	public float triggerFollowDistance = 15f;
	float angleForIsPlayerFacing = 20;
	float waypointToggleDistance = 3f;
	//cat runs back to this point after it attacks player
	Vector3 runawayTarget;

	public GameObject deadBodyGO;

	float overlapTimeTilDeath;
	public bool isKillable;
	bool isOverlappingPlayer;
	protected bool canCauseStress=true;

	public GameObject[] waypoints;
	int waypointIndex;
	// Use this for initialization

	[SerializeField]
	bool switchToFollowing, switchToIdle, switchToWaypoints, switchToRunaway, switchToAttackPlayer;
	protected void Start () {

		thisNavMeshAgent = GetComponent<NavMeshAgent> ();

		if (switchToFollowing) {
			SwitchToState (BaseAIStates.Following);
			switchToFollowing = false;
		}
		else if (switchToAttackPlayer) {
			SwitchToState(BaseAIStates.AttackPlayer);
			switchToAttackPlayer = false;
		}
		else if (switchToIdle) {
			thisAIState = (BaseAIStates.Idle);
			switchToIdle = false;
		}
		else {
			SwitchToState (BaseAIStates.Waypoints);
		}
	}

	// Update is called once per frame
	protected void Update () {

		switch (thisAIState)
		{
		case BaseAIStates.Idle:
			WaitForPlayerToComeClose();
			if (switchToFollowing)
			{
				SwitchToState (BaseAIStates.Following);
				switchToFollowing = false;
			}
			break;
		case BaseAIStates.Talking:

			break;

		case BaseAIStates.Following:
			FollowPlayer ();
			if (switchToIdle) {
				SwitchToState (BaseAIStates.Idle);
				switchToIdle = false;
			}
			else if (switchToRunaway) {
				SwitchToState (BaseAIStates.Runaway);
				switchToRunaway = false;
			}
			break;

		case BaseAIStates.Waypoints:
			HandleWaypointChecking ();
			break;


		case BaseAIStates.Runaway:
			thisNavMeshAgent.SetDestination (runawayTarget);
			CheckDistanceToRunawayTarget ();
			if (switchToFollowing) {
				switchToFollowing = false;
				SwitchToState (BaseAIStates.Following);
			}

			break;
		case BaseAIStates.AttackPlayer:
			FollowPlayer ();
			break;
		}

	}



	public virtual void Interact () {
	}



	void FollowPlayer()
	{
		//transform.LookAt(TestPlayerController.s_instance.transform.position);
		thisNavMeshAgent.SetDestination (TestPlayerController.s_instance.transform.position);


	}



	void WaitForPlayerToComeClose()
	{
		if (Vector3.Distance(transform.position, TestPlayerController.s_instance.transform.position) < triggerFollowDistance) {
			//if (!CheckIsPlayerLookingAtCat())
			//{
				switchToFollowing = true;
			//}
		}
	}

	void CheckDistanceToRunawayTarget()
	{
		if (Vector3.Distance(transform.position, runawayTarget) < .1f) {
			switchToFollowing = true;
		}
	}

	bool IsFacedByPlayer()
	{
		if (GetAngleBetweenPlayerForwardAndSelf() < angleForIsPlayerFacing)
		{
			return true;
		}
		else { return false; }
	}

	float GetAngleBetweenPlayerForwardAndSelf()
	{
		Vector3 playerForward = TestPlayerController.s_instance.transform.forward;
		Vector3 towardCat = -TestPlayerController.s_instance.transform.position + transform.position;
		return Vector3.Angle(playerForward, towardCat);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			isOverlappingPlayer = true;

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			isOverlappingPlayer = false;
		}
	}


	public void SwitchToState(BaseAIStates switchToThisState) {
		switch (switchToThisState) {
		case BaseAIStates.Waypoints:
			thisAIState = BaseAIStates.Waypoints;
			thisAnimator.SetTrigger("run");
			thisNavMeshAgent.isStopped = false;
			GotoNextWaypoint ();
			break;

		case BaseAIStates.Idle:
			thisAIState = BaseAIStates.Idle;
			thisAnimator.ResetTrigger ("run");
			thisAnimator.SetTrigger ("idle");
			thisNavMeshAgent.isStopped = true;
			break;
		case BaseAIStates.Following:
			thisAIState = BaseAIStates.Following;
			thisAnimator.SetTrigger ("run");
			thisNavMeshAgent.isStopped = false;
			runawayTarget = transform.position;
			break;
		case BaseAIStates.Runaway:
			thisAIState = BaseAIStates.Runaway;
			break;
		case BaseAIStates.AttackPlayer:
			thisAIState = BaseAIStates.AttackPlayer;
			thisAnimator.SetTrigger ("run");
			break;
		}
	}




	void GotoNextWaypoint()
	{
		//transform.LookAt(waypoints[waypointIndex].transform);
		thisNavMeshAgent.SetDestination (waypoints [waypointIndex].transform.position);

	}

	void HandleWaypointChecking()
	{
		if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < waypointToggleDistance) {
			if (waypointIndex >= waypoints.Length - 1)
			{
				waypointIndex = 0;
			}
			else
			{
				waypointIndex++;
			}
		}
		GotoNextWaypoint ();

	}
}
