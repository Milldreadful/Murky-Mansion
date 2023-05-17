using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerScript : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(enemy, spawnPoint[i].position, spawnPoint[i].rotation);
            }
        }
    }
}