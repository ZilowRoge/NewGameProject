using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobs{
public class MobChase : MobBehavior {
	// Use this for initialization
	public FieldOfView mob_view;
	public GameObject attack_target;
	public Animator animator;
	void Start () {
		mob_view = GetComponent<FieldOfView>();
		animator = GetComponent<Animator>();
		animator.speed = 0.75f;
		if (movment_script == null) {
			movment_script = GetComponent<MobMovment>();
		}
	}

	void Update()
	{
		targets_in_attack_range();
		if (attack_target != null)
		{
			animator.SetBool("Attack", true);
		} else {
			animator.SetBool("Attack", false);
		}
	}
	public bool reached_target()
	{
		return near_point(destination);
	}
	public void execute_state()
	{
		if (!reached_target()) {
			movment_script.set_destionation(destination);
			movment_script.move();
		}
	}

	public bool destination_reached(string str = "MobChase")
	{
		Debug.Log(str + "destination reached: " + near_point(destination));
		return near_point(destination);
	}

	public void targets_in_attack_range()
	{
		Collider[] targets = Physics.OverlapSphere(transform.position, location_offset, mob_view.target_mask);
		foreach(Collider col in targets)
		{
			if (col.gameObject.tag == "Player") {
				attack_target = col.gameObject;
				break;
			}
		}
	}
}
} //namespace Mobs
