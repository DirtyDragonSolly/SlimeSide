using UnityEngine;

public class Waypoint : MonoBehaviour
{
	public Vector3 position { get; private set; }
	
	private void OnEnable()
	{
		SetPosition();
	}
	
	void SetPosition()
	{
		position = GetComponent<Transform>().position;
	}
}

