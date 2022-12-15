using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float health;
	public Unit unit;
	public Text hpTxt;

	private void Update()
	{
		CalculateHealth();
		bar.fillAmount= health;
		hpTxt.text = ((int)unit.health).ToString();
	}

	void CalculateHealth()
	{
		health = (float)unit.health / (float)unit.maxHealth;
	}
}
