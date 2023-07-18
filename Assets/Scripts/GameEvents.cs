using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoSingleton<GameEvents>
{
    public event Action OnPlayerDie;
    public event Action OnPlayerPaused;
    public event Action OnLevelStarted;
    public event Action OnTochedEnd;
    public event Action OnLevelRestarted;
    public event Action OnNextLevel;
    public event Action OnLevelButtonPressed;
    public event Action<bool> OnFewerMode;
    public event Action OnPlatformPassed;

    //зробить цей івент з інтом.

    protected override void Awake()
    {
        base.Awake();
    }

    public void PlayerDie() => OnPlayerDie?.Invoke();
    public void PlayerPause() => OnPlayerPaused?.Invoke();
    public void SelectLevel() => OnLevelStarted?.Invoke();
    public void PlayerPassedLevel() => OnTochedEnd?.Invoke();
    public void RestartLevel() => OnLevelRestarted?.Invoke();
    public void SelectedNextLevel() => OnNextLevel?.Invoke();
    public void PressLevelButton() => OnLevelButtonPressed?.Invoke();
    public void FewerModeChange(bool active) => OnFewerMode?.Invoke(active);
    public void PlayerPassedPlatform(int i)
    {
        if (i == 3) FewerModeChange(true);
        else FewerModeChange(false);

        OnPlatformPassed?.Invoke();
    }

    //Зробить івент start fewer mode boolean.

}
