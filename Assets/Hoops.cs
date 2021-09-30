using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoops : MonoBehaviour
{
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Update()
    {
        // Basic Moment
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left 
        }
    }

    void FixedUpdate()
    {
        // Changing Directions Randomly is now 
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //Change Directions
        }
    }
}
