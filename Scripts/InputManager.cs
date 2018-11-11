using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public float player_max_speed = 40;
	public float player_acceleration = 500;
	public float player_rotation_speed = 1.0f;
	public int current_selected_spell = 0;
	public Rigidbody player_rigidbody;

	public GameObject player;

	public Player.PlayerSkillManager skill_manager;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		player_inputs();
	}

	private void player_inputs()
	{
		player_movement();
		player_camera_movment();
		player_skill_handling();
	}
	
	private void player_movement()
	{
		float horizontal = Input.GetAxis("Horizontal");     //joystick horizontal
		float vertical = Input.GetAxis("Vertical");      //joystick vertical

		if (vertical > 0.0f ) {
			player_rigidbody.AddForce(player.transform.forward * player_acceleration * Time.deltaTime);
		}
		if (vertical < 0.0f) {
			player_rigidbody.AddForce(-player.transform.forward * player_acceleration * Time.deltaTime);
		}
		if (horizontal > 0.0f) {
			player_rigidbody.AddForce(player.transform.right * player_acceleration * Time.deltaTime);
		}
		if (horizontal < 0.0f) {
			player_rigidbody.AddForce(-player.transform.right * player_acceleration * Time.deltaTime);
		}
	}

	private void player_skill_handling()
	{
		if (Input.GetAxis("Attack1") != 0) {
			skill_manager.cast_spell(current_selected_spell);
		}
	}

	private void player_camera_movment()
	{
		float mouse_horizontal = Input.GetAxis("Mouse X") * player_rotation_speed;

		player.transform.Rotate(0,mouse_horizontal,0);
	}

}
