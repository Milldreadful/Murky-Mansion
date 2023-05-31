using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("Water Meter")]
    public Animator waterMeterAnim;
    public WaterMeterScript waterMeterScript;
    public int currentWater;
    public int maxWater = 80;

    [Header("Watergun")]
    public GameObject bullet;
    public Transform guntip;
    public ParticleSystem waterSpray;
    public AudioSource watergun;
    public AudioClip sprayAudio;

    public AudioSource faucet;

    // Start is called before the first frame update
    void Start()
    {
        currentWater = maxWater;
        waterMeterScript.SetMaxWater(maxWater);
    }

    // Update is called once per frame
    void Update()
    {
        waterMeterScript.SetWater(currentWater);

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Faucet"))
        {
            currentWater = maxWater;
            faucet.Play();
            waterMeterAnim.SetTrigger("FillUp");
        }
    }
}
