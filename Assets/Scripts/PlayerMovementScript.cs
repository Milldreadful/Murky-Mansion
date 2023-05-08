using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController cc;
    public Animator player;
    public float playerSpeed = 5f;

    [Header("Enemy")]
    public float maxPlayerHealth = 100f;
    public GameObject enemy;
    public Transform enemySpawn;
    public Transform startingPoint;

    private float gravity = -9.81f; //default gravity on earth
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        //startingPoint = gameObject.transform.position;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ExitBall")
        {
            print("Heippa");
            Application.Quit();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            maxPlayerHealth -= 1;

            if (maxPlayerHealth <= 0)
            {
                maxPlayerHealth = 100f;
                gameObject.transform.position = startingPoint.position;
            }
        }
    }
}
