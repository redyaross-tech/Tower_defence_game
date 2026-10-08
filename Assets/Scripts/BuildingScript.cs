using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour
{
    private List<GameObject> BuildButtons = new List<GameObject>();

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
                
            });
        }
    }

    void Start()
    {
        GetBuildButtons();
    }
}
