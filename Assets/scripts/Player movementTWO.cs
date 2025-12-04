using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayermovementTWO : MonoBehaviour
{


    Rigidbody2D rb;
    public int speed;
    public float max_v = 50;
    public int health = 3;
    public GameObject Square; 

    public bool IsMoving => rb.linearVelocity.magnitude > 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(0, 1) * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(0, -1) * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(1, 0) * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && rb.linearVelocity.magnitude < max_v)
        {
            rb.AddForce(new Vector2(-1, 0) * speed);
        }

     Debug.Log(rb.linearVelocity);
        if (health < 0)
        {
            Destroy(gameObject);
            
            if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
            {
                SceneManager.LoadSceneAsync(3);
            }
        }
        

        //tog hjälp av ai för att göra movement mindre slidey? 
        if (!Input.GetKey(KeyCode.UpArrow) &&
    !Input.GetKey(KeyCode.DownArrow) &&
    !Input.GetKey(KeyCode.LeftArrow) &&
    !Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, 5f * Time.deltaTime);
        }


    }
}
