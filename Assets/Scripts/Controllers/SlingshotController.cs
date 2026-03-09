using UnityEngine;
using UnityEngine.InputSystem;

public class SlingshotController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool dragging;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Touchscreen.current == null) return;

        var touch = Touchscreen.current.primaryTouch;

        if (touch.press.wasPressedThisFrame)
        {
            dragging = true;
            rb.linearVelocity = Vector2.zero;
        }

        if (touch.press.wasReleasedThisFrame)
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector2 screenPos = touch.position.ReadValue();

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane)
            );

            targetPosition = new Vector2(worldPos.x, worldPos.y);
        }
    }

    void FixedUpdate()
    {
        if (dragging)
        {
            rb.MovePosition(targetPosition);
        }
    }
}