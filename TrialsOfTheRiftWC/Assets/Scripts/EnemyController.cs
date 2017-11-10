using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public abstract class EnemyController : MonoBehaviour {

    protected enum State {CHASE, ATTACK, DIE};
	[SerializeField]
	protected Constants.Side e_Side;
	[SerializeField]
	protected float f_health;
	[SerializeField]
	protected float f_damage;
	protected State e_State;
	protected Rigidbody r_rigidbody;
	protected UnityEngine.AI.NavMeshAgent nma_agent;
	
	protected void Start() {
		r_rigidbody = GetComponent<Rigidbody>();
		nma_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		EnterStateChase ();
	}
	
	// Update is called once per frame
	protected void Update () {
		switch (e_State) {
		case State.CHASE:
			UpdateChase ();
			break;
		case State.ATTACK:
			UpdateAttack();
			break;
		case State.DIE:
			UpdateDie ();
			break;
		}
    }

	protected void EnterStateChase() {
		e_State = State.CHASE;
		ChildEnterStateChase();
    }
	
	protected abstract void ChildEnterStateChase();

    protected void UpdateChase() {
		ChildUpdateChase();
    }
	
	protected abstract void ChildUpdateChase();

    protected void EnterStateAttack() {
        e_State = State.ATTACK;
		ChildEnterStateAttack();
    }
	
	protected abstract void ChildEnterStateAttack();

    protected void UpdateAttack() {
		ChildUpdateAttack();
    }
	
	protected abstract void ChildUpdateAttack();

    protected void DoAttack() {
		ChildDoAttack();
    }
	
	protected abstract void ChildDoAttack();

    protected void AttackOver() {
		EnterStateChase();
    }

    protected void EnterStateDie() {
		e_State = State.DIE;
		ChildEnterStateDie();
    }
	
	protected abstract void ChildEnterStateDie();

    protected void UpdateDie() {
		ChildUpdateDie();
		Destroy(gameObject);
    }
	
	protected abstract void ChildUpdateDie();
	
	protected void TakeDamage(float damage){
		print("Enemy ow");
		f_health -= damage;
		if(f_health <= 0f){
			EnterStateDie();
		}
	}
}