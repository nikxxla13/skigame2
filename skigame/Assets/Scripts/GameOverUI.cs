using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image crossfade;
    [SerializeField] private int nextLevelIndex;

    void Start()
    {
        gameOverMenu.SetActive(false);
        crossfade.CrossFadeAlpha(0, 1f, true);
    }

    private void OnEnable()
    {
        GameEvents.raceEnd += EnableGameOver;
        GameEvents.Quit += Quit;
    }

    private void OnDisable()
    {
        GameEvents.raceEnd -= EnableGameOver;
        GameEvents.Quit -= Quit;
    }

    private void EnableGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void QuitButton()
    {
        GameEvents.CallQuit();
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartCouroutine());
    }

    private IEnumerator RestartCouroutine()
    {
         crossfade.CrossFadeAlpha(1f, 1f, true);
         yield return new WaitForSeconds(1f);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
    public void NextLevel()
    {
        StartCoroutine(NextLevelCouroutine());
    }
    
    private IEnumerator NextLevelCouroutine()
    {
        crossfade.CrossFadeAlpha(1f, 1f, true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevelIndex);
    }

    private void Quit()
    {
        StartCoroutine(QuitCouroutine());
        
    }
    private IEnumerator QuitCouroutine()
    {
        crossfade.CrossFadeAlpha(1f, 1f, true);
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
    
}

