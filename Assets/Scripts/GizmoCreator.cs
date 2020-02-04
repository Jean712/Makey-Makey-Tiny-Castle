using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCreator : MonoBehaviour
{
    [Range(0.1f, 1)]
    public float gizmoSize = 1;
    public Color gizmoColor = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
