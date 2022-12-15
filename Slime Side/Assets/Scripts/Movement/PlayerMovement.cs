using UnityEngine;

public class PlayerMovement : Movement
{
	Player _player;
	Vector3 targetPosition;
	bool _canMoving;
	bool movementSpeedSaved;

	private float _xSpeed = 0;
	private float _ySpeed = 0;
	private float _zSpeed = 15;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
		unitRigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		targetPosition = _player.waypoint.transform.position;

		if (transform.position.z >= targetPosition.z)
		{			
			_canMoving = false;			
			movementSpeedSaved = false;
			Stop();
		}
		else
		{			
			_canMoving = true;
			
			if (!movementSpeedSaved)
			{
				movementSpeed = new Vector3(_xSpeed, _ySpeed, _zSpeed);
				movementSpeedSaved = true;
			}
		}		
	}

	private void FixedUpdate()
	{
		if (_canMoving)
		{
			if(_player.isFighting)
				Stop();
			else
				Move();
		}
	}
}
