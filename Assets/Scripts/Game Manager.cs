using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    
    private LevelManager _levelManager;
    private UIManager _uiManager;

    public enum GameState { MainMenu, Gameplay, Options, Paused, GameOver, GameWin }
    public GameState gameState;


    private void Awake()
    {
        gameState = GameState.MainMenu;

        _levelManager = FindAnyObjectByType<LevelManager>();

        _uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.MainMenu:    MainMenu(); break;
            case GameState.Gameplay:    Gameplay(); break;
            case GameState.Options:     Options(); break;
            case GameState.Paused:      Paused(); break;
            case GameState.GameOver:    GameOver(); break;
            case GameState.GameWin:     GameWin(); break;
        }
    }

    private void MainMenu()
    {
        Cursor.visible = true;

        _uiManager.UIMainManu();
    }

    private void Gameplay()
    {
        Cursor.visible = false;

        _uiManager.UIGameplay();
    }

    private void Options()
    {
        Cursor.visible = true;

        _uiManager.UIOptions();
    }

    private void Paused()
    {
        Cursor.visible = true;

        _uiManager.UIPaused();
    }

    private void GameOver()
    {
        Cursor.visible = true;

        _uiManager.UIGameOver();
    }

    private void GameWin()
    {
        Cursor.visible = true;

        _uiManager.UIGameWin();
    }

    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
