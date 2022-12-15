using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Unit[] units;
    public uint unitsCount;

	float _spawnDelay = 2;

    bool _hasSpawned;

	List<Unit> _units = new List<Unit>();
	public bool _isAliveSomeUnit;

	private void OnEnable()
	{
        unitsCount = Convert.ToUInt32(UnityEngine.Random.Range(1,3));
		FindObjectOfType<Player>().isFighting = true;
	}

	private void Update()
	{
		CheckIsAlive();

		if (unitsCount > 0)
		{
			if (!_hasSpawned)
			{
				_hasSpawned = true;
				Invoke("Spawn", _spawnDelay);
			}
		}
		else
		{
			if (!_isAliveSomeUnit)
			{
				Destroy(gameObject);
				FindObjectOfType<Player>().isFighting = false;
			}
		}
	}

	void Spawn()
    {
        var enemy  = Instantiate(units[UnityEngine.Random.Range(0, units.Length - 1)], 
			new Vector3(transform.position.x + UnityEngine.Random.Range(-3f,3f), transform.position.y, transform.position.z),
			transform.rotation);
		_units.Add(enemy);
		_hasSpawned= false;
		unitsCount--;
    }

	void CheckIsAlive()
	{
		if (_units.Count > 0)
		{
			if (_units[0] == null)
				_units.RemoveAt(0);
			else
				_isAliveSomeUnit= true;
		}
		else 
			_isAliveSomeUnit= false;
	}

	public List<Unit> GetUnits()
	{
		return _units;
	}
}
