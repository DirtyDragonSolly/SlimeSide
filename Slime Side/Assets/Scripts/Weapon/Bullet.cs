using System.Net.Sockets;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Player owner;

	Rigidbody _rb;
	Unit _target;

	Spawner _spawner;

	bool _hasLaunched;
	Vector3 _direction = new Vector3(0, 0, 100);
	
	private void OnEnable()
	{
		_hasLaunched= false;
		_rb= GetComponent<Rigidbody>();		
		_spawner = FindObjectOfType<Spawner>();
	}

	private void Update()
	{
		if (_spawner != null)
		{
			_target = _spawner.GetUnits()[0];

			if (_target != null)
			{
				if (!_hasLaunched)
				{
					Launch();
				}
				else
				{
					var distance = Vector3.Distance(transform.position, _target.transform.position);

					if (distance < 1)
					{						
						_target.GetDamage(owner.Damage());
						Destroy(gameObject);
					}
				}
			}
			else
				Destroy(gameObject);
		}
		else
			Destroy(gameObject);

		if (transform.position.y < 0.3f)
			Destroy(gameObject);
	}

	void Launch()
	{
		_rb.AddForce(new Vector3(
			_target.transform.position.x - transform.position.x,
			_target.transform.position.y - transform.position.y + 4,
			_target.transform.position.z - transform.position.z), ForceMode.Impulse);
		_hasLaunched = true;
	}
}
