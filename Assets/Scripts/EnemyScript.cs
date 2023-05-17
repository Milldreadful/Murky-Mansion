using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed;
    public float maxEnemyHealth = 100;
    public float flashTime = .15f;

    public ParticleSystem hitEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }


    private void OnParticleCollision(GameObject other)
    {
        if (maxEnemyHealth > 0)
        {
            var emission = hitEffect.emission;
            emission.enabled = true;
            hitEffect.Play();
            maxEnemyHealth -= 1;
        }


        if(maxEnemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
