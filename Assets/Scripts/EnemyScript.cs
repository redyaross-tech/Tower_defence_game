using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject EndPoint;

    //Список активных врагов
    private List<GameObject> Enemies = new List<GameObject>();
    //Список ключевых точек
    private List<GameObject> KeyPoints = new List<GameObject>();

    //Создание врага и добавление его в список
    void SpawnEnemy()
    {
        GameObject Enemy = Instantiate(EnemyPrefab, SpawnPoint.transform.position, Quaternion.identity);
        //ID следующей ключевой точки
        Enemy.GetComponent<ItemIdentifier>().NextPointID = 0;
        Enemies.Add(Enemy);
    }

    //Нахождение всех ключевых точек на карте
    void GetKeyPoints()
    {
        KeyPoints.AddRange(GameObject.FindGameObjectsWithTag("KeyPoint"));
        KeyPoints = KeyPoints.OrderBy(k => k.GetComponent<ItemIdentifier>().KeyPointID).ToList();
    }

    //Обновление позиции врагов и удаление их из списка при достижении конечной точки
    void MoveEnemies()
    {
        if(Enemies.Count >= 1)
        {
            //Обработка всех врагов
            //Отсчёт в обратном порядке так как обычный приводит к ошибке отсутствуещего элемента в списке
            for(int i = Enemies.Count - 1; i >= 0; i--)
            {
                GameObject enemy = Enemies[i];
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, KeyPoints[enemy.GetComponent<ItemIdentifier>().NextPointID].transform.position, GlobalSettings.Step);
                if(enemy.transform.position == KeyPoints[enemy.GetComponent<ItemIdentifier>().NextPointID].transform.position && enemy.GetComponent<ItemIdentifier>().NextPointID < KeyPoints.Count - 1)
                {
                    enemy.GetComponent<ItemIdentifier>().NextPointID++;
                }
                if(enemy.transform.position == EndPoint.transform.position)
                {
                    Destroy(enemy);
                    Enemies.RemoveAt(i);
                }
            }
        }
    }
    void FixedUpdate()
    {
        if(Enemies.Count >= 1)
        {
            MoveEnemies();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    void Start()
    {
        GetKeyPoints();
        InvokeRepeating("SpawnEnemy", 0f, 0.5f);
    }
}
