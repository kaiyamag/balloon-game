using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    public int score {get; private set;}
    public UnityEvent<ScoreTracker> OnScoreChange;

    public void IncrementScore()
    {
        score++;
        OnScoreChange.Invoke(this);
    }
}
