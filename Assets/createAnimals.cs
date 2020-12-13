using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAnimals : MonoBehaviour
{
    // my animals
    public List<GameObject> firstAnimal = new List<GameObject>();
    public GameObject animalOne;
    public int animalOneTotal;
    public int NumOne;

    // other animals
    public List<GameObject> secondAnimal = new List<GameObject>();
    public GameObject animalTwo;
    public int animalTwoTotal;
    public int NumTwo;

    // other animals
    public List<GameObject> thirdAnimal = new List<GameObject>();
    public GameObject animalThree;
    public int animalThreeTotal;
    public int NumThree;

    // other animals
    public List<GameObject> fourthAnimal = new List<GameObject>();
    public GameObject animalfour;
    public int animalFourTotal;

    public Perlin_Terrain terrain;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < animalOneTotal; i++)
        {
            GameObject animal = Instantiate(animalOne, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            firstAnimal.Add(animal);
        }

        for (int i = 0; i < animalTwoTotal; i++)
        {
            GameObject animal2 = Instantiate(animalTwo, new Vector3(Random.Range(2f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            secondAnimal.Add(animalTwo);
        }

        for (int i = 0; i < animalThreeTotal; i++)
        {
            GameObject animal3 = Instantiate(animalThree, new Vector3(Random.Range(2f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            thirdAnimal.Add(animalThree);
        }

        NumOne = firstAnimal.Count;
        NumTwo = secondAnimal.Count;
        NumThree = thirdAnimal.Count;

    }

    // Update is called once per frame
    void Update()
    {
        // checking to see how many are left then calling the spawner
        if (NumOne < animalOneTotal)
        {
            circleOfLife(animalOne, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 20f), Random.Range(10f, terrain.rows)));
        }
        if (NumTwo < animalTwoTotal)
        {
            circleOfLife(animalTwo, new Vector3(Random.Range(2f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)));
        }
        
    }

    public void circleOfLife(GameObject animal, Vector3 position)
    {


        if (animal.name == "Cat(Clone)" || animal.name == "Cat")
        {
            if (NumOne < animalOneTotal)
            {
                GameObject b = Instantiate(animal, position, Quaternion.identity);
                firstAnimal.Add(b);
                NumOne++;
            }
        }
        else if (animal.name == "Pred(Clone)" || animal.name == "Pred")
        {
            if (NumTwo < animalTwoTotal)
            {
                GameObject b = Instantiate(animal, position, Quaternion.identity);
                secondAnimal.Add(b);
                NumTwo++;
            }
        }

    }
}
