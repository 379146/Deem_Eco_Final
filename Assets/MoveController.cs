using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Vector3 MoveVector
    {
        get { return moveVector; }
        set
        {
            moveVector = value;
        }
    }

    public float moveSpeed = 3f;

    // Components
    private Rigidbody rb;

    // Move input variables
    private float xInput = 0, zInput = 0;
    private Vector3 moveVector; //do not use, instead use capital MoveVector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateMoveVector();
    }

    public void SetMoveInput(float x, float z)
    {
        xInput = x;
        zInput = z;
    }

    private void UpdateMoveVector()
    {
        MoveVector = new Vector3(xInput, 0f, zInput);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveVector * moveSpeed * Time.fixedDeltaTime);
    }

}