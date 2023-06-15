using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Animator cameraAnimator;
    public Animator textAnimator;
    public Animator fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(YouWinScene());
        }
    }


    public void EnterGame()
    {
        textAnimator.SetTrigger("PressEnter");
        cameraAnimator.SetTrigger("EnterGame");
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(1, 3.5f));
    }

    public void MoveToLevel(int level)
    {
        fadeScreen.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(level, 3f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadLevel(int levelNum, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelNum);
    }

    public IEnumerator YouWinScene()
    {
        yield return new WaitForSeconds(4f);
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }
}

