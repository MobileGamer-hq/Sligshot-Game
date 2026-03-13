using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SomtoSpawnArea : MonoBehaviour
{
    [SerializeField]
    public List<Transform> areaCorners = new List<Transform>();

    public Color gizmoColor = Color.yellow; // I'll add color variation later to indicate areas identity
    public float pointSize = 0.1f;

    void OnDrawGizmos()
    {
        if (areaCorners == null || areaCorners.Count == 0)
            return;

        Gizmos.color = gizmoColor;

        for (int i = 0; i < areaCorners.Count; i++)
        {
            Transform current = areaCorners[i];

            if (current == null)
                continue;

            // Draw corner point
            Gizmos.DrawSphere(current.position, pointSize);

            // Draw line to next point
            if (areaCorners.Count > 1)
            {
                Transform next = areaCorners[(i + 1) % areaCorners.Count];

                if (next != null)
                {
                    Gizmos.DrawLine(current.position, next.position);
                }
            }
        }
    }
    
    public float GetArea()
    {
        if (areaCorners.Count < 3)
            return 0;

        float area = 0;

        for (int i = 0; i < areaCorners.Count; i++)
        {
            Vector3 a = areaCorners[i].position;
            Vector3 b = areaCorners[(i + 1) % areaCorners.Count].position;

            area += (a.x * b.y) - (b.x * a.y);
        }

        return Mathf.Abs(area) * 0.5f;
    }
}