using UnityEngine;

public class SightColliderForPred : MonoBehaviour
{
    public Pred_AI Pred;

    private void Start()
    {
        Pred = GetComponentInParent<Pred_AI>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Cat"))
        {
            Pred.Hunt(collision.gameObject);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Cat"))
        {
            Pred.SlowDown();
        }
    }
}
