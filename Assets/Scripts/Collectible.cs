using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == "HotAirBalloon")
        {
            ScoreTracker st = collisionInfo.gameObject.GetComponent<ScoreTracker>();
            if (st != null)
            {
                Debug.Log("Collision between " + collisionInfo.gameObject.name + " and " + gameObject.name);
                st.IncrementScore();
                gameObject.SetActive(false);
            } else {
                Debug.LogError("ScoreTracker for " + collisionInfo.gameObject.name + " is null!");    
            }
        }
    }
}
