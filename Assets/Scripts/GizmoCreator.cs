using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCreator : MonoBehaviour
{
    [Range(1, 5)]
    public int gizmoAspect = 1;

    [Range(0.1f, 1)]
    public float gizmoSize = 0.25f;
    public Color gizmoColor = Color.green;

    private Vector3 cubeSize;

    private void OnDrawGizmos()
    {
        cubeSize = new Vector3(gizmoSize, gizmoSize, gizmoSize) * 1.5f;

        Gizmos.color = gizmoColor;

        switch (gizmoAspect)
        {
            case 1:
                Gizmos.DrawSphere(transform.position, gizmoSize);
                break;

            case 2:
                Gizmos.DrawWireSphere(transform.position, gizmoSize);
                break;

            case 3:
                Gizmos.DrawCube(transform.position, cubeSize);
                break;

            case 4:
                Gizmos.DrawWireCube(transform.position, cubeSize);
                break;

            case 5:
                Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * gizmoSize);
                break;
        }
    }
}
