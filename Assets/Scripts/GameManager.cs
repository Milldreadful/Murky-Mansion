using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private EnemyScript enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObjects(GameObject obj)
    {
        obj.transform.Translate(new Vector3(-3, 0, 0));
    }

    public void ButtonOff(GameObject button)
    {
        button.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
