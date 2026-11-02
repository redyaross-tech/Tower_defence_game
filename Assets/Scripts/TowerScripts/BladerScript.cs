using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class BladerScript : MonoBehaviour
{
    [SerializeField] GameObject center;
    [SerializeField] GameObject blade1;
    [SerializeField] GameObject blade2;
    [SerializeField] GameObject blade3;
    [SerializeField] GameObject blade4;
    private List<GameObject> Blades = new List<GameObject>();
    private float rotationSpeed = 100f;

    void Start()
    {
        Blades.Add(blade1);
        Blades.Add(blade2);
        Blades.Add(blade3);
        Blades.Add(blade4);
    }

    void FixedUpdate()
    {
        for(int i = Blades.Count - 1; i >= 0; i--)
        {
            GameObject blade = Blades[i];
            blade.transform.RotateAround(center.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
        }
    }
}
