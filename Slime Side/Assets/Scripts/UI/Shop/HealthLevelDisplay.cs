using UnityEngine;
using UnityEngine.UI;

public class HealthLevelDisplay : MonoBehaviour
{
	Player _player;
	public Text display;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
	}

	private void Update()
	{
		display.text = $"Health level {_player.healthLevel}";
	}
}
