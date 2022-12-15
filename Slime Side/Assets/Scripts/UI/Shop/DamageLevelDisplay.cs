using UnityEngine;
using UnityEngine.UI;

public class DamageLevelDisplay : MonoBehaviour
{
    Player _player;
    public Text display;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
	}

	private void Update()
	{
		display.text = $"Damage level {_player.damageLevel}";
	}
}
