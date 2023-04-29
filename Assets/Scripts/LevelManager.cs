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
    [SerializeField] SoundSpawner _soundSpawner;
    [SerializeField] AudioClip _winClip;
    [SerializeField] AudioClip _loseClip;

    int _questionIndex = -1;

    void Start()
    {
        _levelPack = _initialGameplayData.levelPack;
        _questionIndex = _initialGameplayData.levelIndex - 1;

        NextLevel();
        AudioManager.instance.PlayBGM(1);

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
        _soundSpawner.PlaySoundEffect(isCorrect ? _winClip : _loseClip);

        if (!isCorrect) return;

        var levelPackName = _initialGameplayData.levelPack.name;
        var lastUnlockedLevel = _playerProgress.dataProgress.levelProgress[levelPackName];

        if (_questionIndex + 2 > lastUnlockedLevel)
        {
            _playerProgress.dataProgress.coin += 20;

            _playerProgress.dataProgress.levelProgress[levelPackName] = _questionIndex + 2;
            _playerProgress.SaveProgress();
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
