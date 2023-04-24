using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Vector3 movement;

    public Animator walk;

    [Header("Player Step Climb:")]
    public GameObject stepRayUpper;
    public GameObject stepRayLower;
    public float stepHeight = 0.3f;
    public float stepSmooth = 10f;


    // Start is called before the first frame update
    void Start()
    {
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float depth = Input.GetAxis("Depth");

        movement = new Vector3(horizontal, 0.0f, depth);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            walk.SetBool("IsMoving", true);
        }

        else
        {
            walk.SetBool("IsMoving", false);
        }

       stepClimb();
    }


    void stepClimb()
    {
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.3f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.5f))
            {
                rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }
}
