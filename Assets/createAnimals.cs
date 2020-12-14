using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAnimals : MonoBehaviour
{
    // my animals
    public List<GameObject> firstAnimal = new List<GameObject>(); // CAT
    public GameObject animalOne;
    public int animalOneTotal;
    public int NumOne;

    // other animals
    public List<GameObject> secondAnimal = new List<GameObject>(); // Pred
    public GameObject animalTwo;
    public int animalTwoTotal;
    public int NumTwo;

    // other animals
    public List<GameObject> thirdAnimal = new List<GameObject>(); // BEE
    public GameObject animalThree;
    public int animalThreeTotal;
    public int NumThree;

    // other animals
    public List<GameObject> fourthAnimal = new List<GameObject>(); // FOX
    public GameObject animalFour;
    public int animalFourTotal;
    public int NumFour;

    public List<GameObject> fifthAnimal = new List<GameObject>(); // RABBIT
    public GameObject animalFive;
    public int animalFiveTotal;
    public int NumFive;

    public List<GameObject> sixthAnimal = new List<GameObject>(); // BUTTERFLY
    public GameObject animalSix;
    public int animalSixTotal;
    public int NumSix;

    public List<GameObject> seventhAnimal = new List<GameObject>(); // TURTLE
    public GameObject animalSeven;
    public int animalSevenTotal;
    public int NumSeven;

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
            GameObject animal2 = Instantiate(animalTwo, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            secondAnimal.Add(animalTwo);
        }

        for (int i = 0; i < animalThreeTotal; i++)
        {
            GameObject animal3 = Instantiate(animalThree, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            thirdAnimal.Add(animalThree);
        }

        for (int i = 0; i < animalFourTotal; i++)
        {
            GameObject animal4 = Instantiate(animalFour, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            fourthAnimal.Add(animalFour);
        }

        for (int i = 0; i < animalFiveTotal; i++)
        {
            GameObject animal5 = Instantiate(animalFive, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            fifthAnimal.Add(animalFive);
        }

        for (int i = 0; i < animalSixTotal; i++)
        {
            GameObject animal6 = Instantiate(animalSix, new Vector3(Random.Range(10f, terrain.cols), Random.Range(20f, 25f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            sixthAnimal.Add(animalSix);
        }

        for (int i = 0; i < animalSevenTotal; i++)
        {
            GameObject animal7 = Instantiate(animalSeven, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)), Quaternion.identity);
            seventhAnimal.Add(animalSeven);
        }

        NumOne = firstAnimal.Count;
        NumTwo = secondAnimal.Count;
        NumThree = thirdAnimal.Count;
        NumFour = fourthAnimal.Count;
        NumFive = fifthAnimal.Count;
        NumSix = sixthAnimal.Count;
        NumSeven = seventhAnimal.Count;

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
            circleOfLife(animalTwo, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)));
        }
        if (NumSeven < animalSevenTotal)
        {
            circleOfLife(animalSeven, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)));
        }
        if (NumFour < animalFourTotal)
        {
            circleOfLife(animalFour, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)));
        }
        if (NumFive < animalFiveTotal)
        {
            circleOfLife(animalFive, new Vector3(Random.Range(10f, terrain.cols), Random.Range(5f, 5f), Random.Range(10f, terrain.rows)));
        }
        if (NumSix < animalSixTotal)
        {
            circleOfLife(animalSix, new Vector3(Random.Range(10f, terrain.cols), Random.Range(20f, 25f), Random.Range(10f, terrain.rows)));
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
        else if (animal.name == "Fox(Clone)" || animal.name == "Fox")
        {
            if (NumFour < animalFourTotal)
            {
                GameObject b = Instantiate(animal, position, Quaternion.identity);
                fourthAnimal.Add(b);
                NumFour++;
            }
        }
        else if (animal.name == "Rabbit(Clone)" || animal.name == "Rabbit")
        {
            if (NumFive < animalFiveTotal)
            {
                GameObject b = Instantiate(animal, position, Quaternion.identity);
                fifthAnimal.Add(b);
                NumFive++;
            }
        }
        else if (animal.name == "Butterfly(Clone)" || animal.name == "Butterfly")
        {
            if (NumSix < animalSixTotal)
            {
                GameObject b = Instantiate(animal, position, Quaternion.identity);
                sixthAnimal.Add(b);
                NumSix++;
            }
        }
        else if (animal.name == "Turtle(Clone)" || animal.name == "Turtle")
        {
            if (NumSeven < animalSevenTotal)
            {
                GameObject b = Instantiate(animal, position, Quaternion.identity);
                seventhAnimal.Add(b);
                NumSeven++;
            }
        }

    }
}
