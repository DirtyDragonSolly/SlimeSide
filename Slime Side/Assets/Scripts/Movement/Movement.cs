using UnityEngine;

public class Movement : MonoBehaviour
{
	public Rigidbody unitRigidbody;	

	public Vector3 movementSpeed;

	public void Move()
	{
		unitRigidbody.velocity = new Vector3(movementSpeed.x, movementSpeed.y, movementSpeed.z);
	}

	public void Stop()
	{
		unitRigidbody.velocity = Vector3.zero;
	}
}

