using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{

    
    float mSpeed = .5f;
    //sets the max and min of the world
    public int maxPosX;
    public int maxPosZ;
    public int minPosX;
    public int minPosZ;
    //set the gameobject

    public GameObject bunnyGo;
    public bool bunnyDestroy = false;
    Rigidbody body;
    float bunnyHop;
    //controls the movement of the game object
    float z;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        //give the object gravity
        body = GetComponent<Rigidbody>();
        Renderer bunnyColor = bunnyGo.GetComponent<Renderer>();
        bunnyColor.material = new Material(Shader.Find("Diffuse"));
        bunnyColor.material.color = Color.grey;
        body.isKinematic = false;
        body.useGravity = true;
        //body.position = new Vector3(22f, 10.5f, 30f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // CheckEdges();

        if (body.position.y <= 0 && bunnyDestroy == false)
        {
            
            bunnyDestroy = true;
            CheckEdges();
            Debug.Log("Bunny has been destroyed");
        }

        if (bunnyDestroy == true)
        {
            body.transform.position = new Vector3(Random.Range(0, 100), 10, Random.Range(0, 100));
            bunnyDestroy = false;
            CheckEdges();
        }
        else
        {
            CheckEdges();
        }
    }

    public void CheckEdges()
    {
        // moves the bunny around and checks to make sure it stays in the world

       

         if ((body.position.x <= maxPosX) || (body.position.z <= maxPosZ))
        {
            float x = body.position.x - .05f; //* Time.deltaTime;
            float y = body.position.y + .2f; //* Time.deltaTime;
            float z = body.position.z - .05f; // * Time.deltaTime;
            body.position = new Vector3(x, y, z);
            Debug.Log("Is hitting max border");
            

        }

        else if ((body.position.x <= minPosX) || (body.position.z <= minPosZ))
        {
            float x = body.position.x + .05f; //* Time.deltaTime;
            float y = body.position.y + .2f; //* Time.deltaTime;
            float z = body.position.z + .05f; // * Time.deltaTime;
            body.position = new Vector3(x, y, z);
            Debug.Log("Is hitting min border");
            
        }

        else if ((body.position.x <= minPosX) || (body.position.z <= maxPosZ))
        {
            float x = body.position.x + .05f; //* Time.deltaTime;
            float y = body.position.y + .2f; //* Time.deltaTime;
            float z = body.position.z - .05f; // * Time.deltaTime;
            body.position = new Vector3(x, y, z);
            
        }

        else if ((body.position.z <= minPosZ) || (body.position.x <= maxPosX))
        {
            float x = body.position.x - .05f; //* Time.deltaTime;
            float y = body.position.y + .2f; //* Time.deltaTime;
            float z = body.position.z + .05f; // * Time.deltaTime;
            body.position = new Vector3(x, y, z);
            
        }

        

        else
        {
             float x = body.position.x - .05f ; //* Time.deltaTime;
             float y = body.position.y + .2f; //* Time.deltaTime;
             float z = body.position.z - .05f; // * Time.deltaTime;
           
            body.position = new Vector3(x, y, z);
            Debug.Log("Just Moving");
        }
        
    }

}
