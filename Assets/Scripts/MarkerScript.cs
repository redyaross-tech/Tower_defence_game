using UnityEngine;
using UnityEngine.InputSystem;

public class MarkerScript : MonoBehaviour
{
    [SerializeField] private GameObject Marker;
    [SerializeField] private Sprite BladerIcon;

    private string tower;
    private Sprite towerToPlace;

    //Определение положения мыши относительно игровых координат и округление для создания сетки
    static public (double, double) MousePos(){
        Vector2 MousePos = Mouse.current.position.ReadValue();
        Vector3 WorldMousePos = Camera.main.ScreenToWorldPoint(MousePos);

        double MousePosX = System.Math.Round(WorldMousePos.x);
        double MousePosY = System.Math.Round(WorldMousePos.y);
        
        return (MousePosX, MousePosY);
    }

    void Start()
    {
        Marker.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
    }

    void Update()
    {
        //Обработка маркера
        (double, double) MousePosDouble = MousePos();
        Marker.transform.position = new Vector3((float)MousePosDouble.Item1, (float)MousePosDouble.Item2, 0f);

        ColorChanger();
    }

    void ColorChanger()
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
                towerToPlace = BladerIcon;
                break;
            case "FlameThrower":
                towerToPlace = null;
                break;
            default:
                break;
        }
        Marker.GetComponent<SpriteRenderer>().sprite = towerToPlace;
    }
}
