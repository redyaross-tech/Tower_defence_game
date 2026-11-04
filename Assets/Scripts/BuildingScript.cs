using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingScript : MonoBehaviour
{
    [SerializeField] private GameObject BladerPrefab;
    [SerializeField] private GameObject BladerIcon;

    public static string CurrentTower;
    private List<GameObject> BuildButtons = new List<GameObject>();
    private (double, double) TowerPos;

    //переменная для башен
    private GameObject Tower;
    private GameObject TowerIcon;

    void Start()
    {
        GetBuildButtons();
        BuidColorMarkerTest();
    }

    void Update()
    {
        TowerSelect();
        if (Input.GetMouseButtonDown(0) && Tower != null)
        {
            Build();
        }
    }

    void GetBuildButtons()
    {
        BuildButtons.AddRange(GameObject.FindGameObjectsWithTag("BuildButton"));
    }

    void BuidColorMarkerTest()
    {
        foreach (GameObject button in BuildButtons)
        {
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                CurrentTower =  button.GetComponent<BuildingTypes>().Tower.ToString();
                Instantiate(BladerIcon, new Vector3(0, 0, 0), Quaternion.identity);
                Debug.Log("click");
            });
        }
    }

    //присвоение переменной значение префаба
    void TowerSelect()
    {
        switch (CurrentTower)
        {
            case "Remove":
                Tower = null;
                break;
            case "Cannon":
                Tower = null;
                break;
            case "Laser":
                Tower = null;
                break;
            case "Blader":
                Tower = BladerPrefab;
                TowerIcon = BladerIcon;
                break;
            case "FlameThrower":
                Tower = null;
                break;
            default:
                break;
        }
    }

    void Build()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("liehutagshgnejk;lihgtrweilorghtwewgftilohyergfuohyerfqougyqeurgyf g estg uwehargbouywaergbfvku3ywarq 20 q43b78t75803qtg 7q432p5y78toq38u457rtgkqaj3h5rgfouqa3ry4glfvb gaejr.,voseyufvgijwysrdtg");
            TowerPos = MarkerScript.MousePos();
            Object BuidedTower = Instantiate(Tower, new Vector3((float)TowerPos.Item1, (float)TowerPos.Item2, 0f), Quaternion.identity);
        }
    }
}
