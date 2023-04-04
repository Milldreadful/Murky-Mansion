using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [Range(30f, 100f)]
    public float rotationSpeed;
    public float drivingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(1f, 2f, 3f);
        //transform.rotation = new Quaternion(2f, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //transform.rotation = Quaternion.Euler(30f, 100f, 250f);
        //transform.RotateAround(transform.position, Vector3.up, 15f * Time.deltaTime);
        //transform.Rotate(0f, 1f, 0f);
        transform.Translate(Vector3.forward * ver * drivingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * hor * rotationSpeed * Time.deltaTime);

    }
}
