using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    
    private LevelManager _levelManager;
    private UIManager _uiManager;
    private CharacterController2D _characterController2D;

    public GameObject spawnPoint;
    public GameObject player;
    public GameObject playerArt;
    public bool inDialogue;

    public enum GameState { MainMenu, Gameplay, Options, Paused, GameOver, GameWin }
    public GameState gameState;
    private GameState lastGameState;
    private GameState returnFromOptions;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;

        gameState = GameState.MainMenu;

        _levelManager = FindAnyObjectByType<LevelManager>();

        _uiManager = FindAnyObjectByType<UIManager>();

        _characterController2D = FindAnyObjectByType<CharacterController2D>();
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
        Cursor.lockState = CursorLockMode.None;

        playerArt.SetActive(false);
        _characterController2D.enabled = false;

        _uiManager.UIMainManu();
    }

    private void Gameplay()
    {
        if (!inDialogue)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        playerArt.SetActive(true);
        _characterController2D.enabled = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lastGameState = gameState;
            gameState = GameState.Paused;
        }

        _uiManager.UIGameplay();
    }

    private void Options()
    {
        Cursor.lockState = CursorLockMode.None;

        _characterController2D.enabled = false;

        if (Input.GetKeyDown(KeyCode.Escape) && returnFromOptions != GameState.MainMenu)
        {
            gameState = GameState.Paused;
        }

        _uiManager.UIOptions();
    }

    private void Paused()
    {
        Cursor.lockState = CursorLockMode.None;

        _characterController2D.enabled = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = lastGameState;
        }

        _uiManager.UIPaused();
    }

    private void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;

        playerArt.SetActive(false);
        _characterController2D.enabled = false;

        _uiManager.UIGameOver();
    }

    private void GameWin()
    {
        Cursor.lockState = CursorLockMode.None;

        playerArt.SetActive(false);
        _characterController2D.enabled = false;

        _uiManager.UIGameWin();
    }

    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void MovePlayerToSpawnPosition()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        player.transform.position = spawnPoint.transform.position;
    }

    public void ToOptions()
    {
        returnFromOptions = gameState;
        gameState = GameState.Options;
    }

    public void FromOptions()
    {
        gameState = returnFromOptions;
    }

    public void ResumeGame()
    {
        gameState = lastGameState;
    }
}
