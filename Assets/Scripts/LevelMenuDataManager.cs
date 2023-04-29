using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] UI_LevelPackList _levelPackList;
    [SerializeField] InitialGameplayData _initialGameplayData;
    [SerializeField] PlayerProgressSO _playerProgress;
    [SerializeField] TextMeshProUGUI _coinText;
    [SerializeField] LevelPackSO[] _levelPacks;

    void Start()
    {
        if (!_playerProgress.LoadProgress())
        {
            _playerProgress.SaveProgress();
        }

        _levelPackList.LoadLevelPack(_levelPacks, _playerProgress.dataProgress);

        _coinText.text = _playerProgress.dataProgress.coin.ToString();
        AudioManager.instance.PlayBGM(0);
    }

    void OnApplicationQuit()
    {
        _initialGameplayData.IsLose = false;
    }
}
