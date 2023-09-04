using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Componente usado para controlar los movimientos de los enemigos
/// </summary>
public class EnemyController : MonoBehaviour {
	
	#region Classes references
	private EnemyAudios _enemyAudios;
	#endregion

	#region Private variables
	//Movement
	private float stopDistance;

	//Navmesh variables
	private NavMeshAgent agent;
	private CharacterActions playerReference;
	
	//In camera detector
	private Plane[] cameraFrustrum;
	private Collider enemyCollider;
	#endregion

	void Awake() {
		_enemyAudios		= this.GetComponent<EnemyAudios>();
		playerReference 	= GameObject.FindObjectOfType<CharacterActions>();
		agent				= this.GetComponent<NavMeshAgent>();
		enemyCollider		= this.GetComponent<Collider>();
	}

	void Start() {
		agent.isStopped = true;
		stopDistance = 1f;
	}

	void Update() {
		cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if(!GeometryUtility.TestPlanesAABB(cameraFrustrum, enemyCollider.bounds)) {
			agent.isStopped = false;

			var distance = Vector3.Distance(this.transform.position, playerReference.transform.position);
			
			Debug.Log("distance " + distance);
			if(distance > stopDistance){
				agent.SetDestination(playerReference.transform.position);
			}else{
				//El enemigo ha atacado
				agent.isStopped = true;
				playerReference.Kill(this.transform);
				_enemyAudios.PlayScream();
			}

		}else{
			agent.isStopped = true;
		}
	}

}
