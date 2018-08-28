using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Our Game Persistent Scene Object
/// Might handle Save Slots and so forth.
/// </summary>
public class GameGO : MonoBehaviour
{
    public static GameGO instance;

    public string activeSceneName = "";

    public GameObject mainMenuPanel;
    public GameObject gameMenuPanel;

    public ButtonGO menuButton;
    public ButtonGO startButton;
    public ButtonGO optionsButton;
    public ButtonGO quitButton;

    public bool showIntro = true;

    public Scene currentScene;

    private void Awake()
    {
        //if (instance == null && name.ToLower().Contains("prefab") == false)
        if (instance == null)
        {
            //UnityEngine.Debug.Log("Found a GameGO: " + gameObject.name);
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            UnityEngine.Debug.Log("Found a GameGO: " + name);
            Destroy(gameObject);
            return;
        }
    }


    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        activeSceneName = currentScene.name;
        UnityEngine.Debug.Log("GameGO: " + currentScene.name);
        if (currentScene.name == Strings.GameMenu)
        {
            StartMenu();
            OpenAll();
        }
        else if (currentScene.name == Strings.GameLabs)
        {
            StartGame();
            CloseAll();
        }
        else if (currentScene.name == Strings.GameGame)
        {
            StartGame();
            CloseAll();
        }

        if (instance == null)
        {
            return;
        }

        if (instance.menuButton != null)
        {
            instance.menuButton.button.onClick.RemoveAllListeners();
            instance.menuButton.button.onClick.AddListener(instance.GameIntro);
        }

        if (instance.optionsButton != null)
        {
            instance.optionsButton.button.onClick.RemoveAllListeners();
            instance.optionsButton.button.onClick.AddListener(instance.GameOptions);
        }
        if (instance.quitButton != null)
        {
            instance.quitButton.button.onClick.RemoveAllListeners();
            instance.quitButton.button.onClick.AddListener(instance.GameQuit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instance == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentScene.name != "Menu")
        {
            if (gameMenuPanel.activeSelf)
            {
                instance.startButton.text = "Resume";
                CloseAll();
                Time.timeScale = 1f;
            }
            else
            {
                CloseAll();
                gameMenuPanel.SetActive(true);
                instance.startButton.text = "(Paused) Resume";
                Time.timeScale = 0f;
            }
        }
    }

    public static void StartMenu()
    {
        string intro = "(no intro)";
        if (instance.showIntro)
        {
            intro = "(with intro)";
        }
        instance.startButton.text = "Start" + Strings.Space + intro;
        instance.startButton.button.onClick.RemoveAllListeners();
        instance.startButton.button.onClick.AddListener(instance.GameStart);
    }

    public static void StartGame()
    {
        instance.startButton.text = "Resume";
        instance.startButton.button.onClick.RemoveAllListeners();
        instance.startButton.button.onClick.AddListener(instance.GameResume);
    }

    public static void SaveGame()
    {
        instance.GameSave();
    }

    public void GameIntro()
    {
        showIntro = !showIntro;
        StartMenu();
        if (showIntro)
        {
            AudioManager.instance.Play(Strings.GameIntro_0, true);
        }
        else
        {
            AudioManager.instance.Play(Strings.GameIntro_1, true);
        }
    }

    public void GameResume()
    {
        gameMenuPanel.SetActive(false);
    }

    public void GameSave()
    {

    }

    public void GameQuit()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GameStart()
    {
        CloseAll();
        StartGame(); // FOR Now?? move to a better area? - Setup menu to be for the game.
#if UNITY_EDITOR
        if (showIntro)
        {
            SceneManager.LoadScene(Strings.GameLabs);
        }
        else
        {
            SceneManager.LoadScene(Strings.GameGame);
        }
#else
        SceneManager.LoadScene(Strings.GameLabs);
#endif
    }

    private void CloseAll()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
        if (gameMenuPanel != null)
        {
            gameMenuPanel.SetActive(false);
        }
    }

    private void OpenAll()
    {
        mainMenuPanel.SetActive(true);
        gameMenuPanel.SetActive(true);
    }

    public void GameOptions()
    {
        /// RIGHT
    }

    public static void Check()
    {
        if (instance == null)
        {
            GameResource.CreateGameGO();
        }
    }
}