
namespace Weapons {
public interface IWeapon
{
	void attack();
	void change_state(AnimState state);
}

public enum AnimState {
	IDLE,
	TO_ATTACK1,
	ATTACK1,
	ATTACK2,
	ATTACK3,
	END_ATTACK1,
	END_ATTACK2,
	END_ATTACK3
}

}//namespace Weapons

