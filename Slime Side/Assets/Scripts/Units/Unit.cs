using UnityEngine;

public class Unit : MonoBehaviour
{
    public float maxHealth;

	public float health;
    public float damage;

	private void Update()
	{
		if(health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	public void GetDamage(float damage)
    {
        health -= damage;
    }
}
