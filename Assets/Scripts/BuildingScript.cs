using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour
{
    private List<GameObject> BuildButtons = new List<GameObject>();
    public static string CurrentTower;

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
                //Debug.Log(CurrentTower);
            });
        }
    }

    void Start()
    {
        GetBuildButtons();
        BuidColorMarkerTest();
    }
}
