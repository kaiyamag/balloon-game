using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFloat : MonoBehaviour
{
    public float risingSpeed = 5;
    public float fallingSpeed = 2;
    public float horizSpeed = 2;
    private float xBound = -16;
    private float yBound = -7;
    private float xStart = -8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Float up when up key pressed
        transform.Translate(transform.up * Input.GetAxis("Vertical") * Time.deltaTime * risingSpeed);

        // Fall due to gravity
        transform.Translate(-1 * transform.up * Time.deltaTime * fallingSpeed);

        // Return to center
        if (transform.position.x < xStart) {
            transform.Translate(transform.right * Time.deltaTime * horizSpeed);
        }

        // Check for out-of-bounds conditions
        if (transform.position.x < xBound || transform.position.y < yBound) {
            Debug.Log("Game Over");
        }
    }
}
