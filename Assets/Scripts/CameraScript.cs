using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] private float dragSpeed = 0.5f;

    private Vector3 DragOrigin;
    void ZoomOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            MainCamera.orthographicSize -= scroll * 5;
            MainCamera.orthographicSize = Mathf.Clamp(MainCamera.orthographicSize, 2, 20);
        }
    }

    void CameraDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragOrigin = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = DragOrigin - MainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference * dragSpeed;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            transform.position = new Vector3(0, 0, -10);
        }
    }
    void Update()
    {
        CameraDrag();
        ZoomOut();
    }
}