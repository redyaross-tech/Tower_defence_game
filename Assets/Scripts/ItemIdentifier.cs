using UnityEngine;

// Определяем возможные типы объектов
public enum ObjectType
{
    KeyPoint,
    Enemy
}

public class ItemIdentifier : MonoBehaviour
{
    public int KeyPointID;
    public int NextPointID;
    public int ButtonID;
    
    [Tooltip("Тип объекта из списка")]
    public ObjectType objectType;
}