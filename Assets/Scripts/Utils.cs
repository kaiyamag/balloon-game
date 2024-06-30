using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Container for global static helper functions
*/
public class Utils
{
    /*
    Returns the index of a percentage-weighted random obstacle
    */
    public static int GetRandWeightedIndex(float[] weights)
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

}
