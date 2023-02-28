using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acceleration = 10f;
    public float maxSpeed = 3f;
    public float jumpForce = 10f;
    public float jumpBoost = 5f;

    public GameObject guiController;

    public bool isGrounded;
    public bool hitBlock;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;


        Collider col = GetComponent<Collider>();
        float halfHeight = 0.07f;
        float topHalf = halfHeight + 1.87f;

        isGrounded = Physics.Raycast(transform.position, Vector3.down,  halfHeight);
        hitBlock = Physics.Raycast(transform.position, Vector3.up, topHalf);

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y, rb.velocity.z);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

       
        Color lineColor = (isGrounded) ? Color.green : Color.red;
        Color blockLine = (hitBlock) ? Color.green : Color.red;
        Debug.DrawLine(transform.position, transform.position + Vector3.down * halfHeight, lineColor, 0f, false);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * topHalf, blockLine, 0f, false);

        float speed = rb.velocity.magnitude;
        Animator a = GetComponent<Animator>();
        a.SetFloat("Speed", speed);
        a.SetBool("isJumping", !isGrounded);


    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Question")
        {
            guiController.GetComponent<GUIController>().UpdateCoinText();
            guiController.GetComponent<GUIController>().updateScoreText();
        }

        if (collision.gameObject.tag == "Brick")
        {
            guiController.GetComponent<GUIController>().updateScoreText();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Level Completed!");
            guiController.GetComponent<GUIController>().completeLevel();
        }

        if (other.gameObject.tag == "Lava")
        {
            transform.position = new Vector3(14f, 1.6f, 0);
        }
    }

}
