using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public GameObject BasicEnemyPrefab;
    [SerializeField] public GameObject SpawnPoint;
    [SerializeField] public GameObject EndPoint;

    //Список активных врагов
    static private List<GameObject> Enemies = new List<GameObject>();
    //Список ключевых точек
    private List<GameObject> KeyPoints = new List<GameObject>();

    void Start()
    {
        GetKeyPoints();
        //InvokeRepeating("SpawnEnemy", 0f, GlobalSettings.EnemySpawnRate);
    }

    void FixedUpdate()
    {
        if(Enemies.Count >= 1)
        {
            MoveEnemies();
        }
    }

    //Создание врага и добавление его в список
    public IEnumerator SpawnEnemyCoroutine(GameObject prefab, int amount, float delay)
    {
        for(int i = 0; i <= amount; i++){
        yield return new WaitForSeconds(delay);
        GameObject Enemy = Instantiate(prefab, SpawnPoint.transform.position, Quaternion.identity);
        //ID следующей ключевой точки
        Enemy.GetComponent<NextPointData>().NextPointID = 0;
        Enemies.Add(Enemy);
        }
    }

    //Нахождение всех ключевых точек на карте
    void GetKeyPoints()
    {
        KeyPoints.AddRange(GameObject.FindGameObjectsWithTag("KeyPoint"));
        KeyPoints = KeyPoints.OrderBy(k => k.GetComponent<KeyPointID>().KeyPointId).ToList();
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
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, KeyPoints[enemy.GetComponent<NextPointData>().NextPointID].transform.position, enemy.GetComponent<EnemyData>().Speed / 10);
                if(enemy.transform.position == KeyPoints[enemy.GetComponent<NextPointData>().NextPointID].transform.position && enemy.GetComponent<NextPointData>().NextPointID < KeyPoints.Count - 1)
                {
                    enemy.GetComponent<NextPointData>().NextPointID++;
                }
                if(enemy.transform.position == EndPoint.transform.position)
                {
                    Destroy(enemy);
                    Enemies.RemoveAt(i);
                }
            }
        }
    }
}
