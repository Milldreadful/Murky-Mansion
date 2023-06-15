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
    public AudioSource bossDeath;
    public ParticleSystem hitEffect;
    public ParticleSystem deathExplosion;
    public Animator deathAnim;

    [Header("Energy Meter")]
    public BossHealthMeterScript bossHealthMeter;
    public int maxBossHealth = 30;
    public int currentHealth;
    public GameObject healthMeter;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BossTarget").transform;
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
        bossHealthMeter = GameObject.Find("BossHealthMeter").GetComponent<BossHealthMeterScript>();

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
        if (other.gameObject.CompareTag("Ammo") && currentHealth > 0)
        {
            currentHealth -= 10;
            var emission = hitEffect.emission;
            emission.enabled = true;
            hitEffect.Play();
        }

        else if (other.gameObject.CompareTag("Ammo") && currentHealth <= 0)
        {
            deathAnim.SetTrigger("Death");
            deathExplosion.Play();
            bossDeath.Play(); 
            Destroy(gameObject.transform.GetChild(0).gameObject, 1.4f);
            Destroy(gameObject.GetComponent<Collider>());
            healthMeter.SetActive(false);
            StartCoroutine(LoadLevel(2, 3f));
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
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(levelNum);
    }

    public void MoveToLevel(int level)
    {
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(level, 3f));
    }
}