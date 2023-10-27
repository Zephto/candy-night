using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAIConnie : EnemyBase
{
	protected override void AbstractUpdate() {
		if(IsPlayerLooking()){
			agent.isStopped = false;
		}
	}

	private void FollowPlayer(){
		var distance = Vector3.Distance(this.transform.position, playerReference.transform.position);

		//Te quedaste en esta parte para tratar de optimizar estos calculos
		//y evitar usar el SetDestinacion en cada frame, sino posiblemente en algun
		//intervalo de tiempo
		if(distance > StopDistance){
			agent.SetDestination(playerReference.transform.position);
		}
	}
}
