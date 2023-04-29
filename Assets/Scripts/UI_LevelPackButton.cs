using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelPackButton : MonoBehaviour
{
    public static event Action<UI_LevelPackButton, LevelPackSO, bool> OnLevelPackButtonClicked;

    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _levelPackName;
    [SerializeField] LevelPackSO _levelPack;
    [SerializeField] TextMeshProUGUI _lockedText;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] bool _isLocked;

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

    public void LockLevelPack()
    {
        _isLocked = true;
        _lockedText.gameObject.SetActive(true);
        _priceText.gameObject.SetActive(true);
        _priceText.text = _levelPack.Price.ToString();
    }

    public void UnlockLevelPack()
    {
        _isLocked = false;
        _lockedText.gameObject.SetActive(false);
        _priceText.gameObject.SetActive(false);
    }

    void OnLevelPackClicked()
    {
        OnLevelPackButtonClicked?.Invoke(this, _levelPack, _isLocked);
    }
}
