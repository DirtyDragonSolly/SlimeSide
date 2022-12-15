using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    Player _player;
	Vector3 _offset;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
		_offset = new Vector3(7.5f, 4.75f, 8f);
	}

	void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
