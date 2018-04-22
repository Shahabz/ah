using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Stats/EnemyStats")]
public class AIStats : ScriptableObject {

	public float speed = 1f;
	public float lookSphereCastRadius = 1f;
	public float lookRange = 1f;
	public float attackRange = 1f;
	public float attackRate = 1f;
	public float maxHealth = 10f;
	//etc...
}
