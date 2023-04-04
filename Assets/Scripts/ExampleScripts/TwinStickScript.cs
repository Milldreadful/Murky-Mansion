using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickScript : MonoBehaviour
{
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("HorRStick");
        float ver = Input.GetAxis("VerRStick");

        Vector3 gunDirection = Vector3.right * hor + Vector3.up * ver;

        if (gunDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(gunDirection, Vector3.back);

            if (player.canFire)
            {
                player.StartCoroutine("Shoot");
            }
        }
    }
}
