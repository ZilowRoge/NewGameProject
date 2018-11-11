using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells {

public enum SpellType {
	PROJECTAIL,
	AURA,
}
public class Spell : MonoBehaviour {


	public SpellType spell_type;
}
} //namespace spells;