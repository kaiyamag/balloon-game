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
    public BaseObstacle ConstructBlock(GameObject obstaclePrefab, GameObject decoratorPrefab)
    {
        // Get a reference to class of parent type BaseObstacle
        BaseObstacle baseObstacle = obstaclePrefab.GetComponent<BaseObstacle>();
        if (baseObstacle == null) {
            Debug.LogError("baseObstacle is null **");
        }

        // Decorate the obstacle with a coin pattern
        GameObject decoratorObject = Instantiate(decoratorPrefab, transform.position, Quaternion.identity);
        ObstacleDecorator decoratedObstacle = decoratorObject.GetComponent<ObstacleDecorator>();

        if (decoratedObstacle == null) {
            Debug.LogError("decoratedObstacle is null");
        } else {
            decoratedObstacle.Init(baseObstacle);
        }

        return decoratedObstacle;
    }
}
