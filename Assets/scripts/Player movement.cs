using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public float max_v = 50; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && rb.linearVelocity.magnitude < max_v) 
        {
            rb.AddForce(new Vector2(0, 1) * speed); 
        }
        if (Input.GetKey(KeyCode.S) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(0, -1) * speed); 
        }
        if (Input.GetKey(KeyCode.D) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(1, 0) * speed);
        }
        if (Input.GetKey(KeyCode.A) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(-1, 0) * speed);
        }
    }   
}