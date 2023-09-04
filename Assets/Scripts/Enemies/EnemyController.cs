using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Componente usado para controlar los movimientos de los enemigos
/// </summary>
public class EnemyController : Interactable {
	
	#region Classes references
	private EnemyAudios _enemyAudios;
	#endregion

	#region Private variables
	//Movement
	private float stopDistance;

	//Navmesh variables
	private NavMeshAgent agent;
	private CharacterController playerReference;
	
	//In camera detector
	private Plane[] cameraFrustrum;
	private Collider enemyCollider;
	#endregion

	void Awake() {
		_enemyAudios		= this.GetComponent<EnemyAudios>();
		playerReference 	= GameObject.FindObjectOfType<CharacterController>();
		agent				= this.GetComponent<NavMeshAgent>();
		enemyCollider		= this.GetComponent<Collider>();
	}

	void Start() {
		agent.isStopped = true;
		stopDistance = 1f;

		InvokeRepeating("PlaySteps", 0f, 1f);
	}

	void Update() {
		if(!agent.isActiveAndEnabled) return;
		
		cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if(!GeometryUtility.TestPlanesAABB(cameraFrustrum, enemyCollider.bounds)) {
			agent.isStopped = false;

			var distance = Vector3.Distance(this.transform.position, playerReference.transform.position);
			
			if(distance > stopDistance){
				agent.SetDestination(playerReference.transform.position);
				//Caminando
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

	#region Override Methods
	public override void Interact(){
		base.Interact();
		
		agent.enabled = false;
		enemyCollider.isTrigger = true;
		this.transform.SetParent(playerReference.zoneArm.transform);
		this.transform.position = new Vector3(0,0,0);
		this.transform.rotation = new Quaternion(0,0,0,0);
		this.transform.position = new Vector3(
			playerReference.zoneArm.transform.position.x + 1f,
			playerReference.zoneArm.transform.position.y - 0.5f,
			playerReference.zoneArm.transform.position.z + 1f
		);
	}
	#endregion

	#region Private Methods
	private void PlaySteps(){
		if(!agent.isActiveAndEnabled) return;

		if(!agent.isStopped){
			_enemyAudios.PlaySteps();
		}
	}
	#endregion

}
