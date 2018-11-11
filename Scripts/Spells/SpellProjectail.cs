using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells {
public class SpellProjectail : MonoBehaviour {
	public float projectail_speed;
	public float projectail_max_speed;
	public float max_range;
	public float casting_time;
	public float cooldown_time;
	public float cooldown_timer = 0.0f;
	public float damage;
	public float mana_cost;
}
} //namespace Spells