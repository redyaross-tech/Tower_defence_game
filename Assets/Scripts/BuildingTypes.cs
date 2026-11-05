using UnityEngine;

public class BuildingTypes : MonoBehaviour
{
    public enum TowerName
    {
        Remove,
        Cannon,
        Laser,
        Blader,
        Flamethrower
    }

    [SerializeField] public TowerName Tower;
}
