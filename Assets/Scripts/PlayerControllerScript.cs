using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;

    public Rigidbody rb;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float depth = Input.GetAxis("Depth");

        Vector3 movement = new Vector3(horizontal, 0.0f, depth);
        transform.rotation = Quaternion.LookRotation(movement);


        transform.Translate(movement * playerSpeed * Time.deltaTime, Space.World);

        //transform.Translate(Vector3.right * horizontal * playerSpeed * Time.deltaTime);
        //transform.Translate(Vector3.forward * depth * playerSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
