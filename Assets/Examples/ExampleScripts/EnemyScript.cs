using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Material material;

    public float enemySpeed;
    public float maxHealth = 100;
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
        if (maxHealth > 0)
        {
            StartCoroutine(DamageFlash());
            maxHealth -= 1;
        }


        if(maxHealth == 0)
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
