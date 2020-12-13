using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    private Vector3 location, velocity, acceleration;
    private float topSpeed;
    private void Start()
    {
        gameObject.tag = "Butterfly";
        location = transform.position;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
        topSpeed = 1F;
    }
    // Update is called once per frame
    void Update()
    {
        acceleration = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        // Normilize the acceletation
        acceleration.Normalize();
        // Now we can scale the magnitude as we wish!
        acceleration *= Random.Range(5f, 10f);

        // Speeds up the mover
        velocity += acceleration * Time.deltaTime; // Time.deltaTime is the time passed since the last frame.

        // Limit Velocity to the top speed
        velocity = Vector2.ClampMagnitude(velocity, topSpeed);

        // Moves the mover
        location += velocity * Time.deltaTime;


        // Updates the GameObject of this movement
        transform.position = new Vector3(location.x, location.y, location.z);
    }
}

