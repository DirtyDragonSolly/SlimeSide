using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    Player _player;    
    public Chunk chunkPrefab;
    
    Chunk _firstChunk;
    private List<Chunk> _spawnedChunks = new List<Chunk>();

	private void Start()
	{
        _player = FindObjectOfType<Player>();

        _firstChunk = FindObjectOfType<Chunk>();

        _spawnedChunks.Add(_firstChunk);

        _player.waypoint = _firstChunk.waypoint;

        SpawnChunk();
	}

	private void Update()
	{
		if(_player.gameObject.transform.position.z >= _spawnedChunks[_spawnedChunks.Count - 1].waypoint.gameObject.transform.position.z)
        {
			SpawnChunk();            
		}
	}

	void SpawnChunk()
    {
        var newChunk = Instantiate(chunkPrefab);
        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].end.position - newChunk.begin.localPosition;
        _spawnedChunks.Add(newChunk);
        _player.SetWaypoint(newChunk.waypoint);
        _spawnedChunks[_spawnedChunks.Count - 2].SpawnSpawner();

        if(_spawnedChunks.Count >= 3 ) 
        {
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }
    }    
}
