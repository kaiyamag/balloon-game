using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Defines the behavior of a basic Obstacle2 (split obstacle)
*/
public class ConcreteObstacle2 : BaseObstacle
{
    /* Array of prefabs for all coin patterns that are compatible with this obstacle type
    */
    public GameObject[] validCoinPatternPrefabs;

    /* Stores percentage chance of generating the corresponding coin pattern
    */
    public float[] coinPatternWeights = {50, 50};   

    /* Numeric ID for this obstacle type
    */
    protected int obstacleID = 2;
    public ObstacleInfo obsInfo;

    private float obsYMin = -3;     // Range of spawn y-values for obstacles
    private float obsYMax = 3;
    private float offset = -7;      // Offset to center Split Obstacle
    private float spawnX = 20;      // X position of right-hand obstacle spawn
    private float spawnY = -7;      // Height of obstacle spawn

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
    Instantiates this gameObject
    */
    public override void Spawn()
    {
        // Get random height
        int randHeight = (int) Random.Range(obsYMin, obsYMax);
        spawnY = offset + randHeight;
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        Instantiate(gameObject, spawnPos, Quaternion.identity);

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