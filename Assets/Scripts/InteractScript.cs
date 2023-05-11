using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject moveButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Movable"))
        {
            moveButton.SetActive(true);
        }

        if (hit.gameObject.CompareTag("Door"))
        {
            hit.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
