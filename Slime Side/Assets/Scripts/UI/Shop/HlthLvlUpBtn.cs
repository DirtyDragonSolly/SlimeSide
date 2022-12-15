using UnityEngine;
using UnityEngine.UI;

public class HlthLvlUpBtn : MonoBehaviour
{

	Player _player;
	Button _button;
	public Text costDisplay;

	void Start()
	{
		_player = FindObjectOfType<Player>();
		_button = GetComponent<Button>();
	}

	private void Update()
	{
		costDisplay.text = $"{Cost()}$";
		if (_player.money >= Cost())
			_button.image.color = Color.green;
		else
			_button.image.color = Color.red;
	}

	public void LevelUp()
	{
		if (_player.money >= Cost())
		{
			_player.HealthLevelUp(Cost());
		}
	}

	float Cost()
	{
		return _player.healthLevel * 10;
	}
}
