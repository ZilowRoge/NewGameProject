using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells {
public class Fireball : SpellProjectail {
	private Vector3 forward;

	public void set_projectail_forward(Vector3 direction)
	{
		forward = direction;
	}

	// Update is called once per frame
	void Update () {
		move_projectail();
	}

	
	private void move_projectail() //sprwdzic jak zrobić prywatny intr
	{	
		Debug.Log("Move");
		Rigidbody projectail_rigidbody = this.GetComponent<Rigidbody>();
		limit_projectail_speed(projectail_rigidbody);
		if (forward != null) {
			Debug.Log("Add force");
			projectail_rigidbody.AddForce(forward * projectail_speed * Time.deltaTime);
		} else {
			Debug.Log("Fireball: Forward vector missing");
		}
	}

	private void limit_projectail_speed(Rigidbody projectail_rigidbody)
	{
		if (projectail_rigidbody.velocity.magnitude > projectail_max_speed) {
			Debug.Log("Limit");
			projectail_rigidbody.velocity = projectail_rigidbody.velocity.normalized * projectail_max_speed;
		}
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{

		Debug.Log("Fireball: Collision with" + other.gameObject.tag);
		//Destroy(this);
	}
}
} //namespace Spells