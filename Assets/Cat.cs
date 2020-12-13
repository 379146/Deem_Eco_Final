using System.Collections;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public bool isNearPlayer { get; set; } = false;
    public Vector3 playerL;

    [Tooltip("The minimum distance from the player where the cat will begin to flee")]
    //[SerializeField] private float sightRadius = 1f;
    private float fleeDuration = 2f;

    private MoveController moveController;
    private bool canMove = true;

    bool HasInteractedWithPlayer = false;
    bool ReadyToMoveAgain = true;

    float xInput;
    float zInput;

    public float counter = 5f;
    private float downtime;


    protected void Start()
    {
        moveController = GetComponent<MoveController>();

        downtime = Random.Range(3f,6f);
    }

    private void Update()
    {

        if (!HasInteractedWithPlayer && ReadyToMoveAgain && canMove) // Dwight
            WalkAround();

        if (canMove)
            FleeIfNearPlayer();

    }

    private void FixedUpdate()
    {
        counter -= 0.01f;

        if (counter <= 0)
        {
            HasInteractedWithPlayer = false;
            moveController.moveSpeed = 3f;
        }
    }

    protected void FleeIfNearPlayer()
    {
        if (isNearPlayer)
        {

            moveController.SetMoveInput(0, 0);
            moveController.moveSpeed = 8f;

            if (playerL.x > gameObject.transform.position.x)
            {
                xInput = -1f;
            }
            if (playerL.x < gameObject.transform.position.x)
            {
                xInput = 1f;
            }
            if (playerL.z > gameObject.transform.position.z)
            {
                zInput = -1f;
            }
            if (playerL.z < gameObject.transform.position.z)
            {
                zInput = 1f;
            }

            HasInteractedWithPlayer = true; // Dwight
            counter = 5f;
            

            moveController.SetMoveInput(xInput, zInput);

            StartCoroutine(FleeForDuration());
        }
    }

    private IEnumerator FleeForDuration()
    {
        yield return new WaitForSeconds(fleeDuration);
        moveController.SetMoveInput(0, 0);
    }

    public void WalkAround() // Dwight
    {

        ReadyToMoveAgain = false;

        int RandX = Random.Range(-1, 2);
        int RandY = Random.Range(-1, 2);

        Invoke("StopAfterShortTime", downtime);

        moveController.SetMoveInput(RandX, RandY);

    }

    public void ResetWalker()
    {

        ReadyToMoveAgain = true;

    }

    public void StopAfterShortTime()
    {

        moveController.SetMoveInput(0, 0);
        Invoke("ResetWalker", 2f);

    }

}