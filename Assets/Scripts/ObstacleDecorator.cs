using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Basic concrete decorator class. Decorates a BaseObstacle with a coin pattern
TODO: Should add an abstact decorator parent class that defines the behavior of all child decorators
*/
public class ObstacleDecorator : BaseObstacle
{
    /* A block consisting of one obstacle base and any number of coin pattern decorators
    */
    protected BaseObstacle baseObstacle;

    /*
    Replacement constructor for MonoBehaviours. Must be called upon Instantiating
    an ObstacleDecorator. Initializes the base obstacle.
    */
    public void Init(BaseObstacle obstacle)
    {
        this.baseObstacle = obstacle;
    }

    public override void Spawn()
    {
        if (baseObstacle == null) {
            Debug.Log("baseObstacle is null");
        } else {
            // Spawn the existing block
            baseObstacle.Spawn();
            
            // Decorate existing block by instantiating this coin pattern
            Instantiate(gameObject, transform.position, Quaternion.identity);
        }
    }
}
