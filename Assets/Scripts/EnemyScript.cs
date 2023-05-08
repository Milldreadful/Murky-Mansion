using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Material material;

    public float enemySpeed;
    public float maxEnemyHealth = 100;
    public float flashTime = .15f;

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
            StartCoroutine(DamageFlash());
            maxEnemyHealth -= 1;
        }


        if(maxEnemyHealth == 0)
        {
            material.DisableKeyword("_EMISSION");
            Destroy(gameObject);
        }
    }

    IEnumerator DamageFlash()
    {
        material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(flashTime);
        material.DisableKeyword("_EMISSION");
    }
}
