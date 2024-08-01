using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
Stores game score and defines score incrementation. Intended to be used just once
per scene.
*/
public class ScoreTracker : MonoBehaviour
{
    /* Player's total score. Cannot be modified by other classes.
    */
    public int score {get; private set;}

    /* Global event for updating the game score. Event invokation takes an instance
    of a ScoreTracker.
    */
    public UnityEvent<ScoreTracker> OnScoreChange;

    /*
    Increases game score by the given value and invokes the global OnScoreChange event
    */
    public void IncrementScore(int value)
    {
        score += value;
        OnScoreChange.Invoke(this);
    }
}
