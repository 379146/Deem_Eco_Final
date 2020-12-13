using UnityEngine;

public class SightCollider : MonoBehaviour
{
    private Cat cat;

    private void Start()
    {
        cat = GetComponentInParent<Cat>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            cat.isNearPlayer = true;
            cat.playerL = collision.transform.position;
        }
        if (collision.CompareTag("Pred"))
        {
            collision.GetComponent<Pred_AI>().SlowDown();
            cat.isNearPlayer = true;
            cat.playerL = collision.transform.position;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            cat.isNearPlayer = false;
        }
        else if (collision.CompareTag("Pred"))
        {
            cat.isNearPlayer = false;
        }
    }
}
