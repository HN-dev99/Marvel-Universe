
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool isGoodEnemy;
    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    [SerializeField] bool isBossEnemy;


    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            if (isBossEnemy)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject instanceBoss = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    Rigidbody2D rbBoss = instanceBoss.GetComponent<Rigidbody2D>();
                    if (rbBoss != null)
                    {
                        float angleOffset = (i - 1) * 15f;
                        Vector3 direction = Quaternion.Euler(0, 0, angleOffset) * transform.up;

                        rbBoss.velocity = direction * projectileSpeed;
                    }
                }
            }
            else
            {
                GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);

                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                if (rb != null && !isGoodEnemy)
                {
                    rb.velocity = transform.up * projectileSpeed;
                }
                else if (rb != null && isGoodEnemy)
                {
                    rb.velocity = -transform.up * projectileSpeed;
                }

                audioPlayer.PlayerShootingClip();

                Destroy(instance, projectileLifetime);
            }

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                            baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
