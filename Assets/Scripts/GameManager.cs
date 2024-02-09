using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int TimeToEnd;

    public bool GamePaused;
    bool Endgame = false;
    public bool win;

    public GameObject MenuPanel;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (TimeToEnd <= 0)
        {
            TimeToEnd = 100;
        }

        InvokeRepeating(nameof(Stoper), 2, 1);
    }

    public KeyCode PauseKey;

    // Update is called once per frame
    void Update()
    {
        MenuPanel.SetActive(GamePaused);

        PauseCheck();
    }

    void Stoper()
    {
        TimeToEnd--;
        Debug.Log($"Time: {TimeToEnd}");

        if (TimeToEnd <= 0)
        {
            TimeToEnd = 0;
            Endgame = true;
        }
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            if (GamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;

        Debug.Log("Game Paused");
        Time.timeScale = 0;

        GamePaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Game Resumed");
        Time.timeScale = 1;

        GamePaused = false;
    }
}
