using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines standard properties and behaviour of base obstacles.
*/
public class StandardObstacle : BaseObstacle
{
    /* Array of prefabs for all coin patterns that are compatible with this obstacle type
    */
    public GameObject[] validCoinPatternPrefabs;

    /* Stores percentage chance of generating the corresponding coin pattern
    */
    public float[] coinPatternWeights = {};

    /* Numeric ID for this obstacle type
    */
    protected int obstacleID = 0;
    public ObstacleInfo obsInfo;

    protected float obsYMin = -3;     // Range of spawn y-values for obstacles
    protected float obsYMax = 3;
    protected float offset = 0;       // Offset to center Split Obstacle
    protected float spawnX = 20;      // X position of right-hand obstacle spawn
    protected float spawnY = 0;       // Height of obstacle spawn

    /* 
    Spawns this obstacle at a default location. 
    */
    public override void Spawn()
    {
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);

    }

    /*
    Initializes/updates ObstacleInfo object for this obstacle based on private properties
    */
    private void SetObstacleInfo()
    {
        if (obsInfo == null) {
            obsInfo = ScriptableObject.CreateInstance<ObstacleInfo>();
        }
        obsInfo.Init(obstacleID, offset, spawnX, spawnY);
    }

    /*
    Returns a random coin pattern decorator that is compatible with this base obstacle
    */
    public override GameObject GetRandomCoinPattern()
    {
        int coinIndex = Utils.GetRandWeightedIndex(coinPatternWeights);
        Debug.Log("Selecting coin pattern index " + coinIndex);
        return validCoinPatternPrefabs[coinIndex];
    }

     /*
    Returns a list of obstacle info
    */
    public override ObstacleInfo GetObstacleInfo()
    {
        SetObstacleInfo();
        return obsInfo;
    }
}