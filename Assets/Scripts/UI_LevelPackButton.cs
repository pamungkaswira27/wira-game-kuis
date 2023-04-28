using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelPackButton : MonoBehaviour
{
    public static event Action<LevelPackSO> OnLevelPackButtonClicked;

    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _levelPackName;
    [SerializeField] LevelPackSO _levelPack;

    void Start()
    {
        if (_levelPack != null)
        {
            SetLevelPack(_levelPack);
        }

        _button.onClick.AddListener(OnLevelPackClicked);
    }

    void OnDestroy()
    {
        _button.onClick.RemoveListener(OnLevelPackClicked);
    }

    public void SetLevelPack(LevelPackSO levelPack)
    {
        _levelPack = levelPack;
        _levelPackName.text = _levelPack.name;
    }

    void OnLevelPackClicked()
    {
        OnLevelPackButtonClicked?.Invoke(_levelPack);
    }
}
