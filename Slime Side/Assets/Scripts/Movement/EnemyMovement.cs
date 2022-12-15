using UnityEngine;

public class EnemyMovement : Movement
{
    Player _player;
	float _distanceToPlayer;	
	bool _needMove;
	Negative _enemy;

	bool movementSpeedSaved;
	float _movementSpeed;

	private void OnEnable()
	{
		_player = FindObjectOfType<Player>();
		_enemy = GetComponent<Negative>();
		unitRigidbody = GetComponent<Rigidbody>();
		_movementSpeed = (_player.transform.position.z - transform.position.z) / 8;
	}

	private void Update()
	{
		_distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
		
		if(_distanceToPlayer > _enemy.attackDistance)
		{
			_needMove = true;

			if (!movementSpeedSaved)
			{
				movementSpeed = new Vector3(
				/*X*/0,
				/*Y*/0,
				/*Z*/_movementSpeed);

				Debug.Log($"New movement speed is {movementSpeed}.");
				movementSpeedSaved = true;
			}
		}
		else
		{
			_needMove = false;
			movementSpeedSaved = false;
		}
	}

	private void FixedUpdate()
	{
		if(_needMove)		
			Move();		
		else
			Stop();
	}
}
