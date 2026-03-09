using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector3(2, 3, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
