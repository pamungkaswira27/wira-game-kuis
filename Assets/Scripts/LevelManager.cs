using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerProgressSO _playerProgress;
    [SerializeField] LevelPackSO _levelPack;
    [SerializeField] UI_Question _questionUI;
    [SerializeField] UI_AnswerPoint[] _answerUI;

    int _questionIndex = 0;

    void Start()
    {
        if (!_playerProgress.LoadProgress())
        {
            _playerProgress.SaveProgress();
        }

        NextLevel();
    }

    public void NextLevel()
    {
        _questionIndex++;

        if (_questionIndex >= _levelPack.QuestionCount)
        {
            _questionIndex = 0;
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
