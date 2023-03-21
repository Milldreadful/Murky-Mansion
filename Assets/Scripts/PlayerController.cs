using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0.1f, 30f)]
    public float playerSpeed;

    [Header ("Shooting")]
    public GameObject ammo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float depth = Input.GetAxis("Depth");

        transform.Translate(Vector3.right * horizontal * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * depth * playerSpeed * Time.deltaTime);

        // ALTERNATIVE:
        // transform.Translate(new Vector3(horizontal * playerSpeed * Time.deltaTime, vertical * playerSpeed * Time.deltaTime, depth * playerSpeed * Time.deltaTime));

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(ammo, transform.position, transform.rotation);
    }
}
