using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons {

public class Sword : MonoBehaviour, IWeapon {
	public Animator animator;
	public AnimState current_state = AnimState.IDLE;

	public float animation_max_duration = 1.0f;

	public float animation_current_duration = 0.0f;

	public bool is_attacking = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		is_attacking = Input.GetAxis("Attack1") != 0;
		attack();
		//manage_animation();
	}

	public void attack()
	{
		if (current_state == AnimState.IDLE && is_attacking) {
			Debug.Log("ATTACK1");
			animator.SetTrigger(Animator.StringToHash("TO_ATTACK1"));
			animator.SetTrigger(Animator.StringToHash("ATTACK1"));
			current_state = AnimState.ATTACK1;
			animation_current_duration = 0;
		}

		if (current_state == AnimState.ATTACK1 && is_attacking &&
		    animation_current_duration >= animation_max_duration) {
			Debug.Log("ATTACK2");
			animator.SetTrigger(Animator.StringToHash("ATTACK2"));
			current_state = AnimState.ATTACK2;
			animation_current_duration = 0;
		}

		if (current_state == AnimState.ATTACK2 && is_attacking &&
		    animation_current_duration >= animation_max_duration) {
			Debug.Log("ATTACK3");
			animator.SetTrigger(Animator.StringToHash("ATTACK3"));
			current_state = AnimState.ATTACK3;
			animation_current_duration = 0;
		}

		if (current_state == AnimState.ATTACK3 && !is_attacking &&
		    animation_current_duration >= animation_max_duration) {
			Debug.Log("END_ATTACK3");
			animator.SetTrigger(Animator.StringToHash("END_ATTACK3"));
			current_state = AnimState.END_ATTACK3;
			animation_current_duration = 0;
		}

		if (current_state == AnimState.ATTACK1 && !is_attacking &&
		    animation_current_duration >= animation_max_duration) {
			Debug.Log("END_ATTACK1");
			animator.SetTrigger(Animator.StringToHash("END_ATTACK1"));
			current_state = AnimState.END_ATTACK1;
			animation_current_duration = 0;
		}

		if (current_state == AnimState.ATTACK2 && !is_attacking &&
		    animation_current_duration >= animation_max_duration) {
			Debug.Log("END_ATTACK2");
			animator.SetTrigger(Animator.StringToHash("END_ATTACK2"));
			current_state = AnimState.END_ATTACK2;
			animation_current_duration = 0;
		}

		if ((current_state == AnimState.END_ATTACK3 ||
		    current_state == AnimState.END_ATTACK2 ||
		    current_state == AnimState.END_ATTACK1) &&
		    animation_current_duration >= animation_max_duration) {
			Debug.Log("TO_IDLE");
			animator.SetTrigger(Animator.StringToHash("IDLE"));
			current_state = AnimState.IDLE;
			animation_current_duration = 0;
		}

		if (animation_current_duration < animation_max_duration) {
			animation_current_duration += Time.deltaTime;
		}
	}

	public void manage_animation()
	{
		switch(current_state)
		{
			case AnimState.IDLE:
				animator.SetTrigger(Animator.StringToHash("IDLE"));
				change_state(AnimState.TO_ATTACK1);
			break;
			case AnimState.TO_ATTACK1:
				animator.SetTrigger(Animator.StringToHash("TO_ATTACK1"));
				change_state(AnimState.ATTACK1);
			break;
			case AnimState.ATTACK1:
				animator.SetTrigger(Animator.StringToHash("ATTACK1"));
				change_state(AnimState.ATTACK2);
			break;
			case AnimState.ATTACK2:
				animator.SetTrigger(Animator.StringToHash("ATTACK2"));
				change_state(AnimState.ATTACK3);
			break;
			case AnimState.ATTACK3:
				animator.SetTrigger(Animator.StringToHash("ATTACK3"));
				change_state(AnimState.END_ATTACK3);
			break;
			case AnimState.END_ATTACK1:
				animator.SetTrigger(Animator.StringToHash("END_ATTACK1"));
			break;
			case AnimState.END_ATTACK2:
				animator.SetTrigger(Animator.StringToHash("END_ATTACK2"));
			break;
			case AnimState.END_ATTACK3:
				animator.SetTrigger(Animator.StringToHash("END_ATTACK3"));
				change_state(AnimState.IDLE);
			break;
		}
	}

	public void change_state(AnimState state)
	{
		current_state = state;
	}
}

}//namespace Weapons