using UnityEngine;

public class MovementController : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            //Gets the first contact with a collider tagged {OBSTACLE}
            Vector2 collisionNormal = collision.GetContact(0).normal;
        }
    }
    void Start()
    {
                
    }

    void Update()
    {
        
    }
}
