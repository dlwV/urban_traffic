using System.Collections;
using UnityEngine;

public class carGeneration : MonoBehaviour
{
    public GameObject[] carArr = new GameObject[3];
    public float minSpawnTime = 0.1f, maxSpawnTime = 1f;

    private Vector3[] spawnPositions;

    private void Start()
    {
        spawnPositions = new Vector3[] {
            new Vector3(13.56f, 0, -93f), //rotate 0
            new Vector3(9f, 0, -93f),
            new Vector3(4.04f, 0, -93f),
            new Vector3(-1.28f, 0, 93f), // rotate 180
            new Vector3(-6.19f, 0, 93f),
            new Vector3(-10.8f, 0, 93f),
            new Vector3(-93f, 0, -2.3f), // rotate 90
            new Vector3(-93f, 0, -6.96f),
            new Vector3(-93f, 0, -11.84f),
            new Vector3(93f, 0, 2.869999f), //rotate 270
            new Vector3(93f, 0, 7.75f),
            new Vector3(93f, 0, 12.41f)
        };

        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject car = carArr[Random.Range(0, 3)];
            Vector3 randomPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
            switch (randomPosition.z) {
                case 93f:
                    Instantiate(car, randomPosition, Quaternion.Euler(0, 180, 0));
                    break;
                case -93f:
                    Instantiate(car, randomPosition, Quaternion.Euler(0, 0, 0));
                    break;
            }
            switch (randomPosition.x)
            {
                case 93f:
                    Instantiate(car, randomPosition, Quaternion.Euler(0, 270, 0));
                    break;
                case -93f:
                    Instantiate(car, randomPosition, Quaternion.Euler(0, 90, 0));
                    break;
            }

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
