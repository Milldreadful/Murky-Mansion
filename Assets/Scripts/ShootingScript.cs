using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject sprayEffect;
    public Transform waterSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(sprayEffect, waterSpawner.position, waterSpawner.rotation);
        }

        if(Input.GetButton("Jump"))
        {
            sprayEffect.SetActive(true);
        }

        else
        {
            //sprayEffect.SetActive(false);
            ParticleSystem ps = sprayEffect.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.loop = false;
        }
    }
}
