using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
public class PlayerMovement : MonoBehaviour {

	public GameObject player;
	public Rigidbody player_rigidbody;


	// Use this for initialization
	void Start () {
		player = this.gameObject;
		player_rigidbody = player.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
} //namespace Player