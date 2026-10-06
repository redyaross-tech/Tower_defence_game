using UnityEngine;

// Определяем возможные типы объектов
public enum ObjectType
{
    KeyPoint,
    Enemy
}

public class ItemIdentifier : MonoBehaviour
{
    [Header("Настройки идентификации")]
    [Tooltip("Уникальный числовой ID объекта")]
    public int id;
    public int NextPointID;
    
    [Tooltip("Тип объекта из списка")]
    public ObjectType objectType;
}