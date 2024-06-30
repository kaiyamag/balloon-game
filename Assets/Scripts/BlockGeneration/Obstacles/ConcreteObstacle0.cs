using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ConcreteObstacle0.cs
Kaiya Magnuson 2024

Defines the behavior of a basic Obstacle0 (empty obstacle). Inherits from StandardObstacle
*/
public class ConcreteObstacle0 : StandardObstacle
{
    /*
    Initialize obstacle properties from parent class 
    */
    void Start()
    {
        obstacleID = 0;
        offset = 0;       // Offset to center Split Obstacle
        spawnX = 20;      // X position of right-hand obstacle spawn
        spawnY = 0;       // Height of obstacle spawn
    }

    /* 
    Spawns this obstacle at a default location. 
    */
    public override void Spawn()
    {
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);

    }
}