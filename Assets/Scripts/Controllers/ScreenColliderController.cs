using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ScreenColliderController : MonoBehaviour
{

    [HideInInspector] public Vector2 bottomLeft;
    [HideInInspector] public Vector2 bottomRight;
    [HideInInspector] public Vector2 topLeft;
    [HideInInspector] public Vector2 topRight;

    private void Start()
    {
        var cam = Camera.main;
        var edge = GetComponent<EdgeCollider2D>();

        bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane));
        topLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane));
        topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

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