using UnityEngine;
using UnityEngine.UI;

public class RegenLevelDisplay : MonoBehaviour
{
	Player _player;
	public Text display;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
	}

	private void Update()
	{
		display.text = $"Health Regen level {_player.hpRegenLevel}";
	}
}
