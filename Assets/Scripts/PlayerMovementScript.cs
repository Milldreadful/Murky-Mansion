using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMovementScript : MonoBehaviour
{
    public GameManager gm;
    public GameObject flashlight;
    public GameObject instructions;

    [Header("Effects")]
    public PostProcessVolume PPVolume;
    private Vignette vignette;
    public AudioSource stepAudio;
    public float minVolume;
    public float maxVolume;
  
    [Header("Movement")]
    public CharacterController cc;
    public Animator player;
    public float playerSpeed = 5f; 
    private float gravity = -9.81f; //default gravity on earth
    private Vector3 velocity;

    [Header("Fight")]
    public HealthMeterScript healthMeter;
    public int maxPlayerHealth;
    public int currentHealth;
    public float flashTime = 0.15f;

   

    // Start is called before the first frame update
    void Start()
    {
        PPVolume.profile.TryGetSettings(out vignette);

        currentHealth = maxPlayerHealth;
        healthMeter.SetMaxHealth(maxPlayerHealth);

        StartCoroutine(InstructionsOff());
    }

    // Update is called once per frame
    void Update()
    {
        healthMeter.SetHealth(currentHealth);

        float horizontal = Input.GetAxis("Horizontal");
        float depth = Input.GetAxis("Depth");

        Vector3 move = new Vector3(horizontal, 0f, depth);

        cc.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move); //rotates the player to face moving direction
            player.SetBool("IsMoving", true);
            stepAudio.volume = maxVolume;
        }

        else
        {
            player.SetBool("IsMoving", false);
            stepAudio.volume = minVolume;
        }

        if (!cc.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            StartCoroutine(DamageFlash(0.15f));
            currentHealth -= 10;

            if (currentHealth <= 0)
            {
                vignette.color.Override(Color.red);
                gm.MoveToLevel(1);
            }
        }
    }

    IEnumerator DamageFlash(float flashTime)
    {
        vignette.color.Override(Color.red);
        yield return new WaitForSeconds(flashTime);
        vignette.color.Override(Color.black);
    }

    IEnumerator InstructionsOff()
    {
        yield return new WaitForSeconds(10f);
        instructions.SetActive(false);
    }
}
