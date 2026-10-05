using UnityEngine;
using UnityEngine.InputSystem;

public class MarkerScript : MonoBehaviour
{
    [SerializeField] private GameObject Marker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    (double, double) MousePos(){
        Vector2 MousePos = Mouse.current.position.ReadValue();
        Vector3 WorldMousePos = Camera.main.ScreenToWorldPoint(MousePos);

        double MousePosX = System.Math.Round(WorldMousePos.x);
        double MousePosY = System.Math.Round(WorldMousePos.y);
        
        //if(MousePosX){}
        //Debug.Log($"{MousePosX}, {MousePosY}");
        return (MousePosX, MousePosY);
    }

    // Update is called once per frame
    void Update()
    {
        (double, double) MousePosDouble = MousePos();
        Marker.transform.position = new Vector3((float)MousePosDouble.Item1, (float)MousePosDouble.Item2, 0f);
    }
}
