using UnityEngine;

public class BuildingTypes : MonoBehaviour
{
    [SerializeField] public TowerName Tower;

    public enum TowerName
    {
        Remove,
        Cannon,
        Laser,
        Blader,
        FlameThrower
    }
}
