using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; 
    public float jumpForce = 7.0f; 
    private Rigidbody rb; 
    public bool isGrounded = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        // Captura a direção para frente da câmera e ignora a inclinação vertical (pitch)
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();

        // Captura a direção para a direita da câmera
        Vector3 right = Camera.main.transform.right;

        // Cria um vetor de movimento que é uma combinação das direções para frente e para a direita da câmera
        Vector3 movement = forward * moveVertical + right * moveHorizontal;
        
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }


    void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}