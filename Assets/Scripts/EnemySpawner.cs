
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("List Wave")]
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] List<WaveConfigSO> waveBoss;

    [Header("Time Beetween Waves")]
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] float timeBetweenWavesBoss = 5f;
    [SerializeField] bool isLooping;

    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {

                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);

                foreach (WaveConfigSO child in waveBoss)
                {
                    if (currentWave == child)
                    {
                        yield return new WaitForSeconds(timeBetweenWavesBoss);
                    }
                }
            }
        }
        while (isLooping);
    }
}

