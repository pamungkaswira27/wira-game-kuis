using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] InitialGameplayData _initialGameplayData;
    [SerializeField] PlayerProgressSO _playerProgress;
    [SerializeField] TextMeshProUGUI _coinText;

    void Start()
    {
        _coinText.text = _playerProgress.dataProgress.coin.ToString();
    }

    void OnApplicationQuit()
    {
        _initialGameplayData.IsLose = false;
    }
}
