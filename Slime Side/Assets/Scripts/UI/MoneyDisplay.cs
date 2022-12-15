using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
	Text _display;
	Player _player;
	
	private void Start()
	{
		_display = GetComponent<Text>();	
		_player= FindObjectOfType<Player>();
	}
	
	void Update()
    {
		_display.text = $"{_player.money}$";
    }
}
