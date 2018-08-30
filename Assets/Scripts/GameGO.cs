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

    public AudioManager audioManager;
    public WorldManager worldManager;

    public string activeSceneName = "";

    public GameObject mainMenuPanel;
    public GameObject gameMenuPanel;

    public ButtonGO menuButton;
    public ButtonGO startButton;
    public ButtonGO optionsButton;
    public ButtonGO difficultyButton;
    public ButtonGO menu2Button;
    public ButtonGO quitButton;

    public bool showIntro = true;
    public Scene currentScene;

    public List<string> GameStates;

    public AudioClip introClip;
    public AudioClip introNoClip;
    public AudioClip optionsClip;
    public AudioClip difficultyClip;

    private void Awake()
    {
        //if (instance == null && name.ToLower().Contains("prefab") == false)
        if (instance == null)
        {
            //UnityEngine.Debug.Log("Found a GameGO: " + gameObject.name);
            instance = this;
            AudioManager.instance = audioManager;
            AudioManager.instance.Init();
            DontDestroyOnLoad(this);
            Restart();
        }
        else if (instance == this)
        {

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
        UnityEngine.Debug.Log(name + " Starting");
    }

    void Restart()
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
        if (instance.difficultyButton != null)
        {
            instance.difficultyButton.button.onClick.RemoveAllListeners();
            instance.difficultyButton.button.onClick.AddListener(instance.GameDifficulty);
        }
        if (instance.menu2Button != null)
        {
            instance.menu2Button.button.onClick.RemoveAllListeners();
            instance.menu2Button.button.onClick.AddListener(instance.GameMainMenu);
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
        GameStates = new List<string>(Game.GetDisplays());
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
                Game.isMenuActive = false;
            }
            else
            {
                CloseAll();
                gameMenuPanel.SetActive(true);
                instance.startButton.text = "(Paused) Resume";
                Time.timeScale = 0f;
                Game.isMenuActive = true;
            }
        }
    }

    public static void StartMenu()
    {
        string intro = "(no intro)";
        if (instance.showIntro)
        {
            intro = "(with intro)";
            AudioManager.instance.Play(instance.introClip);
            instance.worldManager.ChangeLight();
        }
        else
        {
            AudioManager.instance.Play(instance.introNoClip);
        }
        instance.startButton.text = "Start" + Strings.Space + intro;
        instance.startButton.button.onClick.RemoveAllListeners();
        instance.startButton.button.onClick.AddListener(instance.GameStart);
        instance.menu2Button.gameObject.SetActive(false);
    }

    public static void StartGame()
    {
        instance.startButton.text = "Resume";
        instance.startButton.button.onClick.RemoveAllListeners();
        instance.startButton.button.onClick.AddListener(instance.GameResume);
        instance.menu2Button.gameObject.SetActive(true);
    }

    public void GameMainMenu()
    {
        SceneManager.sceneLoaded += OnSceneRestarted;
        // Are you sure??
        SceneManager.LoadScene(Strings.GameMenu);
    }

    private void OnSceneRestarted(Scene arg0, LoadSceneMode arg1)
    {
        Restart();
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
        if (showIntro)
        {
            SceneManager.LoadScene(Strings.GameLabs);
        }
        else
        {
            SceneManager.LoadScene(Strings.GameGame);
        }
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

    private bool clickOnceOptions = false;
    public void GameOptions()
    {
        if (clickOnceOptions == false)
        {
            AudioManager.instance.Play(instance.optionsClip);
            clickOnceOptions = true;
        }
        else
        {
            // Play Clip 2 (NO Options for you!)
            AudioManager.instance.Play(instance.optionsClip);
            difficultyButton.gameObject.SetActive(true);
        }
        /// RIGHT
    }

    public void GameDifficulty()
    {
        AudioManager.instance.Play(instance.difficultyClip);
    }

    public static void Check()
    {
        if (instance == null)
        {
            GameResource.CreateGameGO();
        }
    }
}