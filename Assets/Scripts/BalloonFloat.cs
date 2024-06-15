using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BalloonFloat.cs
Kaiya Magnuson, 06/2024

Handles player input to control balloon motion
*/
public class BalloonFloat : MonoBehaviour
{
    public float risingSpeed = 5;   // Speed at which the balloon moves when controlled by player vertical input
    public float fallingSpeed = 2;  // Speed of balloon descent due to gravity
    public float horizSpeed = 2;    // Speed at which balloon returns to default x-posititon
    private float xBound = -16;     // Left-hand screen barrier
    private float yBound = -7;      // Lower screen barrier
    private float xStart = -8;      // Default balloon x-position

    void Start()
    {
        
    }

    void Update()
    {
        // Float up when up key pressed
        transform.Translate(transform.up * Input.GetAxis("Vertical") * Time.deltaTime * risingSpeed);

        // Fall due to gravity
        transform.Translate(-1 * transform.up * Time.deltaTime * fallingSpeed);

        // Return to center
        if (transform.position.x < xStart) {
            transform.Translate(transform.right * Time.deltaTime * horizSpeed);
        }

        // Check for out-of-bounds conditions
        if (transform.position.x < xBound || transform.position.y < yBound) {
            GameManager.TriggerOnGameOver();
        }
    }
}
