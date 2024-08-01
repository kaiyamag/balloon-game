using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
BlockDriver.cs
Kaiya Magnuson 2024

Manages the construction of a block consisting of a base obstacle and a decorating coin pattern
*/
public class BlockDriver : MonoBehaviour
{
    /* Returns a BaseBlock constructed from an obstacle prefab (must implement BaseBlock)
    and a coin pattern prefab (must implement ObstacleDecorator)
    */
    public BaseBlock ConstructBlock(GameObject obstaclePrefab)
    {
        // Get a reference to class of parent type BaseBlock
        StandardObstacle baseObstacle = obstaclePrefab.GetComponent<StandardObstacle>();
        if (baseObstacle == null) {
            Debug.LogError("baseObstacle is null **");
        }

        // Decorate the obstacle with a coin pattern
        GameObject decPrefab = baseObstacle.GetRandomCoinPattern();
        ObstacleDecorator decoratedObstacle = decPrefab.GetComponent<ObstacleDecorator>();

        if (decoratedObstacle == null) {
            Debug.LogError("decoratedObstacle is null");
        } else {
            decoratedObstacle.Init(baseObstacle);
        }

        return decoratedObstacle;
    }
}
