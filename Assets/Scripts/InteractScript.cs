using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private bool doorIsOpen = false;
    public GameObject openText;

    private bool isInPlace = true;
    public GameObject moveText;

    public GameObject darkText;
    public GameObject atticHatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }

    private void OnTriggerExit(Collider other)
    {
        moveText.SetActive(false);
        openText.SetActive(false);
        darkText.SetActive(false);

        Destroy(other.gameObject);
    }
}
