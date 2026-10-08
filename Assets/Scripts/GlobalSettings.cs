using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static float Speed = 5f;
    public static float Step = Speed * Time.deltaTime;
    public static float UISpeed = 100f;
    public static float UIStep = UISpeed * Time.deltaTime;
}
