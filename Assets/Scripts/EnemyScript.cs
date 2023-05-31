using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator enemyAnim;
    public Transform target;
    public float enemySpeed;
    public float maxEnemyHealth = 30;
    public float flashTime = .15f;

    public ParticleSystem hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo") && maxEnemyHealth > 0)
        {
            var emission = hitEffect.emission;
            emission.enabled = true;
            hitEffect.Play();
            maxEnemyHealth -= 10;
        }


        if (maxEnemyHealth == 0)
        {
            enemyAnim.SetTrigger("Death");
            Destroy(gameObject, 1f);
        }
    }
}
