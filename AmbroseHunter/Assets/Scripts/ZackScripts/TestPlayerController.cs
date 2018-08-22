using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum PlayerMode {Normal, WalkLookOnly, LookOnly, Cutscene, InteractiveCutscene, Death};



public class TestPlayerController : MonoBehaviour {

	public PlayerMode thisPlayerMode = PlayerMode.Normal;

	BaseInput input;
	
	public float moveSpeed = 3.0f;
	public float sprintSpeedMod = 1.8f;
	public float turnSpeed = 0.6f;

	bool bIsFalling;

	Animator anim;
    //	public Animator topAnimator;
    //	public Animator bottomAnimator;
    FootstepHandler footstepHandler;
	Rigidbody rigidbody;
	public Transform cameraObj;

	List<GameObject> interactables = new List<GameObject> ();
	GameObject closestInteractableObject;

	public AudioClip[] allBarks;
	public AudioSource barkSource;
	int lastbark;
	public void PlayBark() {
		int temp = Random.Range (0, allBarks.Length);
		while (temp == lastbark)
			temp = Random.Range (0, allBarks.Length);
		barkSource.clip = allBarks[temp];
		barkSource.Play ();
		lastbark = temp; 
	}

	float CheckForInteractablesTimer;

	bool isStomp;
	public void Stomp()
	{
		if (!isStomp) {
			GetComponent<Animator> ().SetTrigger ("stomp");
			isStomp = true;
			SetPlayerModeCutscene ();
			StartCoroutine ("HandleStomp");
		}

	}

	IEnumerator HandleStomp ()
	{
		yield return new WaitForSeconds (.6f);
		SetPlayerModeNormal ();
		isStomp = false;
	}

	public GameObject NPCam;

	public Transform holdItemTransform;

	public UnityEvent InteractiveCutscene_Interact, InteractiveCutscene_Fire;

    public static TestPlayerController s_instance;

	public enum InputLock { CameraOnly, Locked, Unlocked }
	public InputLock lockInput = InputLock.Unlocked;


	GameObject heldObject;

	float runAnxietyTime = 10f, runAnxietyTimer;
	bool isBeingWatched;
	public void SetIsBeingWatched(bool isTrue) {
		isBeingWatched = isTrue;
	}

	bool bSwitch_InteractiveCutscene, bSwitch_Normal, bSwitch_Cutscene;

    void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start () {
		barkSource = GetComponent<AudioSource> ();
		GetComponentInChildren<Camera>().transform.parent = null;
        footstepHandler = GetComponentInChildren<FootstepHandler>();
		input = GetComponent<BaseInput>();
		rigidbody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		HandleMovement ();
		HandleInteraction ();
		CheckForInteractables ();
		//had to make this block of code to avoid loop glitches
		if (bSwitch_InteractiveCutscene) {
			SetPlayerMode (PlayerMode.InteractiveCutscene);
			bSwitch_InteractiveCutscene = false;
		}
		else if (bSwitch_Cutscene) {
			SetPlayerMode (PlayerMode.Cutscene);
			bSwitch_Cutscene = false;
		}
		else if (bSwitch_Normal) {
			SetPlayerMode (PlayerMode.Normal);
			bSwitch_Normal = false;
		}
	}

	public void FixedUpdate() {
		if(lockInput == InputLock.Locked)
			return;
		//TODO make this not suck by working out better logic for when you are on elevation

			//allow gravity to pull you down
		/*RaycastHit tempHit;
		Physics.Raycast (transform.position, Vector3.down, out tempHit, 10000000f);
		//if is on elevation
		print(tempHit.normal);
		print (tempHit.point);
		if (Vector3.Dot(tempHit.normal, Vector3.up) < .9f)
		{
			float speedMod = input.sprint ? sprintSpeedMod : 1.0f;
			rigidbody.angularVelocity = Vector3.zero;
			if (input.moveDir.magnitude > 0.0f) {
				Vector3 targetVelocity = transform.forward * moveSpeed * speedMod;
				Vector3 velocity = rigidbody.velocity;
				Vector3 velocityChange = (targetVelocity - velocity);
				rigidbody.AddForce (velocityChange, ForceMode.VelocityChange);
				Vector3 lookDir = Vector3.zero;
				if (Mathf.Abs (input.moveDir.z) > 0.0f)
					lookDir += (transform.position - cameraObj.transform.position).normalized * Mathf.Sign (input.moveDir.z);
				if (Mathf.Abs (input.moveDir.x) > 0.0f)
					lookDir += Vector3.Cross (transform.up, (transform.position - cameraObj.transform.position).normalized) * Mathf.Sign (input.moveDir.x);
				lookDir.Normalize ();
				lookDir.y = 0.0f;
				if (lookDir != Vector3.zero)
					rigidbody.MoveRotation (Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (lookDir), turnSpeed * Time.deltaTime));
			}
		}
		else
		{*/

			float speedMod = input.sprint ? sprintSpeedMod : 1.0f;
			rigidbody.angularVelocity = Vector3.zero;
			if (input.moveDir.magnitude > 0.0f) {
			Vector3 targetVelocity = (transform.forward - transform.up) * moveSpeed * speedMod;
				Vector3 velocity = rigidbody.velocity;
				Vector3 velocityChange = (targetVelocity - velocity);
				rigidbody.AddForce (velocityChange, ForceMode.VelocityChange);
				Vector3 lookDir = Vector3.zero;
				if (Mathf.Abs (input.moveDir.z) > 0.0f)
					lookDir += (transform.position - cameraObj.transform.position).normalized * Mathf.Sign (input.moveDir.z);
				if (Mathf.Abs (input.moveDir.x) > 0.0f)
					lookDir += Vector3.Cross (transform.up, (transform.position - cameraObj.transform.position).normalized) * Mathf.Sign (input.moveDir.x);
				lookDir.Normalize ();
				lookDir.y = 0.0f;
				if (lookDir != Vector3.zero)
					rigidbody.MoveRotation (Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (lookDir), turnSpeed * Time.deltaTime));
			//}
		}
	}

	public void HandleMovement() {

		//Wonky code because idle: 0, walk: 0.5, sprint: 1
		anim.SetFloat("Movement", Mathf.Lerp(anim.GetFloat("Movement"), input.moveDir.normalized.magnitude + anim.GetFloat("Movement"), 14f*Time.deltaTime));

		if (input.moveDir.magnitude > 0.0f) {
			footstepHandler.PlayFootStep(Mathf.Lerp(anim.GetFloat("Movement"), input.moveDir.normalized.magnitude/2f + anim.GetFloat("Movement")/2f, 14f*Time.deltaTime)); //this is always 1, I need to figure out how to differentiate between running and walking and pass it to this param
			anim.SetFloat("Movement", input.sprint ? Mathf.Lerp(anim.GetFloat("Movement"), 1f, 5f*Time.deltaTime) :  Mathf.Lerp(anim.GetFloat("Movement"), 0f, 5f*Time.deltaTime));
		} else {
			footstepHandler.CallCeaseFootStep();
			anim.SetFloat("Movement", Mathf.Lerp(anim.GetFloat("Movement"), 0f, 5f*Time.deltaTime));
		}
	}



	public void SetPlayerModeNormal(){
		lockInput = InputLock.Unlocked;
		thisPlayerMode = PlayerMode.Normal;
	}

	public void SetPlayerModeCutscene(){
		SetPlayerMode (PlayerMode.Cutscene);
	}

	public void SetLookAtIKTarget(Transform thisTarget) {
		GetComponent<RootMotion.FinalIK.LookAtIK> ().solver.target = thisTarget;
	}

	public void SetPlayerMode(PlayerMode switchToThisMode) {
		switch (switchToThisMode) {

		case PlayerMode.Normal:
			lockInput = InputLock.Unlocked;
			thisPlayerMode = PlayerMode.Normal;
			break;

		case PlayerMode.Cutscene:
			lockInput = InputLock.Locked;

			anim.SetFloat ("Movement", 0);
			anim.SetFloat ("Sprint", 0);
			thisPlayerMode = PlayerMode.Cutscene;

			break;

		case PlayerMode.LookOnly:

			break;

		case PlayerMode.WalkLookOnly:

			break;

		case PlayerMode.InteractiveCutscene:
			thisPlayerMode = PlayerMode.InteractiveCutscene;
			lockInput = InputLock.Locked;

			break;

		case PlayerMode.Death:
			thisPlayerMode = PlayerMode.Death;
			break;
		}
	}

	void HandleInteraction() {
		if (NPInputManager.input.Interact.WasPressed) {
			if (closestInteractableObject != null) {
				closestInteractableObject.GetComponent<IContextInteractable> ().Interact (this);
			}
		}
	}

	void CheckForInteractables()
	{
		//we want to allow people to interact with an object
		//when the object is in range and can be interactive, we want to display that hitting the action button
		//will perform this contextual action
		CheckForInteractablesTimer+=Time.deltaTime;
		if (CheckForInteractablesTimer > .05f) {
			CheckForInteractablesTimer = 0;
			FindAllInteractionInInteractionZone();
            //TODO make this work for multiple interactables next to each other
			if (interactables.Count > 0) {
                //show prompt for this
                TextManager.s_instance.SetPromptUntimed(interactables[0].GetComponent<IContextInteractable>().GetPrompt());
			} else {
                //hide prompt
                TextManager.s_instance.ClearPrompt();
			}
		}



	}

	void FindAllInteractionInInteractionZone()
	{
        //Handles whether items are still interactable or not by checking CanInteract
		Vector3 center = transform.position + transform.forward + transform.up;
		Collider[] cols = Physics.OverlapSphere (center, 1.5f, LayerMask.GetMask ("Interactable"));
		for (int i = 0; i < cols.Length; i++) {
			if (cols [i].GetComponent<IContextInteractable> () != null && cols [i].GetComponent<IContextInteractable> ().CanInteract()) {
				interactables.Add (cols [i].gameObject);
			}
		}
		if (interactables.Count > 0) {
			GameObject closest = interactables [0];
			for (int i = 1; i < interactables.Count; i++) {
				if (Vector3.Distance (center, interactables [i].transform.position) < Vector3.Distance (center, closest.transform.position)) {
					closest = interactables [i];
				}
				closestInteractableObject = closest;
                if (!closestInteractableObject.GetComponent<IContextInteractable>().CanInteract())
                {
                    interactables.Clear();
                }
			}
		}
	}


    public void EnterTherapy ()
    {
		TestUIManager.instance.SetState(TestUIManager.UIState.Cutscene);
//		lockInput = InputLock.CameraOnly;
        anim.SetTrigger("sit");
    }

    public void ExitTherapy()
    {
		TestUIManager.instance.SetState(TestUIManager.UIState.None);
//		lockInput = InputLock.Unlocked;
        anim.SetTrigger("stand");
    }
		
	public void GrabAndSwallowPills (GameObject thesePills) {
		anim.SetTrigger ("pills");
		bSwitch_Cutscene = true;
		StartCoroutine ("EndPillGrab");
		heldObject = thesePills;
		thesePills.transform.SetParent (holdItemTransform);
		thesePills.transform.position = holdItemTransform.position;
		thesePills.transform.rotation = holdItemTransform.rotation;
	}

	IEnumerator EndPillGrab() {
		yield return new WaitForSeconds (3f);
		GetComponent<HealthHandler> ().ReduceStress (5);
		heldObject.transform.parent = null;
		heldObject.AddComponent<Rigidbody> ();
		bSwitch_Normal = true;
	}

	public void PlayAnimation(string name, bool freezeInput, float freezeDuration = -1)
	{

	}

	void OnCollisionStay()
	{
		bIsFalling = false;
	}

	void OnCollisionExit()
	{
		bIsFalling = true;

	}
}
