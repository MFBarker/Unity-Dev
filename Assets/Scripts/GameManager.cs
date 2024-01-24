using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	[Header("UI")]
	[SerializeField] GameObject titleUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timerUI;
	[SerializeField] TMP_Text healthUI;
	[SerializeField] GameObject gameOverUI;
	[SerializeField] GameObject gameWinUI;

    [Header("Variables")]
    [SerializeField] FloatVariable health;
	[SerializeField] GameObject respawn;
	[SerializeField] GameObject player;

	[Header("Events")]
	[SerializeField] Event gameStartEvent;
	[SerializeField] GameObjectEvent respawnEvent;

    public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		GAME_WIN,
		GAME_OVER
	}

	private State state = State.TITLE;
	private float timer = 0;
	private int lives = 0;

	public int Lives { 
		get { return lives; } 
		set { 
			lives = value; 
			livesUI.text = "LIVES: " + lives.ToString(); 
			} 
		}

	public float Timer
	{
		get { return timer; }
		set
		{
			timer = value;
			timerUI.text = string.Format("{0:F1}", timer);
		}
	}

	void Update()
	{
		switch (state)
		{
			case State.TITLE:
				titleUI.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
			case State.START_GAME:
				titleUI.SetActive(false);
				Timer = 0;
				Lives = 3;
				health.value = 100;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				gameStartEvent.RaiseEvent();
				respawnEvent.RaiseEvent(respawn);
				Respawn(player);
				state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
				Timer = Timer + Time.deltaTime;
				break;
            case State.GAME_WIN:
                gameWinUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.GAME_OVER:
				gameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
			default:
				break;
		}

		healthUI.text = $"HEALTH:\n {health.value.ToString()}/100";
	}

	public void OnStartGame()
	{
		state = State.START_GAME;
	}

	public void OnPlayerDead()
	{
		state = State.GAME_OVER;
	}

	public void OnAddPoints(int points)
	{
		print(points);
	}

    public void OnToTitle()
    {
        if (gameOverUI.activeSelf == true)
        {
            gameOverUI.SetActive(false);
        }
        else if (gameWinUI.activeSelf == true)
        {
            gameWinUI.SetActive(false);
        }
        state = State.TITLE;
    }

	public void GameWin()
	{
		state = State.GAME_WIN;
	}

	public void DamageHealth(float damage)
	{
		health.value -= damage;
	}

	public void Respawn(GameObject p)
	{ 
		p.transform.position = respawn.transform.position;
	}
}
