using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;

    public Rigidbody rb;
    bool grounded;

    public Animator walk;

    [Header("Player Step Climb:")]
    public GameObject stepRayUpper;
    public GameObject stepRayLower;
    public float stepHeight = 0.3f;
    public float stepSmooth = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float depth = Input.GetAxis("Depth");

        Vector3 movement = new Vector3(horizontal, 0.0f, depth);


        transform.Translate(movement * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            walk.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            walk.SetBool("IsMoving", true);
        }

        else
        {
            walk.SetBool("IsMoving", false);
        }

        //stepClimb();
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

    void stepClimb()
    {
        RaycastHit hitLower;
        if(Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.5f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.1f))
            {
                rb.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
    }
}
