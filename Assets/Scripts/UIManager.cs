using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gameplayUI;
    public GameObject optionsUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public void UIMainManu()
    {
        mainMenuUI.SetActive(true);
        gameplayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UIGameplay()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UIOptions()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        optionsUI.SetActive(true);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UIPaused()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(true);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UIGameOver()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameWinUI.SetActive(false);
    }

    public void UIGameWin()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(true);
    }
}
