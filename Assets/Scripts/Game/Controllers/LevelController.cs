using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<CoreController> cores;
    [SerializeField] Transform spawnTransform;
    [SerializeField] private Vector3 spawnLevelOffset = new Vector3(0f, -12f, 0f);
    private CanvasController _canvasController;
    private Vector3 _ballSpawnOffset = new Vector3(0.15f, -0.45f, -0.75f);
    private CoreController _currentCore;

    public void Init(CanvasController newCanvasController)
    {
        _canvasController = newCanvasController;
        //Events for Init level from game panel
        GameEvents.Instance.OnLevelStarted += DestroyCurrentLevel;
        GameEvents.Instance.OnLevelStarted += InstantiateLevel;

        //Level restarted Events
        GameEvents.Instance.OnLevelRestarted += DestroyCurrentLevel;
        GameEvents.Instance.OnLevelRestarted += InstantiateLevel;
        //Next level Events
        GameEvents.Instance.OnNextLevel += DestroyCurrentLevel;
        GameEvents.Instance.OnNextLevel += InstantiateNextLevel;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnLevelStarted -= InstantiateLevel;
        GameEvents.Instance.OnLevelRestarted -= DestroyCurrentLevel;
        GameEvents.Instance.OnLevelRestarted -= InstantiateLevel;
        GameEvents.Instance.OnLevelStarted -= DestroyCurrentLevel;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log($"index from level controller: {_canvasController.levelButtonIndex}");
        }
    }
#endif

    private void InstantiateLevel()
    {
        if (_currentCore == null)
        {
            _currentCore = Instantiate(cores[_canvasController.levelButtonIndex], spawnTransform.position + spawnLevelOffset, Quaternion.identity);
        }
    }

    private void InstantiateNextLevel()
    {
        _canvasController.levelButtonIndex += 1;
        _currentCore = Instantiate(cores[_canvasController.levelButtonIndex], spawnTransform.position + spawnLevelOffset, Quaternion.identity);
    }

    private void DestroyCurrentLevel()
    {
        if (_currentCore == null) return;
        Destroy(_currentCore.gameObject);
        _currentCore = null;
    }
}
