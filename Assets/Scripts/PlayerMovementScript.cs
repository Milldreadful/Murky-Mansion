using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController cc;
    public Animator player;

    public float playerSpeed = 5f;
    public float gravity = -9.81f; //default gravity on earth
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float depth = Input.GetAxis("Depth");

        Vector3 move = new Vector3(horizontal, 0f, depth);

        cc.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move); //rotates the player to face moving direction
            player.SetBool("IsMoving", true);
        }

        else
        {
            player.SetBool("IsMoving", false);
        }

        if (!cc.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity);
        }
    }
}
