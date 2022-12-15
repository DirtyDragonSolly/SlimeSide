using UnityEngine;

public class RedSlime : Negative
{
	bool canAttack;
	float _attackDelay = 2;

	float _cost = 10;

	private void Start()
	{
		canAttack = true;
		_attackType = attackType.melee;
		target= FindObjectOfType<Player>();
		attackDistance = (float)_attackType;		
	}

	private void Update()
	{
		if(Vector3.Distance(transform.position, target.transform.position) < attackDistance && canAttack)
		{
			Invoke("Attack", _attackDelay);
			canAttack = false;
		}
		
		if (health <= 0)
		{
			FindObjectOfType<Player>().money += _cost;
			Destroy(this.gameObject);
		}
	}

	void Attack()
	{
		target.GetDamage(damage);
		canAttack= true;
	}
}

	

	
