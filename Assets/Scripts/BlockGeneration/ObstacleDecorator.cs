using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Abstract parent class for all block decorators (coin patterns)
*/
public abstract class ObstacleDecorator : BaseObstacle
{
    /*
    Replacement constructor for MonoBehaviours. Must be called upon Instantiating
    an ObstacleDecorator. Initializes the base obstacle.
    */
    public abstract void Init(BaseObstacle obstacle);
    
}
