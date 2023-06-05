using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightScript : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 1;
    public float maxEnemyHealth = 30f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BossTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);
        //transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo") && maxEnemyHealth > 0)
        {
            maxEnemyHealth -= 10;
        }

        if (maxEnemyHealth == 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}