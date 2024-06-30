using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Container class for obstacle properties including ID, vertical offset, and spawn X-Y positions
*/
[System.Serializable]
public class ObstacleInfo : ScriptableObject
{
    public int id;                  // A unique numeric ID for this obstacle type
    public float offset;            // Vertical offset required to center the obstacle prefab
    public float spawnX, spawnY;    // XY spawn positions of the obstacle

    /*
    Sets all obstacle properties. Must be called like a constructor before using an instance of ObstacleInfo
    */
    public void Init(int id, float offset, float spawnX, float spawnY)
    {
        this.id = id;
        this.offset = offset;
        this.spawnX = spawnX;
        this.spawnY = spawnY;
    }
}
