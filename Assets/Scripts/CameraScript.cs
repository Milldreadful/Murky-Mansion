using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float cameraDistance = 1f;
    public float cameraSpeed = 4f;

    private PlayerMovementScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = Player.GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = Vector3.Lerp(transform.position, Player.position + Offset, cameraSpeed * Time.deltaTime);
        }
    }
    private void LateUpdate()
    {
        if (playerScript.cc.velocity.x > 0.1)
        {
            Offset.x = cameraDistance;
        }

        else if (playerScript.cc.velocity.x < -0.1)
        {
            Offset.x = -cameraDistance;
        }
    }
}
