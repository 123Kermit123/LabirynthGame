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

    public int Points = 0;

    public int RedKeys, GreenKeys, BlueKeys = 0;

    [Header("Keybinds")]
    public KeyCode PauseKey;
    public KeyCode PickupStats;
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

    // Update is called once per frame
    void Update()
    {
        MenuPanel.SetActive(GamePaused);

        PauseCheck();

        PickupStatistics();
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
        Cursor.visible = false;

        Debug.Log("Game Resumed");
        Time.timeScale = 1;

        GamePaused = false;
    }

    public void AddPoints(int POINTS)
    {
        Points += POINTS;
    }

    public void AddTime(int TIMETOADD)
    {
        TimeToEnd += TIMETOADD;
    }

    public void FreezeTime(int TIME)
    {
        CancelInvoke(nameof(Stoper));
        InvokeRepeating(nameof(Stoper), TIME, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.RedKey)
        {
            RedKeys++;
        }
        if (color == KeyColor.GreenKey)
        {
            GreenKeys++;
        }
        if (color == KeyColor.BlueKey)
        {
            BlueKeys++;
        }
    }

    void PickupStatistics()
    {
        if (Input.GetKeyDown(PickupStats))
        {
            Debug.Log($"Current TimeToEnd: {TimeToEnd}");
            Debug.Log($"Keys: red: {RedKeys}, green: {GreenKeys}, blue: {BlueKeys}");
            Debug.Log($"Points: {Points}");
        }
    }
}
