using System.Threading;
using UnityEngine;

public class Player : Positive
{
	[Header("Individual Characteristics")]
	public float startMaxHealth = 100;
	public float hpRegen;

	[Header("Currency")]
	public float money;

	[Header("Improvements")]
	public float hpRegenLevel;
	public float damageLevel;
	public float healthLevel;
	float _healthPerLevel = 10;

	[Header("Shooting")]
	public GameObject shootPoint;
	public bool isFighting;
	public bool canAttack;
	public GameObject bulletPrefab;
	float attackDelay = 1.25f;

	[Header("Regen")]
	public bool _needRegen;

	private void Start()
	{
		canAttack = true;
	}
	private void OnEnable()
	{
		canAttack = true;
	}

	private void Update()
	{
		if (isFighting)
		{
			Unit enemy = FindObjectOfType<Negative>();

			if (enemy != null)
			{
				if (isFighting && canAttack)
				{
					canAttack = false;
					Invoke("Shoot", attackDelay);
				}
			}
		}

		if (health < MaxHealth())
			_needRegen = true;
		else
			_needRegen = false;

		if (_needRegen)
			health += Time.fixedDeltaTime * Regen();
		else
			health = MaxHealth();

		if (health <= 0)
			Respawn();
	}

	void Shoot()
	{
		Negative target = FindObjectOfType<Negative>();

		if (target != null)
		{
			var _bullet = Instantiate(bulletPrefab, shootPoint.transform.position, transform.rotation);

			_bullet.GetComponent<Bullet>().owner= this;
		}
		
		canAttack = true;
	}

	//floats 
	public float Damage()
	{
		return damageLevel * damage;
	}
	public float Regen() 
	{
		return hpRegen * hpRegenLevel;
	}
	public float MaxHealth()
	{
		return maxHealth = startMaxHealth + healthLevel * _healthPerLevel;
	}

	//Levels
	public void DamageLevelUp(float cost)
	{
		damageLevel++;
		money -= cost;
	}
	public void HealthLevelUp(float cost)
	{
		healthLevel++;
		money -= cost;
	}
	public void RegenLevelUp(float cost)
	{
		hpRegenLevel++;
		money -= cost;
	}

	//Respawn
	void Respawn()
	{
		enabled = false;
		health= MaxHealth();
		Negative[] enemies = Resources.FindObjectsOfTypeAll<Negative>();		

		foreach(var enemy in enemies)
		{
			Destroy(enemy.gameObject);
		}
		Thread.Sleep(100);
		
		enabled = true;
	}
}
