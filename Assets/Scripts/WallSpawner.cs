using System.Collections;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] walls;

    public float wallVisibleTime = 4f;

    public float delayBetweenWalls = 2f;

    private Vector3[] startPositions;

    private Quaternion[] startRotations;

    private int currentWall = -1;

    void Start()
    {
        startPositions = new Vector3[walls.Length];
        startRotations = new Quaternion[walls.Length];

        for (int i = 0; i < walls.Length; i++)
        {
            startPositions[i] = walls[i].transform.position;
            startRotations[i] = walls[i].transform.rotation;

            walls[i].SetActive(false);
        }

        StartCoroutine(SpawnWalls());
    }

    IEnumerator SpawnWalls()
    {
        while (true)
        {
            SpawnRandomWall();

            yield return new WaitForSeconds(wallVisibleTime);

            HideCurrentWall();

            yield return new WaitForSeconds(delayBetweenWalls);
        }
    }

    void SpawnRandomWall()
    {
        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, walls.Length);
        }
        while (randomIndex == currentWall);

        currentWall = randomIndex;

        GameObject wall = walls[randomIndex];

        wall.transform.position = startPositions[randomIndex];
        wall.transform.rotation = startRotations[randomIndex];

        wall.SetActive(true);

        Rigidbody rb = wall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void HideCurrentWall()
    {
        if (currentWall >= 0)
        {
            walls[currentWall].SetActive(false);
        }
    }
}