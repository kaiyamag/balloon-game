using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Manages the construction of a block consisting of a base obstacle and a decorating coin pattern
*/
public class BlockDriver : MonoBehaviour
{
    /* Returns a BaseObstacle constructed from an obstacle prefab (must implement BaseObstacle)
    and a coin pattern prefab (must implement ObstacleDecorator)
    */
    public BaseObstacle ConstructBlock(GameObject obstaclePrefab)
    {
        // Get a reference to class of parent type BaseObstacle
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
