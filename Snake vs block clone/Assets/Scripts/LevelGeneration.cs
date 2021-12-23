using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform Plane;
    public GameObject badCube;
    public GameObject Health;
    public BadCube CubeBad;
    public Health HealthCount;

    private void Awake()
    {
        CubeBad.maxHealth = 5;
        HealthCount.maxHealth = 5;

        Quaternion Rotation = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Vector3 CubePosition = new Vector3(3 - j * 2, 25 + 8 * i, -0.5f);
                    GameObject Cube = Instantiate(badCube, CubePosition, Rotation);
                    Cube.transform.parent = Plane;
                    CubeBad.maxHealth += 2;
                }
            }
            int healthLocation = Random.Range(0, 5);
            Vector3 HealthPosition = new Vector3(healthLocation * 2 - 4, 22 + 8 * i, -0.5f);
            GameObject Sphere = Instantiate(Health, HealthPosition, Rotation);
            Sphere.transform.parent = Plane;
            HealthCount.maxHealth += 1;
        }
    }

}
