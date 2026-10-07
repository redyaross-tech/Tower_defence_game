using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private Button BuildButton;
    [SerializeField] private GameObject BuildMenu;
    private int toggle = 0;
    public void MoveBuildMenuUP()
    {
        BuildMenu.transform.position = Vector3.MoveTowards(BuildMenu.transform.position, new Vector3(BuildMenu.transform.position.x, 140, 0), 5f);
    }

    public void MoveBuildMenuDOWN()
    {
        BuildMenu.transform.position = Vector3.MoveTowards(BuildMenu.transform.position, new Vector3(BuildMenu.transform.position.x, -150, 0), 5f);
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
        BuildButton.onClick.AddListener(() =>
        {
            Toggle();
        });
    }
}
