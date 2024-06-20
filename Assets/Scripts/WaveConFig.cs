// using System.Collections;
// using System.Collections.Generic;
// using System.Security;
// using UnityEngine;
// using UnityEngine.Experimental.AI;

// [CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
// public class WaveConFig : ScriptableObject
// {
//     [Header("Enemy's nature")]
//     [SerializeField] List<GameObject> enemyPrefabs;
//     [SerializeField] Transform pathPrefab;
//     [SerializeField] float moveSpeed = 2f;

//     [Header("Time Spawn")]
//     [SerializeField] float timeBetweenSpawnEnemy;
//     [SerializeField] float spawnTimeVariance = 0f;
//     [SerializeField] float minimumSpawnTime = 0.2f;


//     public Transform GetStartingPoint()
//     {
//         return pathPrefab.GetChild(0);
//     }

//     public List<Transform> GetWayPoints()
//     {
//         List<Transform> wavePoints = new List<Transform>();
//         foreach (Transform child in pathPrefab)
//         {
//             wavePoints.Add(child);
//         }
//         return wavePoints;
//     }

//     public int GetEnemyCount()
//     {
//         return enemyPrefabs.Count;
//     }

//     public GameObject GetEnemyPrefab(int index)
//     {
//         return enemyPrefabs[index];
//     }

//     public float GetMoveSpeed()
//     {
//         return moveSpeed;
//     }

//     public float GetRandomSpawnTime()
//     {
//         float spawnTime = Random.Range(timeBetweenSpawnEnemy - spawnTimeVariance, timeBetweenSpawnEnemy + spawnTimeVariance);
//         return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
//     }

// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }


}
