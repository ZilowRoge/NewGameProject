using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
public class PlayerSkillManager : MonoBehaviour {

	
	public GameObject spell_cast_point;
	public List<GameObject> spells = new List<GameObject>();

	public List<GameObject> shields = new List<GameObject>();
	public float spell_cooldown_time = 1.0f;

	public float spell_cooldown_timer = 0.0f;

	public bool shield_casted = false;

	public float shield_time_max = 2.5f;
	public float shield_timer = 0.0f;

	public void cast_spell(int spell_id)
	{

		/*GameObject projectail;
		if(spell_cooldown_time < spell_cooldown_timer) {
			if (spell_cast_point != null) {
				if (spell_id < spells_hotkeys.Count || spell_id < 0) {
					projectail = Instantiate(spells_hotkeys[spell_id], spell_cast_point.transform.position, Quaternion.identity);
					projectail.GetComponent<Spells.Fireball>().set_projectail_forward(transform.forward);
					spell_cooldown_timer = 0.0f;
				} else {
					Debug.Log("PlayerSkillManager: Wrong spell_id: " + spell_id);
				}
			} else {
				Debug.Log("PlayerSkillManager: Position not initialized");
			}
		}*/
		if (spell_id < spells.Count || spell_id < 0) {
			GameObject spell = Instantiate(spells[spell_id], spell_cast_point.transform.position, Quaternion.identity);
			switch(spell.GetComponent<Spells.Spell>().spell_type)
			{
				case Spells.SpellType.PROJECTAIL:
				break;
				case Spells.SpellType.AURA:
					if(!shield_casted) {
						spell.transform.parent = this.transform;
						spell.transform.localPosition = Vector3.zero;
						shield_casted = true;
					} else {
						Destroy(spell);
					}
				break;
			}
		} else {
			Debug.Log("PlayerSkillManager: Wrong spell_id: " + spell_id);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(spell_cooldown_time > spell_cooldown_timer) {
			spell_cooldown_timer += Time.deltaTime;
		}
	}
}
} //namespace Player