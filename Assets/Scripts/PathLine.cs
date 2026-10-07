using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

public class PathLine : MonoBehaviour
{
    public Color LineColor;

    // Path node storage
    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = LineColor;

        Transform[] PathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < PathTransforms.Length; i++){
            if(PathTransforms[i] != transform)
            {
                nodes.Add(PathTransforms[i]);
            }
        }

        for (int i = 0; i < nodes.Count; i++){
            Vector3 CurrentNode = nodes[i].position;
            if(i > 0){
                Vector3 PreviousNode = nodes[i-1].position;
                Gizmos.DrawLine(PreviousNode, CurrentNode);
            }  
        }
    }
    void Start()
    {
        LineColor = new Color(0, 0, 0, 0);
    }
}