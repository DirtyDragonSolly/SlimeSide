using UnityEngine;

public class Chunk : MonoBehaviour
{
	public Transform begin;
	public Transform end;
	public Waypoint waypoint;

	public Spawner spawnerPrefab;
	bool _hasSpawned;

	private void OnEnable()
	{
		_hasSpawned = false;	
	}

	public void SpawnSpawner()
	{
		if (!_hasSpawned)
		{
			Instantiate(spawnerPrefab,
				new Vector3(transform.position.x, 0.75f, transform.position.z + 15),
				new Quaternion());
			_hasSpawned = true;
		}
	}
}
