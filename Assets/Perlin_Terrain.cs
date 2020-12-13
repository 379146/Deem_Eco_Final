using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin_Terrain : MonoBehaviour
{

    public List<Vector3> terrainAray = new List<Vector3>();
    public GameObject terrainCube;

    public int cols, rows;

    public Color color1, color2, color3, color4, color5;

    // Start is called before the first frame update
    void Start()
    {
        GameObject terrain = new GameObject();
        terrain.name = "Terrain";

        float xOff = 0;
        for (int i = 0; i < cols; i++)
        {

            float yOff = 0;

            for (int j = 0; j < rows; j++)
            {

                // you can play with the last float in each statement to change the terrain
                float theta = ExtensionMethods.Remap(Mathf.PerlinNoise(xOff, yOff), 0f, 1f, 0f, 2f); // height of the waves and valleys

                float theta2 = ExtensionMethods.Remap(Mathf.PerlinNoise(xOff,yOff), 0f, 1f, 0f, 2f); // frequency of waves and valleys

                //this is handling rotaion of each cube / soil object
                Quaternion perlinRotation = new Quaternion();
                Vector3 perlinVectors = new Vector3(Mathf.Cos(theta2), Mathf.Sin(theta2), 0f);
                perlinRotation.eulerAngles = perlinVectors * 100f;

                // now we place them 
                terrainCube = Instantiate(terrainCube, new Vector3(i, theta, j), perlinRotation);
                terrainCube.transform.SetParent(terrain.transform);
                Renderer terrainRenderer = terrainCube.GetComponent<Renderer>();
                terrainRenderer.material.SetColor("_Color", colorTerrain(terrainCube.transform.position));

                yOff += .06f;
            
            }

            xOff += 0.06f;
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color colorTerrain(Vector3 terrainCubePosition)
    {

        Color terrainColor = new Vector4(1f, 1f, 1f);

        if (terrainCubePosition.y >= 0f && terrainCubePosition.y <= 2f)
        {
            terrainColor = color1;
        }
        else if (terrainCubePosition.y >= 2f && terrainCubePosition.y <= 3.5f)
        {
            terrainColor = color2;
        }
        else if (terrainCubePosition.y >= 3.5f && terrainCubePosition.y <= 4.5f)
        {
            terrainColor = color3;
        }
        else if (terrainCubePosition.y >= 4.5f && terrainCubePosition.y <= 5.5f)
        {
            terrainColor = color4;
        }
        else if (terrainCubePosition.y >= 5.5f && terrainCubePosition.y <= 10f)
        {
            terrainColor = color5;
        }

        return terrainColor;
    
    }
    

}
