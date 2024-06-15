using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public GameObject scoreObject;  // Reference to text UI element
    private static TMP_Text text;   // Reference to actual TextMeshPro component
   
    void Start()
    {
        text = scoreObject.GetComponent<TextMeshProUGUI>();
        text.text = "Score:";
    }

    void Update()
    {

    }

    public static void HandleOnScoreChange(int scoreInc)
    {
        text.text = "Score: " + scoreInc.ToString();
    }
}
