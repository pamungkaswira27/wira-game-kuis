using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelButton : MonoBehaviour
{
    public static event Action<int> OnLevelButtonClicked;

    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _levelName;
    [SerializeField] LevelQuestionSO _levelQuestion;

    void Start()
    {
        if (_levelQuestion != null)
        {
            SetLevelQuestion(_levelQuestion, _levelQuestion.levelPackIndex);
        }

        _button.onClick.AddListener(OnLevelClicked);
    }

    void OnDestroy()
    {
        _button.onClick.RemoveListener(OnLevelClicked);
    }

    public void SetLevelQuestion(LevelQuestionSO levelQuestion, int index)
    {
        _levelQuestion = levelQuestion;
        _levelQuestion.levelPackIndex = index;

        _levelName.text = levelQuestion.level;
    }

    void OnLevelClicked()
    {
        OnLevelButtonClicked?.Invoke(_levelQuestion.levelPackIndex);
    }
}
