using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetPrefabColor(Color newColor)
{
    SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
    foreach (SpriteRenderer sr in renderers)
    {
        sr.color = newColor;
    }
}
}
