using UnityEngine;
using UnityEngine.InputSystem;

public class MarkerScript : MonoBehaviour
{
    // [SerializeField] private GameObject BladerIcon;
    private GameObject Marker;

    //Определение положения мыши относительно игровых координат и округление для создания сетки
    static public (double, double) MousePos(){
        Vector2 MousePos = Mouse.current.position.ReadValue();
        Vector3 WorldMousePos = Camera.main.ScreenToWorldPoint(MousePos);

        double MousePosX = System.Math.Round(WorldMousePos.x);
        double MousePosY = System.Math.Round(WorldMousePos.y);
        
        return (MousePosX, MousePosY);
    }

    void GetMarker()
    {
        Marker = GameObject.FindGameObjectWithTag("Marker");
    }

    void Update()
    {
        GetMarker();
        if(Marker != null){
            //Обработка маркера
            (double, double) MousePosDouble = MousePos();
            Marker.transform.position = new Vector3((float)MousePosDouble.Item1, (float)MousePosDouble.Item2, 0f);
        }
    }
}
