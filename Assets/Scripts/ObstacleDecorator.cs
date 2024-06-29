using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Decorator class that adds additional functionality to obstacles
public /*abstract*/ class ObstacleDecorator : BaseObstacle
{
    protected BaseObstacle baseObstacle;

    public void /*ObstacleDecorator*/Init(BaseObstacle obstacle)
    {
        this.baseObstacle = obstacle;
    }

    public override void Spawn()
    {
        if (baseObstacle == null) {
            Debug.Log("baseObstacle is null");
        } else {
            baseObstacle.Spawn(); // Call the wrapped obstacle's Spawn method
            Debug.Log("You got decorated ! :D");
            // Add decoration behavior here
        }
    }
}
