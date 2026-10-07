using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Camera camera;
    void ZoomOut()
    {
        camera.orthographicSize = 6f;
    }
    void Update()
    {
        if(Screen.width / Screen.height != 16f / 9f)
        {
            ZoomOut();
        }
    }
}