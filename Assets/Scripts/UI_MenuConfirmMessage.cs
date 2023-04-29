using TMPro;
using UnityEngine;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [SerializeField] PlayerProgressSO _playerProgress;
    [SerializeField] GameObject _enoughMessage;
    [SerializeField] GameObject _notEnoughMessage;
    [SerializeField] TextMeshProUGUI _coinText;

    UI_LevelPackButton _levelPackButton;
    LevelPackSO _levelPack;

    void Start()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        UI_LevelPackButton.OnLevelPackButtonClicked += UI_LevelPackButton_OnLevelPackButtonClicked;
    }

    void OnDestroy()
    {
        UI_LevelPackButton.OnLevelPackButtonClicked -= UI_LevelPackButton_OnLevelPackButtonClicked;
    }

    private void UI_LevelPackButton_OnLevelPackButtonClicked(UI_LevelPackButton levelPackButton, LevelPackSO levelPack, bool isLocked)
    {
        if (!isLocked) return;

        gameObject.SetActive(true);

        if (_playerProgress.dataProgress.coin < levelPack.Price)
        {
            _enoughMessage.SetActive(false);
            _notEnoughMessage.SetActive(true);
            return;
        }

        _enoughMessage.SetActive(true);
        _notEnoughMessage.SetActive(false);

        _levelPack = levelPack;
        _levelPackButton = levelPackButton;
    }

    public void BuyLevelPack()
    {
        _playerProgress.dataProgress.coin -= _levelPack.Price;
        _playerProgress.dataProgress.levelProgress[_levelPack.name] = 1;
        _playerProgress.SaveProgress();

        _coinText.text = _playerProgress.dataProgress.coin.ToString();

        _levelPackButton.UnlockLevelPack();
    }
}
