using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject sprayEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            sprayEffect.SetActive(true);
        }

        else
        {
            sprayEffect.SetActive(false);
        }
    }
}
