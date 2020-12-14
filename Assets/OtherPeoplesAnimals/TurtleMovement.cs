using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{


    float mSpeed = .5f;
    //sets the max and min of the world
    public int maxPosX;
    public int maxPosZ;
    public int minPosX;
    public int minPosZ;
    //set the gameobject

    //public GameObject turtleGo;
    public bool turtleDestroy = false;
    Rigidbody body;
  
    //controls the movement of the game object
    float z;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        //give the object gravity
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (body.position.y <= 0 && turtleDestroy == false)
        {

            turtleDestroy = true;
            CheckEdges();
            Debug.Log("Turtle has been destroyed");
        }

        if (turtleDestroy == true)
        {
            body.transform.position = new Vector3(Random.Range(0, 100), 10, Random.Range(0, 100));
             turtleDestroy = false;
            CheckEdges();
        }
        else
        {
            CheckEdges();
        }
    }

    public void CheckEdges()
    {
        // moves the turtle around and checks to make sure it stays in the world



        //if ((body.position.x <= maxPosX) || (body.position.z <= maxPosZ))
        //{
        //    float x = body.position.x - .04f; //* Time.deltaTime;
        //    float y = body.position.y + .02f; //* Time.deltaTime;
        //    float z = body.position.z - .04f; // * Time.deltaTime;
        //    body.position = new Vector3(x, y, z);
        //    Debug.Log("Is hitting max border");


        //}

        //else if ((body.position.x <= minPosX) || (body.position.z <= minPosZ))
        //{
        //    float x = body.position.x + .04f; //* Time.deltaTime;
        //    float y = body.position.y + .02f; //* Time.deltaTime;
        //    float z = body.position.z + .04f; // * Time.deltaTime;
        //    body.position = new Vector3(x, y, z);
        //    Debug.Log("Is hitting min border");

        //}

        //else if ((body.position.x <= minPosX) || (body.position.z <= maxPosZ))
        //{
        //    float x = body.position.x + .04f; //* Time.deltaTime;
        //    float y = body.position.y + .02f; //* Time.deltaTime;
        //    float z = body.position.z - .04f; // * Time.deltaTime;
        //    body.position = new Vector3(x, y, z);

        //}

        //else if ((body.position.z <= minPosZ) || (body.position.x <= maxPosX))
        //{
        //    float x = body.position.x - .04f; //* Time.deltaTime;
        //    float y = body.position.y + .02f; //* Time.deltaTime;
        //    float z = body.position.z + .04f; // * Time.deltaTime;
        //    body.position = new Vector3(x, y, z);

        //}



        //else
        //{
            float x = body.position.x - .04f; //* Time.deltaTime;
            float y = body.position.y + .02f; //* Time.deltaTime;
            float z = body.position.z - .04f; // * Time.deltaTime;

            body.position = new Vector3(x, y, z);
            Debug.Log("Just Moving");
        //}

    }

}
