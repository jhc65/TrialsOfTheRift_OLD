using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public abstract class EnemyController : MonoBehaviour {

    protected enum State {CHASE, ATTACK, FROZEN, DIE};
	[SerializeField]
	public Constants.Side e_Side;
	[SerializeField]
	protected int i_health;
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
		if(i_health <= 0f){
			Debug.Log("death");
			EnterStateDie();
		}
		switch (e_State) {
		case State.CHASE:
			UpdateChase ();
			break;
		case State.ATTACK:
			UpdateAttack();
			break;
		case State.FROZEN:
			UpdateFrozen();
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
	
	public void TakeDamage(float damage){
		i_health -= (int)damage;
		//Debug.Log(i_health);
		//if(i_health <= 0f){
		//	Debug.Log("death");
		//	EnterStateDie();
		//}
	}
	
	protected void EnterStateFrozen() {
		e_State = State.FROZEN;
		nma_agent.isStopped = true;
		Invoke("Unfreeze", Constants.SpellStats.C_IceFreezeTime);
		ChildEnterStateFrozen();
    }
	protected abstract void ChildEnterStateFrozen();

    protected void UpdateFrozen() {
		ChildUpdateFrozen();
    }
	protected abstract void ChildUpdateFrozen();
	
	public void Freeze(){
		EnterStateFrozen();
	}

	private void Unfreeze(){
		nma_agent.isStopped = false;
		EnterStateChase();
	}

    public int GetHealth() {
        return i_health;
    }

    public void SetHealth(int healthIn) {
        i_health = healthIn;
    }
}