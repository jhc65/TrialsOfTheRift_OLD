using UnityEngine;
using System.Collections;

public class MeleeController : EnemyController {
	
	private GameObject go_closestTarget;
	[SerializeField]
	private float f_attackDistance;

	protected override void ChildEnterStateChase() {
		
    }

    protected override void ChildUpdateChase() {
		go_closestTarget = null;
		float f_minDistance = 9999f;
		float f_currentDistance;
		for(int i = 0; i < Constants.Players.Length; i++){	
			f_currentDistance = Vector3.Distance(Constants.Players[i].transform.position,transform.position);
			if(Constants.Players[i].GetComponent<PlayerController>().e_Side == e_Side && f_currentDistance < f_minDistance){
				go_closestTarget = Constants.Players[i];
				f_minDistance = f_currentDistance;
			}
		}
		
		
		if(go_closestTarget){
			nma_agent.SetDestination(go_closestTarget.transform.position);
			if(Vector3.Distance(transform.position,go_closestTarget.transform.position) < f_attackDistance)
				EnterStateAttack();
		}
		else{
			nma_agent.Stop();
		}
			
    }

    protected override void ChildEnterStateAttack() {
        GetComponent<Animator>().Play("placeholder_enemy_attack");
    }

    protected override void ChildUpdateAttack() {

    }

    protected override void ChildDoAttack() {
		go_closestTarget.GetComponent<PlayerController>().TakeDamage(f_damage);
    }

    protected override void ChildEnterStateDie() {
    }

    protected override void ChildUpdateDie() {
    }
}