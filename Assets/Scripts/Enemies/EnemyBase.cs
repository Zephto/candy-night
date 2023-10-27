using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Componente usado para controlar los movimientos de los enemigos
/// </summary>
public abstract class EnemyBase : Interactable {
	
	#region Classes references
	private EnemyAudios _enemyAudios;
	#endregion

	#region Public variables
	[SerializeField] private MeshRenderer faceRenderer;
	[SerializeField] private Texture screamerFace;
	#endregion

	#region Private variables
	//Navmesh variables
	protected NavMeshAgent agent;
	protected CharacterController playerReference;
	
	//In camera detector
	private Plane[] cameraFrustrum;
	private Collider enemyCollider;
	#endregion

	#region Consts
	//Max distance to approach the player
	protected const float StopDistance = 1f;
	#endregion

	void Awake() {
		_enemyAudios		= this.GetComponent<EnemyAudios>();
		playerReference 	= GameObject.FindObjectOfType<CharacterController>();
		agent				= this.GetComponent<NavMeshAgent>();
		enemyCollider		= this.GetComponent<Collider>();
	}

	void Start() {
		agent.isStopped = true;
		agent.enabled = false;

		// InvokeRepeating("PlaySteps", 0f, 1f);
	}

	void Update() {
		if(!agent.isActiveAndEnabled) return;
		
		// AbstractUpdate();
		// return;

		cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if(!GeometryUtility.TestPlanesAABB(cameraFrustrum, enemyCollider.bounds)) {
			agent.isStopped = false;

			var distance = Vector3.Distance(this.transform.position, playerReference.transform.position);
			
			if(distance > StopDistance){
				agent.SetDestination(playerReference.transform.position);
				//Caminando
			}else{
				this.transform.position = new Vector3(
					this.transform.position.x,
					this.transform.position.y + 0.8f,
					this.transform.position.z
				);

				//El enemigo ha atacado
				CanMove(false);
				agent.isStopped = true;
				playerReference.Kill(this.transform);
				_enemyAudios.PlayScream();
				faceRenderer.material.mainTexture = screamerFace;

			}

		}else{
			agent.isStopped = true;
		}
	}

	protected abstract void AbstractUpdate();

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

	#region Public Methods
	public void CanMove(bool set){
		agent.enabled = set;
	}
	#endregion

	#region Private Methods
	private void PlaySteps(){
		if(!agent.isActiveAndEnabled) return;

		if(!agent.isStopped){
			_enemyAudios.PlaySteps();
		}
	}

	/// <summary>
	/// Check if player is looking the enemie
	/// </summary>
	protected bool IsPlayerLooking() {
		cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		return GeometryUtility.TestPlanesAABB(cameraFrustrum, enemyCollider.bounds);
	}
	#endregion

}
