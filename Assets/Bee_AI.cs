using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_AI : MonoBehaviour
{

    // The basic properties of an oscillator class
    public Vector3 velocity, angle, amplitude;

    // The window limits
    private Vector3 maximumPos;

    void Start()
    {

        maximumPos = new Vector3(1f,1f,1f);
        //Debug.Log(maximumPos);
        angle = Vector3.zero;

        velocity = new Vector3(Random.Range(-0.05f, .05f), Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
        amplitude = new Vector3(Random.Range(-maximumPos.x / 2, maximumPos.x / 2), Random.Range(-maximumPos.y / 2, maximumPos.y / 2), Random.Range(-maximumPos.z / 2, maximumPos.z / 2));

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Each oscillator object oscillating on the x-axis
        float x = Mathf.Sin(angle.x) * amplitude.x;
        //Each oscillator object oscillating on the y-axis
        float y = Mathf.Sin(angle.y) * amplitude.y;
        //Each oscillator object oscillating on the Z-axis
        float z = Mathf.Sin(angle.z) * amplitude.z;
        //Add the oscillator's velocity to its angle
        angle += velocity;
        //Move the oscillator
        gameObject.transform.Translate(new Vector3(x, y, z) * Time.deltaTime);
        //Debug.Log(gameObject.name + ": " + x + " " + y + " " + z);

    }

}
