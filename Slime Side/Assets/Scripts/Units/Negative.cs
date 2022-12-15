public class Negative : Unit
{
	protected enum attackType
	{
		melee = 3,
		range = 10,
	}
	
	protected Player target;
	protected attackType _attackType;
	public float attackDistance;
}

