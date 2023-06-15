using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightScript : MonoBehaviour
{
    public Animator fadeScreen;

    [Header("BossFight")]
    public Transform target;
    public float enemySpeed = 1;
    public int maxBossHealth = 100;
    public AudioSource bossDeath;
    public ParticleSystem hitEffect;
    public ParticleSystem deathExplosion;

    [Header("Energy Meter")]
    public BossHealthMeterScript bossHealthMeter;
    public int currentHealth;
    public GameObject healthMeter;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BossTarget").transform;
        currentHealth = maxBossHealth;
        bossHealthMeter.SetMaxHealth(maxBossHealth);
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

        bossHealthMeter.SetHealth(currentHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo") && maxBossHealth > 0)
        {
            currentHealth -= 10;
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
            healthMeter.SetActive(false);
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