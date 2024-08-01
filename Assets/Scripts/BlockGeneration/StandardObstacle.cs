using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
StandardObstacle.cs
Kaiya Magnuson 2024

Defines standard properties and behaviour of base obstacles.
*/
public class StandardObstacle : BaseBlock
{
    /* Array of prefabs for all coin patterns that are compatible with this obstacle type
    */
    public GameObject[] validCoinPatternPrefabs;

    /* Stores percentage chance of generating the corresponding coin pattern
    */
    public float[] coinPatternWeights = {};

    /* Numeric ID for this obstacle type
    */
    public ObstacleInfo obsInfo;

    /* 
    Spawns this obstacle at a default location. 
    */
    public override void Spawn()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);

        Debug.LogWarning("Using parent method :/ Make sure concrete obstacle class implements GetObstacleInfo");
    }

    /*
    Returns a random coin pattern decorator that is compatible with this base obstacle
    */
    public GameObject GetRandomCoinPattern()
    {
        int coinIndex = Utils.GetRandWeightedIndex(coinPatternWeights);
        Debug.Log("Selecting coin pattern index " + coinIndex);
        return validCoinPatternPrefabs[coinIndex];
    }

    /*
    Returns current ObstacleInfo object attached to this base obstacle
    */
    public override ObstacleInfo GetObstacleInfo() {
        return obsInfo;
    }

}
