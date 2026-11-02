using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour
{
    [SerializeField] private GameObject BladerPrefab;

    public static string CurrentTower;
    private List<GameObject> BuildButtons = new List<GameObject>();
    private (double, double) TowerPos;

    //переменная для башен
    private GameObject Tower;

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
        Debug.Log("place");
        TowerPos = MarkerScript.MousePos();
        Object BuidedTower = Instantiate(Tower, new Vector3((float)TowerPos.Item1, (float)TowerPos.Item2, 0f), Quaternion.identity);
    }
}
