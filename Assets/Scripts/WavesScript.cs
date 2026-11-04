using System;
using UnityEngine;

public class WavesScript : MonoBehaviour
{
    [SerializeField] GameObject BasicEnemyPrefab;
    private Coroutine spawnCoroutine;
    void Start()
    {
        EnemyScript SpawnEnemy = GetComponent<EnemyScript>();
        StartCoroutine(SpawnEnemy.SpawnEnemyCoroutine(BasicEnemyPrefab, 100, 1));
    }
}
