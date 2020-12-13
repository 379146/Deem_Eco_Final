using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pred_AI : MonoBehaviour
{

    //public float predspeed = 0.015f;
    public GameObject PreyONE;
    private MoveController moveController;

    float xInput;
    float zInput;

    // Start is called before the first frame update
    void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PreyONE != null)
        {
            if (gameObject.transform.position.x > PreyONE.transform.position.x)
            {
                xInput = -1f;
            }
            else if (gameObject.transform.position.x < PreyONE.transform.position.x)
            {
                xInput = 1f;
            }
            if (gameObject.transform.position.z > PreyONE.transform.position.z)
            {
                zInput = -1f;
            }
            else if (gameObject.transform.position.z < PreyONE.transform.position.z)
            {
                zInput = 1f;
            }

            moveController.SetMoveInput(xInput, zInput);

        }


    }

    public void Hunt(GameObject collision)
    {
            PreyONE = collision.gameObject;
    }

    public void SlowDown()
    {

        PreyONE = null;
        moveController.SetMoveInput(0f, 0f);

    }

}
