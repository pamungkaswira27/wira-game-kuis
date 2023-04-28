using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] InitialGameplayData _initialGameplayData;
    [SerializeField] UI_LevelQuestionList _levelQuestionList;
    [SerializeField] UI_LevelPackButton _levelPackButton;
    [SerializeField] RectTransform _content;
    [SerializeField] LevelPackSO[] _levelPacks;

    void Start()
    {
        LoadLevelPack();

        if (_initialGameplayData.IsLose)
        {
            UI_LevelPackButton_OnLevelPackButtonClicked(_initialGameplayData.levelPack);
        }

        UI_LevelPackButton.OnLevelPackButtonClicked += UI_LevelPackButton_OnLevelPackButtonClicked;
    }

    void OnDestroy()
    {
        UI_LevelPackButton.OnLevelPackButtonClicked -= UI_LevelPackButton_OnLevelPackButtonClicked;
    }

    private void UI_LevelPackButton_OnLevelPackButtonClicked(LevelPackSO levelPack)
    {
        _levelQuestionList.gameObject.SetActive(true);
        _levelQuestionList.UnloadLevelPack(levelPack);

        gameObject.SetActive(false);

        _initialGameplayData.levelPack = levelPack;
    }

    void LoadLevelPack()
    {
        foreach (LevelPackSO levelPack in _levelPacks)
        {
            var button = Instantiate(_levelPackButton);
            button.SetLevelPack(levelPack);
            button.transform.SetParent(_content);
            button.transform.localScale = Vector3.one;
        }
    }
}
