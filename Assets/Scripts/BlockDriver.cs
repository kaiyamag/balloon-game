using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The driver class that constructs and decorates blocks
public class BlockDriver : MonoBehaviour
{
    // void Start()
    // {
    //     BaseObstacle b = ConstructBlock
    // }
    public BaseObstacle ConstructBlock(GameObject obstaclePrefab, GameObject decoratorPrefab)
    {
        Debug.Log("Constructing block");
        // Instantiate the base obstacle
        // prefab must be of type that contains the BaseObstacle script
        //GameObject obstacleObject = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        BaseObstacle baseObstacle = obstaclePrefab.GetComponent<BaseObstacle>();
        if (baseObstacle == null) {
            Debug.LogError("baseObstacle is null **");
        }

        // Decorate the obstacle as needed
        // For example, adding a visual effect or modifying properties
        //ObstacleDecorator decoratedObstacle = new ObstacleDecorator(baseObstacle);      // CHANGED from `SomeConcreteDecorator`
        //ObstacleDecorator decoratedObstacle = gameObject.AddComponent<ObstacleDecorator>();
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
