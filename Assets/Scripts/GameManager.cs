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
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() 
    {
        // Subscribe relevant internal functions to game events
        OnGameOver += GameOver;
    }

    void OnDisable() 
    {
        // Unsubscribe relevant internal functions to game events
        OnGameOver -= GameOver;
    }

    // Test method
    private void GameOver() 
    {
        Debug.Log("Game Over!!");
        Time.timeScale = 0;     // Freeze gameplay
    }

    // Triggers the OnGameOver event. Can be called by other classes
    public static void TriggerOnGameOver() {
        OnGameOver?.Invoke();
    }
}
