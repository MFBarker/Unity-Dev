using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("GameUI")]
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;

    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;

    public enum State
    { 
        TITLE,
        START,
        PLAY_GAME,
        GAME_OVER
    }

    [Header("Variables")]
    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

    public int Lives { 
        get { return lives; } 
        set { 
            lives = value; 
            livesUI.text = lives.ToString(); 
        } 
    }

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            timerUI.text = string.Format("{0:F1",timer); //timer.ToString()
        }
    }

    private void OnEnable()
    {
        scoreEvent.Subscribe(OnAddPoints);
    }

    private void OnDisable()
    {
        scoreEvent.Unsubscribe(OnAddPoints);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START:
                titleUI.SetActive(false);
                Timer = 60;
                Lives = 3;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0) 
                {
                    state = State.GAME_OVER;
                }
                break;
            case State.GAME_OVER:
                break;
        }

        healthUI.value = health.value / 100.0f;
    }



    public void OnStartGame() 
    {
        state = State.START;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }

}//
