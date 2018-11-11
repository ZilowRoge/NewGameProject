using System.Collections;
using System.Collections.Generic;

namespace Spells {
public interface ISpell {
	void cast_spell();
	bool can_cast();
}
} //namespace Spells
