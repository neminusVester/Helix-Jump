using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private Ball ball;

    private void Start()
    {
        levelController.Init(canvasController);
        canvasController.Init();
        ball.SetInactive();
        GameEvents.Instance.OnLevelStarted += InitCamera;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnLevelStarted -= InitCamera;
    }

    private void InitCamera()
    {
        cameraMovement.Init(ball.transform);
        ball.SetActive();
    }
}
