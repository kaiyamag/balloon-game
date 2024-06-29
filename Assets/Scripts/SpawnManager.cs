using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
SpawnManager.cs
Kaiya Magnuson 2024

Manages the instantiation of random obstacles.
*/


public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;   // Stores obstacle prefabs. Filled in editor
    public GameObject coin;         // Reference to coin objects
    public float[] obstacleWeights = {75, 25};  // Stores percentage chance of generating the corresponding obstacle in the `obstacles` array
    public float[] coinPatternWeights = {33, 33, 34};   // Stores percentage chance of generating the corresponding coin pattern
    private float spawnX = 20;      // X position of right-hand obstacle spawn
    private float startDelay = 2;   // Number of seconds before starting obstacle spawn
    private float spawnInterval = 2;   // Number of seconds between obstacles spawning
    private float obsYMin = -3;     // Range of spawn y-values for obstacles
    private float obsYMax = 3;
    private float offset = -7;      // Offset to center Split Obstacle
    private float centerHeight = 4.5f; // Offset to edges of Center Obstacle
    private float coinSpacing = 0.75f;   // X distance between coins in a line
    private float horizCoinOffset = 2.5f;   // X offset distance to center horizontal lines in obstacles
    private int horizLineCount = 6;     // Number of coins in a horizontal line

    //--------------------------------
    //public Block myBlock;

    //DEBUG
    //private int[] testTally = {0,0};

    void Start()
    {
        // myBlock = ScriptableObject.CreateInstance<CenterObstacle>();
        // myBlock.Init(10);
        // Block x = ScriptableObject.CreateInstance<CoinSingle>();
        // x.Init(myBlock);

        // Block b = gameObject.AddComponent<CO>();
        // b.Spawn();

        // x.Spawn();

        //StartInvoke();
    }
    void Update()
    {

    }

    /*
    // Spawns a new random obstacle
    void SpawnRandomObstacle() 
    {
        // Pick random obstacle
        int index = Random.Range(0, obstacles.Length);

        // Pick random y-position for applicable obstacles
        float yPos;
        if (index == 0) {
            yPos = offset + Random.Range(obsYMin, obsYMax);
        }
        else {
            yPos = 0;
        }
        Vector3 spawnPos = new Vector3(spawnX, yPos, 0);

        // Instantiate random object
        Instantiate(obstacles[index], spawnPos, obstacles[index].transform.rotation);
    }

    void SpawnRandomBlock()
    {
        // Pick random obstacle
        int obstacleIndex = GetRandWeightedIndex(obstacleWeights);

        // Pick random coin layout
        int coinPatternIndex = GetRandWeightedIndex(coinPatternWeights);
        //int coinPatternIndex = 2;

        // Pick random y-position for applicable obstacles
        float yPos = 0;

        // ---- Split Obstacle ----
        if (obstacleIndex == 0) {
            // Get random height
            yPos = offset + Random.Range(obsYMin, obsYMax);

            // Instantiate coins
            InstantiateCoinPattern(coinPatternIndex, new Vector3(spawnX, yPos - offset, 0));
        }
        // ---- Center Obstacle ----
        else if (obstacleIndex == 1) {
            yPos = 0;

            int sign = 1;
            if (Random.Range(0, 100) < 50) {
                sign = -1;
            }
            float centerOffset = sign * centerHeight;

            // Instantiate coins
            // TODO: restrict types of patterns generated with this obstacle
            InstantiateCoinPattern(coinPatternIndex, new Vector3(spawnX, centerOffset, 0));
        }
        Vector3 spawnPos = new Vector3(spawnX, yPos, 0);

        // Instantiate random object
        Instantiate(obstacles[obstacleIndex], spawnPos, obstacles[obstacleIndex].transform.rotation);
    }

    private void InstantiateCoinPattern(int index, Vector3 startPos) 
    {
        // ---- Single coin ----
        if (index == 0) {
            Debug.Log("Spawn single coin at " + startPos);
            Instantiate(coin, startPos, coin.transform.rotation);
        }
        // ---- Horizontal line ----
        else if (index == 1) {
            Debug.Log("Spawn horizontal line starting at " + startPos);
            Vector3 tempPos = startPos;
            tempPos.x += horizCoinOffset;
            for (int i = 0; i < horizLineCount; i++) {
                tempPos.x -= coinSpacing;
                Instantiate(coin, tempPos, coin.transform.rotation);
            }
        }
        // ---- Left positive arc ----
        else if (index == 2) {
            Debug.Log("Spawn left positive arc starting at " + startPos);
            Vector3 tempPos = startPos;
            tempPos.x += horizCoinOffset;
            for (int i = 0; i < horizLineCount; i++) {
                tempPos.x -= coinSpacing;
                float steepness = 0.3f;     // Arc steepness
                tempPos.y = (float) System.Math.Pow(i * steepness, 2) + startPos.y;
                Instantiate(coin, tempPos, coin.transform.rotation);
            }
        }
    }
    
    */

    /*
    Returns the index of a percentage-weighted random obstacle
    */
    private int GetRandWeightedIndex(float[] weights)
    {
        int result = -1;    // TODO: Maybe change this to a usable index just in case
        int x = Random.Range(0, 100);     // Random is exclusive on the last bound
        float lowerBound = 0;
        //Debug.Log("Starting random. x = " + x);
        for (int i = 0; i < weights.Length; i++) {
            //Debug.Log("-- Comparing obstacleWeights[" + i + "] = " + obstacleWeights[i] + ", lowerBound = " + lowerBound);
            if (x < weights[i] + lowerBound) {
                //Debug.Log("--result = " + i);
                //testTally[result] = testTally[result] + 1;
                //PrintArray(testTally);
                result = i;
                return result;
            }

            lowerBound += weights[i];
        }
        //testTally[result] = testTally[result] + 1;
        //Debug.Log("Done, result = " + result);
        //PrintArray(testTally);
        return result;
    }

    // private void PrintArray(int[] array) {
    //     string text = "[";
    //     foreach (int x in array) {
    //         text += x.ToString() + ", ";
    //     }
    //     text += "]";
    //     Debug.Log(text);
    // }

    void StartInvoke() {
        InvokeRepeating("SpawnRandomBlock", startDelay, spawnInterval);

        //InvokeRepeating("GetRandObstacle", 0, 0.2f); 
    }
}
