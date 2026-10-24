using UnityEngine;
using UnityEngine.InputSystem;

public class MarkerScript : MonoBehaviour
{
    [SerializeField] private GameObject Marker;
    private string tower;
    private Color color;
    
    //Определение положения мыши относительно игровых координат и округление для создания сетки
    (double, double) MousePos(){
        Vector2 MousePos = Mouse.current.position.ReadValue();
        Vector3 WorldMousePos = Camera.main.ScreenToWorldPoint(MousePos);

        double MousePosX = System.Math.Round(WorldMousePos.x);
        double MousePosY = System.Math.Round(WorldMousePos.y);
        
        return (MousePosX, MousePosY);
    }

    void ColorChanger()
    {
        tower = BuildingScript.CurrentTower;
        switch (tower)
        {
            case "Remove":
                color = new Color32(255, 0 , 0, 255);
                break;
            case "Cannon":
                color = new Color32(255, 255 , 0, 255);
                break;
            case "Laser":
                color = new Color32(0, 255, 0, 255);
                break;
            case "Blader":
                color = new Color32(0, 0, 255, 255);
                break;
            case "FlameThrower":
                color = new Color32(255, 128, 0, 255);
                break;
            default:
                break;
        }
        Marker.GetComponent<SpriteRenderer>().color = color;
        
    }

    void Update()
    {
        //Обработка маркера
        (double, double) MousePosDouble = MousePos();
        Marker.transform.position = new Vector3((float)MousePosDouble.Item1, (float)MousePosDouble.Item2, 0f);
        
        ColorChanger();
    }
}
