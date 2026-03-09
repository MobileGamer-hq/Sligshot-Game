using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector2 ballPosition;
    public Vector2 ballVelocity;

    Vector2 collisionNormal;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            //Gets the first contact with a collider tagged {OBSTACLE}
            collisionNormal = collision.GetContact(0).normal;
        }
    }

    void ReflectBall()
    {
    //Gets the resultant direction for the ball and normalises
        Vector2 newDirection = (ballPosition - collisionNormal).normalized;

    //Sets the new velocity of the ball
        Vector2 newVelocity = newDirection;
    }


    void Update()
    {
        ballPosition = gameObject.transform.position;
    }
}
