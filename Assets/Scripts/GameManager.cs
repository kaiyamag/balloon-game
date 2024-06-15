using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
Manages high-level game events including game over and scroll speed
*/
public class GameManager : MonoBehaviour
{
    // ~~~~ ACTIONS ~~~~
    public static event Action OnGameOver;      // Game event triggered when game is over
    public static event Action<int> OnScoreChange;  

    // ~~~~ MENUS ~~~~
    public GameObject gameOverMenu;     // UI element to show on game over

    // ~~~~ PROPERTIES ~~~~
    public float scrollSpeed;   // Movement speed of obstacles

    void Start()
    {
        // Initialize properties
        Time.timeScale = 1;

        // Initialize UI menus
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable() 
    {
        // Subscribe relevant internal & external functions to game events
        OnGameOver += HandleGameOver;
        OnScoreChange += DisplayScore.HandleOnScoreChange;
    }

    void OnDisable() 
    {
        // Unsubscribe relevant internal & external functions to game events
        OnGameOver -= HandleGameOver;
        OnScoreChange += DisplayScore.HandleOnScoreChange;
    }

    // Handles game over case
    private void HandleGameOver() 
    {
        Debug.Log("Game Over!!");
        Time.timeScale = 0;             // Freeze gameplay
        gameOverMenu.SetActive(true);   // Show restart menu
    }

    // Triggers the OnGameOver event. Can be called by other classes
    public static void TriggerOnGameOver() {
        OnGameOver?.Invoke();
    }

    // Triggers the OnScoreChange event. Can be called by other classes
    public static void TriggerOnScoreChange(int scoreInc) {
        OnScoreChange?.Invoke(scoreInc);
    }
}
