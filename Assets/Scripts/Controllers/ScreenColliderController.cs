using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ScreenColliderController : MonoBehaviour
{
    void Start()
    {
        Camera cam = Camera.main;
        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();

        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane));
        Vector2 topLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        Vector2[] points =
        {
            topLeft,
            topRight,
            bottomRight,
            bottomLeft,
            topLeft
        };

        edge.points = points;


    }
}
