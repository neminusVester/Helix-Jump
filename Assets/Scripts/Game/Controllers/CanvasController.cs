using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public int levelButtonIndex;

    [Header("Panels")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject playingPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameSuccessfulPanel;
    [SerializeField] private GameObject emptyLevelsPanel;

    [Header("Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button[] levelButtons;

    public void Init()
    {
        //Subscribes to events
        GameEvents.Instance.OnPlayerDie += PlayerLose;
        GameEvents.Instance.OnPlayerPaused += GamePause;
        GameEvents.Instance.OnTochedEnd += GameSuccessful;
        GameEvents.Instance.OnNextLevel += PlayerSelectNextLevel;

        //onClick for buttons
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int buttonIndex = i;
            levelButtons[i].onClick.AddListener(() => LevelSelectButton(buttonIndex));
        }
        resumeButton.onClick.AddListener(ResumeButton);
        pauseButton.onClick.AddListener(PauseButton);
        startButton.onClick.AddListener(StartButton);
        restartButton.onClick.AddListener(RestartLevelButton);
        nextLevelButton.onClick.AddListener(NextLevelButton);
        mainMenuButton.onClick.AddListener(MenuButton);
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnPlayerDie -= PlayerLose;
        GameEvents.Instance.OnPlayerPaused -= GamePause;
        GameEvents.Instance.OnTochedEnd -= GameSuccessful;
        GameEvents.Instance.OnNextLevel -= PlayerSelectNextLevel;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log($"index from canvas controller: {levelButtonIndex}");
        }
    }
#endif

    // Buttons functions
    public void LevelSelectButton(int index) //When player click on level button then index of this button set 
    {                                        //in static variable which mean a level number
        levelButtonIndex = index;
    }

    private void StartButton()
    {
        GameEvents.Instance.SelectLevel();
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void PauseButton()
    {
        GameEvents.Instance.PlayerPause();
    }

    private void ResumeButton()
    {
        pausePanel.SetInactive();
        Time.timeScale = 1f;
    }

    private void RestartLevelButton()
    {
        GameEvents.Instance.RestartLevel();
        losePanel.SetInactive();
        Time.timeScale = 1f;
    }

    private void NextLevelButton()
    {
        if (levelButtonIndex + 2 <= levelButtons.Length)
        {
            GameEvents.Instance.SelectedNextLevel();
        }
        else
        {
            Debug.Log("else in next level button");
            emptyLevelsPanel.SetActive();
            nextLevelButton.SetInactive();
        }
    }

    private void MenuButton()
    {
        emptyLevelsPanel.SetInactive();
        nextLevelButton.SetActive();
        gameSuccessfulPanel.SetInactive();
        startPanel.SetActive();
    }

    //Functions of events during the game
    private void PlayerLose() //Player toched the death sector and lose game
    {
        losePanel.SetActive();
        playingPanel.SetInactive();
        Time.timeScale = 0f;
    }

    private void GamePause() //Player click on pause button
    {
        pausePanel.SetActive();
        Time.timeScale = 0f;
    }

    private void GameSuccessful() //Player passed all platform and toched the end platform
    {
        Time.timeScale = 0f;
        gameSuccessfulPanel.SetActive();
        emptyLevelsPanel.SetInactive();
    }

    private void PlayerSelectNextLevel()
    {
        gameSuccessfulPanel.SetInactive();
        Time.timeScale = 1f;
    }

}
