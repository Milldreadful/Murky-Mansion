using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightScript : MonoBehaviour
{
    public Animator fadeScreen;

    public Transform target;
    public float enemySpeed = 1;
    public float maxBossHealth = 100f;
    public AudioSource bossDeath;
    public ParticleSystem hitEffect;
    public ParticleSystem deathExplosion;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BossTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        StartCoroutine(BossGrowl());

        if(maxBossHealth <= 0)
        {
            bossDeath.volume = Mathf.Lerp(bossDeath.volume, 0, 1 * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo") && maxBossHealth > 0)
        {
            maxBossHealth -= 10;
            var emission = hitEffect.emission;
            emission.enabled = true;
            hitEffect.Play();
        }

        else if (other.gameObject.CompareTag("Ammo") && maxBossHealth <= 0)
        {
            deathExplosion.Play();
            bossDeath.Play(); 
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Destroy(gameObject.GetComponent<Collider>());
            MoveToLevel(2);
        }
    }

    public IEnumerator BossGrowl()
    {
        yield return new WaitForSeconds(7f);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    public IEnumerator LoadLevel(int levelNum, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelNum);
    }

    public void MoveToLevel(int level)
    {
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(level, 3f));
    }
}