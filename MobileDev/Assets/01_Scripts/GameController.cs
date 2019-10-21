using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [Header("Objects to serialize")]
    [SerializeField, Tooltip("Reference to the tile to spawn")] Transform tile;
    [SerializeField, Tooltip("Reference to the obstacle to spawn")] Transform obstacle;

    [Header("Serializable variables")]
    [SerializeField, Tooltip("Where the first tile should be placed")] Vector3 startPoint = new Vector3(0, 0, -5);
    [SerializeField, Tooltip("How many tiles should be created in advance"), Range(1, 15)] int initSpawnNum = 10;
    [SerializeField, Tooltip("How many tiles to spawn initially with no obstacles"), Range(1, 15)] int initNoObstacles = 4;

    //Private
    Vector3 nextTileLocation;
    Quaternion nextTileRotation;

    private void Start()
    {
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; i++)
        {
            SpawnNextTile(i >= initNoObstacles);   
        }
    }

    public void SpawnNextTile(bool spawnObstacles)
    {
        Transform newTile = Instantiate(tile, nextTileLocation, nextTileRotation);
        Transform nextTile = newTile.Find("Next Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;

        if (!spawnObstacles)
            return;

        List<GameObject> obstacleSpawnPoints = new List<GameObject>();

        foreach (Transform child in newTile)
        {
            if (child.CompareTag("ObstacleSpawn"))
            {
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }

        if (obstacleSpawnPoints.Count > 0)
        {
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];

            var spawnPos = spawnPoint.transform.position;

            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);
            newObstacle.SetParent(spawnPoint.transform);
        }
    }
}