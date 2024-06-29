using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Abstract parent class defining the behaviour of a base obstacle (e.g., the
overarching object type of any base or decorated block). Child classes of BaseObstacle
define the behavior of unique, concrete obstacles.
*/
public abstract class BaseObstacle : MonoBehaviour
{
    /*
    Instantiates the gameObject tied to this BaseObstacle child class
    */
    public abstract void Spawn();

    /*
    Returns a random coin pattern decorator that is compatible with this base obstacle
    */
    public abstract GameObject GetRandomCoinPattern();
}
