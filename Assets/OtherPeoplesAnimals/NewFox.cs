using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFox : MonoBehaviour
{
    public bool timeRunning = false;
    public float timeLeft = 5f;
    public bool jumpCool = false;

    private createAnimals engine;

    public float speed = 5f; //Change this to adjust speed of the fox
    private Rigidbody body;
    public GameObject rabbit;
    public GameObject engineG;

    Vector3 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>(); //Add a rigidbody to the fox in the inspector
        rabbit = GameObject.FindGameObjectWithTag("Rabbit"); //On your rabbit GameObject, be sure to also add a "Rabbit" tag
        engineG = GameObject.FindGameObjectWithTag("Script"); //On your Animal Spawner Script, be sure to add a "Script" tag
        engine = engineG.GetComponent<createAnimals>(); //This is required to grab your spawner's script and use its methods
    }

    // Update is called once per frame
    void Update()
    {
        //Looks at the rabbit where it is in the ecosystem
        transform.LookAt(rabbit.transform);
        lookDirection = ( rabbit.transform.position - transform.position);

        //Applies force to the fox to move towards the rabbit
        body.AddForce(lookDirection * speed);

        Vector2 difference = rabbit.transform.position - transform.position;
        float dist = difference.magnitude;
        //If the fox is close enough, the rabbit is placed somewhere else and the fox will "eat" the rabbit
        if (dist <= 1)
        {
            //Method added to Animal Engine spawner, used to respawn rabbit////////////////////////************************
            Destroy(rabbit.gameObject);
            engine.NumFive--;
            timeRunning = true;
        }
        //If the fox gets a rabbit, they will stop for 5 seconds
        if (timeRunning == true)
        {

            Invoke("thing", 5f);

            //if (timeLeft > 0)
            //{
            //    body.velocity = new Vector3(0, 0, 0);
            //    timeLeft -= 0.1f;
            //}
            //else
            //{
            //    timeLeft = 5f; //Time reset to 5 seconds
            //    timeRunning = false;
            //    rabbit = GameObject.FindGameObjectWithTag("Rabbit");
            //    body.AddForce(lookDirection * speed);
            //}
        }
        //If this is true, a countdown starts for the fox to jump
        if (jumpCool == false)
        {
            StartCoroutine(JumpCounter());
            jumpCool = true;
        }
    }


    void thing()
    {

        timeLeft = 5f; //Time reset to 5 seconds
        timeRunning = false;
        rabbit = GameObject.FindGameObjectWithTag("Rabbit");
        body.AddForce(lookDirection * speed);

    }


    //Makes the fox "jump"
    IEnumerator JumpCounter()
    {
        yield return new WaitForSeconds(Random.Range(2f,6f)); //Random range of seconds to wait for a fox's jump
        body.position += Vector3.up * 2f; //Change this to make the jump higher or lower
        Vector3 lookDirection = (rabbit.transform.position - transform.position).normalized;
        body.AddForce(lookDirection * speed);
        jumpCool = false;
    }
}
