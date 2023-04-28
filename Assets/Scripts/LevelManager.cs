using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] InitialGameplayData _initialGameplayData;
    [SerializeField] PlayerProgressSO _playerProgress;
    [SerializeField] LevelPackSO _levelPack;
    [SerializeField] UI_Question _questionUI;
    [SerializeField] UI_AnswerPoint[] _answerUI;
    [SerializeField] GameSceneManager _gameSceneManager;
    [SerializeField] string _levelSelectSceneName;

    int _questionIndex = -1;

    void Start()
    {
        //if (!_playerProgress.LoadProgress())
        //{
        //    _playerProgress.SaveProgress();
        //}

        _levelPack = _initialGameplayData.levelPack;
        _questionIndex = _initialGameplayData.levelIndex - 1;

        NextLevel();

        UI_AnswerPoint.OnAnswerQuestion += UI_AnswerPoint_OnAnswerQuestion;
    }

    void OnDestroy()
    {
        UI_AnswerPoint.OnAnswerQuestion -= UI_AnswerPoint_OnAnswerQuestion;
    }

    void OnApplicationQuit()
    {
        _initialGameplayData.IsLose = false;
    }

    private void UI_AnswerPoint_OnAnswerQuestion(string answerText, bool isCorrect)
    {
        if (isCorrect)
        {
            _playerProgress.dataProgress.coin += 20;
        }
    }

    public void NextLevel()
    {
        _questionIndex++;

        if (_questionIndex >= _levelPack.QuestionCount)
        {
            // _questionIndex = 0;
            _gameSceneManager.OpenScene(_levelSelectSceneName);
            return;
        }

        LevelQuestionSO question = _levelPack.GetQuestion(_questionIndex);

        _questionUI.SetQuestion(question.level, question.question, question.hintSprite);

        for (int i = 0; i < _answerUI.Length; i++)
        {
            UI_AnswerPoint point = _answerUI[i];
            LevelQuestionSO.Answers answer = question.answers[i];
            point.SetAnswer(answer.answerText, answer.isCorrect);
        }
    }
}
