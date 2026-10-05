using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject EndPoint;

    private List<GameObject> Enemies = new List<GameObject>();

    void SpawnEnemy()
    {
        GameObject Enemy = Instantiate(EnemyPrefab, SpawnPoint.transform.position, Quaternion.identity);
        Enemies.Add(Enemy);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
        if(Enemies.Count >= 1)
        {
            //Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, EndPoint.transform.position, (float)0.01);
            for(int i = Enemies.Count - 1; i >= 0; i--)
            {
                GameObject enemy = Enemies[i];
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, EndPoint.transform.position, (float)0.01);
                if(enemy.transform.position == EndPoint.transform.position)
                {
                    Destroy(enemy);
                }
            }
        }
    }
}
