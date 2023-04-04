using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Mode")]
    public bool twinStick = false;
    public bool mouseAim = false;
    public bool classic = false;

    [Range(0.1f, 30f)]
    public float playerSpeed;

    [Header ("Shooting")]
    public GameObject gun;
    public GameObject ammo;
    public float fireRate = 0.5f;
    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        if (twinStick)
        {
            gun.GetComponent<TwinStickScript>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }

        else if (mouseAim)
        {
            gun.GetComponent<TwinStickScript>().enabled = false;
            gun.GetComponent<GunScript>().enabled = true;
        }

        else if (classic)
        {
            gun.GetComponent<TwinStickScript>().enabled = false;
            gun.GetComponent<GunScript>().enabled = false;
        }
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
            ShootOnce();
        }
    }

    public void ShootOnce()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ammo, gun.transform.position, gun.transform.rotation);
        }
    }

    public IEnumerator Shoot()
    {
        Instantiate(ammo, gun.transform.position, gun.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
