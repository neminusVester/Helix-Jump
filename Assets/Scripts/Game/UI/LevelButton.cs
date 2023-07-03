using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ColorChange);
        _image = GetComponent<Image>();
        GameEvents.Instance.OnLevelButtonPressed += SetDefaultColor;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnLevelButtonPressed -= SetDefaultColor;
    }

    private void ColorChange()
    {
        GameEvents.Instance.PressLevelButton();
        _image.color = Color.red;
    }

    private void SetDefaultColor()
    {
        _image.color = Color.white;
    }
}
