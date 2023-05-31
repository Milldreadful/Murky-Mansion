using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Animator lightAnimator;
    public Animator cameraAnimator;
    public Animator textAnimator;
    public PostProcessVolume PP;

    public bool doorIsOpen = true ;

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


    public void ButtonOff(GameObject button)
    {
        button.SetActive(false);
    }

    public void EnterGame()
    {
        textAnimator.SetTrigger("PressEnter");
        cameraAnimator.SetTrigger("EnterGame");
        StartCoroutine(LoadLevel(1));
        //ButtonOff(enterButton);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadLevel(int levelNum)
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(levelNum);
    }
}

