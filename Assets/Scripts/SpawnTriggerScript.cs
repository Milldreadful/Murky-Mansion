using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerScript : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void EnemySpawner()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemySpawner();
            Destroy(gameObject);
        }
    }
}
