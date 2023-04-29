using UnityEngine;

public class UI_LevelQuestionList : MonoBehaviour
{
    [SerializeField] InitialGameplayData _initialGameplayData;
    [SerializeField] PlayerProgressSO _playerProgress;
    [SerializeField] UI_LevelButton _levelButton;
    [SerializeField] RectTransform _content;
    [SerializeField] LevelPackSO _levelPack;
    [SerializeField] GameSceneManager _gameSceneManager;
    [SerializeField] string _gameSceneName;

    void Start()
    {
        UI_LevelButton.OnLevelButtonClicked += UI_LevelButton_OnLevelButtonClicked;
    }

    void OnDestroy()
    {
        UI_LevelButton.OnLevelButtonClicked -= UI_LevelButton_OnLevelButtonClicked;
    }

    private void UI_LevelButton_OnLevelButtonClicked(int index)
    {
        _initialGameplayData.levelIndex = index;
        _gameSceneManager.OpenScene(_gameSceneName);
    }

    public void UnloadLevelPack(LevelPackSO levelPack)
    {
        ClearContent();

        var lastUnlockedLevel = _playerProgress.dataProgress.levelProgress[levelPack.name] - 1;

        _levelPack = levelPack;

        for (int i = 0; i < levelPack.QuestionCount; i++)
        {
            var button = Instantiate(_levelButton);
            button.SetLevelQuestion(levelPack.GetQuestion(i), i);
            button.transform.SetParent(_content);
            button.transform.localScale = Vector3.one;

            if (i > lastUnlockedLevel)
            {
                button.ButtonInteraction = false;
            }
        }
    }

    void ClearContent()
    {
        int contentCount = _content.childCount;

        for (int i = 0; i <  contentCount; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
