using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    struct QuestionData
    {
        public Sprite hintSprite;
        public string level;
        public string question;

        public string[] answers;
        public bool[] isCorrect;
    }

    [SerializeField] QuestionData[] questions;
    [SerializeField] UI_Question _questionUI;
    [SerializeField] UI_AnswerPoint[] _answerUI;

    int _questionIndex = 0;

    void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        _questionIndex++;

        if (_questionIndex >= questions.Length)
        {
            _questionIndex = 0;
        }

        QuestionData question = questions[_questionIndex];

        _questionUI.SetQuestion(question.level, question.question, question.hintSprite);

        for (int i = 0; i < _answerUI.Length; i++)
        {
            UI_AnswerPoint answer = _answerUI[i];
            answer.SetAnswer(question.answers[i], question.isCorrect[i]);
        }
    }
}
