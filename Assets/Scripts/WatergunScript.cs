using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatergunScript : MonoBehaviour
{

    public Transform gunTip;

    public GameObject sprayEffect;
    public GameObject sprayEffectEnd;

    public bool endShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            sprayEffect.SetActive(true);
            endShooting = true;
        }

        else
        {
            if(endShooting)
            {
                sprayEffect.SetActive(false);
                Instantiate(sprayEffectEnd, gunTip.position, gunTip.rotation);
                endShooting = false;
            }
        }
    }
}
