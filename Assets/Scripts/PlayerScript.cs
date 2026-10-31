using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerScript : MonoBehaviour
{
    //Указать все префабы для башен
    [SerializeField] private GameObject BladerPrefab;
    private (double, double) TowerPos;
    private string tower;
    //переменная для башен
    private GameObject towerToPlace;
    void Build()
    {
        Debug.Log("place");
        TowerPos = MarkerScript.MousePos();
        Object BuidedTower = Instantiate(towerToPlace, new Vector3((float)TowerPos.Item1, (float)TowerPos.Item2, 0f), Quaternion.identity);
    }
    //присвоение переменной значение префаба
    void TowerSelect()
    {
        tower = BuildingScript.CurrentTower;
        switch (tower)
        {
            case "Remove":
                towerToPlace = null;
                break;
            case "Cannon":
                towerToPlace = null;
                break;
            case "Laser":
                towerToPlace = null;
                break;
            case "Blader":
                towerToPlace = BladerPrefab;
                break;
            case "FlameThrower":
                towerToPlace = null;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TowerSelect();
        if (Input.GetMouseButtonDown(0) && towerToPlace != null)
        {
            Build();
        }
    }
}
