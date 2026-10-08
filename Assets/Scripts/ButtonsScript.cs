using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private Button BuildButton;
    private List<GameObject> BuildMenu = new List<GameObject>();
    private int toggle = 0;

    void GetBuildButtons()
    {
        BuildMenu.AddRange(GameObject.FindGameObjectsWithTag("BuildButton"));
    }
    public void MoveBuildMenuUP()
    {
        foreach (GameObject button in BuildMenu)
        {
            button.transform.position = Vector3.MoveTowards(button.transform.position, new Vector3(button.transform.position.x, 140, 0), 5f);
        }
    }

    public void MoveBuildMenuDOWN()
    {
        foreach (GameObject button in BuildMenu)
        {
            button.transform.position = Vector3.MoveTowards(button.transform.position, new Vector3(button.transform.position.x, -150, 0), 5f);
        }
    }
    void Toggle()
    {
        switch (toggle)
            {
                case 0:
                    toggle = 1;
                    break;
                case 1:
                    toggle = 0;
                    break;
            }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Toggle();
        }
        
        if (toggle == 1)
        {
            MoveBuildMenuUP();
        }
        else
        {
            MoveBuildMenuDOWN();
        }
    }

    void Start()
    {
        GetBuildButtons();
        BuildButton.onClick.AddListener(() =>
        {
            Toggle();
        });
    }
}
