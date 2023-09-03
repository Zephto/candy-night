using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Componente usado para controlar los movimientos de los enemigos
/// </summary>
public class EnemyController : MonoBehaviour {
	
	#region Private variables
	//Navmesh variables
	private NavMeshAgent agent;
	private FirstPersonController playerReference;
	
	//In camera detector
	private Plane[] cameraFrustrum;
	private Collider enemyCollider;
	#endregion

	void Awake() {
		playerReference = GameObject.FindObjectOfType<FirstPersonController>();
		agent			= this.GetComponent<NavMeshAgent>();
		enemyCollider	= this.GetComponent<Collider>();
	}

	void Update() {
		
		cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if(!GeometryUtility.TestPlanesAABB(cameraFrustrum, enemyCollider.bounds)) {
			agent.isStopped = false;
			agent.SetDestination(playerReference.transform.position);
		}else{
			agent.isStopped = true;
		}
	}

}
