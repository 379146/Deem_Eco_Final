using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFox : MonoBehaviour
{
    public bool timeRunning = false;
    public float timeLeft = 5f;
    private bool jumpCool = false;

    private AnimalEngine engine;

    private float speed = 5f; //Change this to adjust speed of the fox
    private Rigidbody body;
    private GameObject rabbit;
    private GameObject engineG;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>(); //Add a rigidbody to the fox in the inspector
        rabbit = GameObject.FindGameObjectWithTag("Rabbit"); //On your rabbit GameObject, be sure to also add a "Rabbit" tag
        engineG = GameObject.FindGameObjectWithTag("Script"); //On your Animal Spawner Script, be sure to add a "Script" tag
        engine = engineG.GetComponent<AnimalEngine>(); //This is required to grab your spawner's script and use its methods
    }

    // Update is called once per frame
    void Update()
    {
        //Looks at the rabbit where it is in the ecosystem
        transform.LookAt(rabbit.transform);
        Vector3 lookDirection = ( rabbit.transform.position - transform.position);

        //Applies force to the fox to move towards the rabbit
        body.AddForce(lookDirection * speed);

        Vector2 difference = rabbit.transform.position - transform.position;
        float dist = difference.magnitude;
        //If the fox is close enough, the rabbit is placed somewhere else and the fox will "eat" the rabbit
        if (dist <= 1)
        {
            engine.NewSpawn(rabbit); //Method added to Animal Engine spawner, used to respawn rabbit
            timeRunning = true;
        }
        //If the fox gets a rabbit, they will stop for 5 seconds
        if (timeRunning == true)
        {
            if (timeLeft > 0)
            {
                body.velocity = new Vector3(0, 0, 0);
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 5f; //Time reset to 5 seconds
                timeRunning = false;
                body.AddForce(lookDirection * speed);
            }
        }
        //If this is true, a countdown starts for the fox to jump
        if (jumpCool == false)
        {
            StartCoroutine(JumpCounter());
            jumpCool = true;
        }
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
