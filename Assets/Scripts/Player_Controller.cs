using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
   
    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;
   
    private bool isGrounded = true ;

private void Awake()
    {    
        rb = GetComponent<Rigidbody2D>();
    }
private void OnEnable()
    {
        direction = Vector3.zero;
    }
private void Update()
{ 
    if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
            direction = Vector3.up * jumpForce;
        }
        direction += gravity * Time.deltaTime * Vector3.down;
    if (isGrounded==true)        
    {
        direction = Vector3.down;
    }
    void Jump()
    {
       rb.velocity = new Vector3(rb.velocity.x, jumpForce);
       isGrounded = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           BackgroundScroll.Instance.GameOver();
        }
         if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }
}
}