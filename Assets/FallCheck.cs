using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    private createAnimals Parent;

    private void Start()
    {
        Parent = GetComponentInParent<createAnimals>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Application.Quit();
        }
        if (collision.CompareTag("Pred"))
        {
            Parent.NumTwo--;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Cat"))
        {
            Parent.NumOne--;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Fox"))
        {
            Parent.NumFour--;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Rabbit"))
        {
            Parent.NumFive--;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Butterfly"))
        {
            Parent.NumSix--;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Turtle"))
        {
            Parent.NumSeven--;
            Destroy(collision.gameObject);
        }    
    }

}
