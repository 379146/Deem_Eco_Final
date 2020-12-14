using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    public Rigidbody body;
    private bool jumpCool = false;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.mass = 50;
    }
    private void Update()
    {
        body.AddForce(new Vector3(Random.Range(-4f, 4f), 0f, Random.Range(-4f, 4f))); //Randomized acceleration

        //Consistent jump pattern
        if (jumpCool == false)
        {
            StartCoroutine(JumpCounter());
            jumpCool = true;
        }
    }
    //Makes the bunny "jump"
    IEnumerator JumpCounter()
    {
        yield return new WaitForSeconds(1f); //Random range of seconds to wait for rabbit's hop
        body.position += Vector3.up * 1f; //Change this to make the jump higher or lower
        jumpCool = false;
    }
}

