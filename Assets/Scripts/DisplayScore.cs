using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
DisplayScore.cs
Kaiya Magnuson, 06/2024

Stores game score and handles updates to score UI
*/
public class DisplayScore : MonoBehaviour
{
    public GameObject scoreObject;  // Reference to text UI element
    private static TMP_Text text;   // Reference to actual TextMeshPro component
    private static int score;
   
    void Start()
    {
        // Get reference to TMP component
        text = scoreObject.GetComponent<TextMeshProUGUI>();

        // Initialize score
        score = 0;
        text.text = "Score: " + score.ToString();
    }

    void Update()
    {

    }

    public static void HandleOnScoreChange(int scoreInc)
    {
        score += scoreInc;
        text.text = "Score: " + score.ToString();
    }
}
