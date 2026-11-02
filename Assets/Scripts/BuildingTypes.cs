using UnityEngine;

public class BuildingTypes : MonoBehaviour
{
    public enum TowerName
    {
        Remove,
        Cannon,
        Laser,
        Blader,
        FlameThrower
    }

    [SerializeField] public TowerName Tower;
}
