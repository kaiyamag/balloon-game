using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
SpawnManager.cs
Kaiya Magnuson 2024

Manages the destruction of out-out-bounds obstacles.
*/

public class DestroyOutOfBounds : MonoBehaviour
{
    private float boundaryX = -20;     // Left-hand scene boundary

    void Update()
    {
        if (transform.position.x < boundaryX) {
            Destroy(gameObject);
        }
    }
}
