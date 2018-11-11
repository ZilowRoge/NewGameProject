using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour {
	GameObject implosion;
	GameObject shield;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void shield_implosion()
	{
		Instantiate(implosion, transform.position, Quaternion.identity);
	}


}
