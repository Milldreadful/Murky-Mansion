using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [Header("Doors")]
    private bool doorIsOpen = false;
    public GameObject openText;
    public AudioSource doorCreak;

    [Header("Movable")]
    private bool isInPlace = true;
    public GameObject moveText;

    [Header("Easter Egg")]
    public GameObject waterPlantText;

    [Header("Lights")]
    public GameObject darkText;
    public GameObject atticHatch;
    public GameObject WClight;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Movable"))
        {
            if (isInPlace)
            {
                moveText.SetActive(true);

                if (Input.GetKey(KeyCode.Return))
                {
                    other.transform.Translate(new Vector3(-3, 0, 0));
                    moveText.SetActive(false);
                    isInPlace = false;
                }
            }
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (!doorIsOpen)
            {
                openText.SetActive(true);

                if (Input.GetKey(KeyCode.Return))
                {
                    other.transform.eulerAngles = new Vector3(0, -100f, 0);
                    doorCreak.Play();
                    openText.SetActive(false);
                    Destroy(other.GetComponent<Collider>());
                }
            }
        }


        if (other.gameObject.CompareTag("DarkTrigger"))
        {
            darkText.SetActive(true);

            if(Input.GetButton("Fire1"))
            {
                atticHatch.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (other.gameObject.CompareTag("WCEnemy"))
        {
            WClight.SetActive(true);
        }

        if(other.gameObject.CompareTag("Plant"))
        {
            waterPlantText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        moveText.SetActive(false);
        openText.SetActive(false);
        darkText.SetActive(false);
        waterPlantText.SetActive(false);

        if (other.gameObject.CompareTag("DarkTrigger"))
        {
            Destroy(other.gameObject);
        }
    }
}
