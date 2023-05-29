using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public WaterMeterScript waterMeter;
    public int currentWater;
    public int maxWater = 80;

    public GameObject bullet;
    public Transform guntip;
    public ParticleSystem waterSpray;
    public AudioSource watergun;
    public AudioClip sprayAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentWater = maxWater;
        waterMeter.SetMaxWater(maxWater);
    }

    // Update is called once per frame
    void Update()
    {
        waterMeter.SetWater(currentWater);

        if(Input.GetButtonDown("Jump") && currentWater > 0)
        {
            var emission = waterSpray.emission;
            emission.enabled = true;
            waterSpray.Play();
            Instantiate(bullet, guntip.position, guntip.rotation);
            watergun.PlayOneShot(sprayAudio);
            currentWater -= 5;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Faucet"))
        {
            currentWater = maxWater;
        }
    }
}
